using System;
using System.Collections.Generic;
using Core.Shared.Base.Exceptions;
using Core.Shared.Interfaces;

namespace Core.Shared.Base.Aggregate
{
    public class AggregateFactory
    {
        private readonly ISnapshotRepository<Guid> _snapshotRepository;
        private readonly IEventStore<Guid> _eventStore;
        private readonly long INITIAL_VERSION = 1;

        //summay: aplicações não são obrigadas a possuirem uma estrutura de snapshot
        public AggregateFactory(IEventStore<Guid> eventStore, ISnapshotRepository<Guid> snapshotRepository = null)
        {
            _snapshotRepository = snapshotRepository;
            _eventStore = eventStore;
        }
        
        public TAggregate Create<TAggregate>(Guid? id = null)
            where TAggregate : AggregateRoot<Guid>
        {
            id = id == null || id.Value == Guid.Empty ? Guid.NewGuid() : id;
            
            var existStream = _eventStore.Any(id.Value);
            if(existStream)
                throw new DuplicatedRootException(id.ToString());
            
            var createEvent = new AggregateCreated<Guid>(id.Value);
            var events = new List<IEvent>() { createEvent};
            
            var stream = new EventStream(){ Version = INITIAL_VERSION, Events = events};

            TAggregate aggregate = (TAggregate) Activator.CreateInstance(typeof(TAggregate), new object[] {stream});
            
            aggregate.Changes.Add(createEvent);
            return aggregate;
        }
        
        public TAggregate Load<TAggregate>(Guid id)
            where TAggregate : AggregateRoot<Guid>
        {
            TAggregate root;
            long snapshotVersion = 0;
            
            if (_snapshotRepository != null && _snapshotRepository.TryGetSnapshotById<TAggregate>(id, out root, out snapshotVersion))
            {
                var stream = _eventStore.LoadEventStreamAfterVersion(id, snapshotVersion);
                
                root.ReplayEvents(stream.Events);

                return root;
            }
            else 
            {
                EventStream stream = _eventStore.LoadEventStream(id);

                return (TAggregate)Activator.CreateInstance(typeof(TAggregate), new object[] { stream });
            }
        }
    }
}