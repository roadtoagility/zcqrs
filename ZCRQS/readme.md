###### Objetivo

Este projeto tem como objetivo desenvolver uma arquitetura de referência, que consiga 
evoluir de acordo com as regras de negócio. Uma série de ferramentas vão ser fornecidas para 
a modelagem de domínios ricos.

Alguns dos conceitos abordados aqui são:

- Domain Driven Design
- CQRS (Command Query Responsibility Segregation)
- Event Sourcing

###### Estrutura do repositório

Este repositório é organizado da seguinte forma:

* Core: Solution agrupando todos os projetos do repositório
    * Core.Shared: Centraliza as ferramentas/classes/interfaces compartilhadas, 
    e também define os contratos de relacionamento entre cada uma das estruturas
    de desenvolvimento que vão ser utilizadas.
    * Core.Shared.TestClient: Apenas um projeto de console testando em baixo nível os componentes
    * AppSource: Agrupa todos os projetos da Aplicação de Referência.
 
A aplicação de referência tem como objetivo aplicar os conceitos modelados na Core.Shared.

###### Tecnologias

* ASP.NET Core Framework 3.1
* C# 8.0
TODO




