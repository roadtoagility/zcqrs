#### Sobre

Os projetos contidos na pasta AppSource são de uma implementação de referência.

A aplicação trata-se de um site de compras online com algumas funcinalidades:

* Visualizar produtos
    * Buscar produtos
    * Visualizar os detalhes de um produto
    * Adicionar um comentário em um produto
* Carrinho de compras
    * Adicionar produtos ao carrinho
    * Remover produtos do carrinho
* Ordens de compra
    * Executar uma compra
    * Adicionar endereço de entrega
    * Finalizar uma compra
* Conta
    * Criar uma conta
    
 
#### Regras de negócio

###### Buscar produtos
O usuário pode buscar produtos pesquisando pelo seu nome, e o sistema deve considerar tanto o título
quando a descrição no resultado. Apenas produtos que possuem pelo 
menos uma unidade devem ser apresentados ao usuário.


###### Visualizar os detalhes de um produto
Quando o usuário clicar em um produto, o site deve exibir seus detalhes.
Caso o produto tenha comentários, eles devem ser exibidos.
Se o produto já foi adicionado ao carrinho, deve ser exibida uma mensagem informando que o item já está no carrinho.
Caso exista algum produto relacionado com pontuação de estrelas maior que 3, deve ser exibido um link
na página para navegar até o novo produto.



###### Adicionar um comentário em um produto

Se o usuário estiver logado na aplicação, ele deve poder adicionar um comentário.
O comentário tem um título, uma descrição e deve pontuar o produto.
  
###### Adicionar produtos ao carrinho
Se o usuário estiver logado na aplicação, ele deve poder visualizar o botão de adicionar a partir da página
de detalhes do produto.

Caso o usuário não esteja logado, o sistema deve exibir um botão avisando-o para entrar ou se cadastrar.

###### Remover produtos do carrinho

O usuário pode remover itens do carrinho a partir da página de checkout. 
      
###### Executar uma compra

Quando o usuário clicar no botão de comprar, uma ordem de compra deve ser criada.
Apenas usuários logados na aplicação podem efetuar compras.
Se o usuário não está com seu perfil completo, o sistema não deve permitir que a compra seja
criada.

###### Adicionar endereço de entrega

O cliente pode adicionar apenas um endereço de entrega por ordem

###### Finalizar uma compra

O cliente pode finalizar a compra apenas se informou um endereço de entrega.
Clientes com perfil Ouro devem ganhar 10% de desconto.
Clientes com perfil Prata devem ganhar 5% de desconto.
Clientes com perfil Bronze devem ganhar 2% de desconto.

###### Criar uma conta
O usuário pode criar uma conta para poder efetuar compras.


