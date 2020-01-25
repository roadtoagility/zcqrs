using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Infraestructure.EntityFramework;
using Microsoft.Data.SqlClient;
using ProductModule.Queries;
using SharedKernel;

namespace ProductModule.Handlers
{
    
    public class GetAllProductsHandler : QueryHandlerBase<GetAllProducts, IEnumerable<Product>>, IQueryHandler
    {
        public GetAllProductsHandler()
        {
            
        }
        
        public override string GetName()
        {
            return "GetAllProductsHandler";
        }

        public override IEnumerable<Product> Handler(GetAllProducts query)
        {

            IEnumerable<Product> products;
            
            using (IDbConnection db = new SqlConnection("server=localhost;database=BD_BENCHMARK;trusted_connection=false;User ID=sa;Password=abc123@abc;MultipleActiveResultSets=true"))
            {

                products = db.Query<Product>("Select * From TB_PRODUCT").ToList();
            }

            return products;
        }
    }
}