# RH Rest Api
Rest API para recursos humanos desenvolvida para demonstrar meus conhecimentos com .NET Core e ASP.NET Core.
Este projeto foi desenvolvido como parte de um desafio para uma vaga de desenvolvedor júnior C#.

## O que foi realizado
Conforme proposto pelos requisitos do projeto, foram implementados uma REST Api capaz de visualizar, adicionar, editar e remover (CRUD) funcionários de um sistema de Rh e um painel administrativo capaz de consumir essa Api;  
  
A api contém dados referentes ao funcionário incluindo: id, nome, email, cargo, salário, data de contratação;  
  
Todos os desafios opcionais foram realizados:
  * **Validação de email**:  
    Cada funcionário possui um email único, se uma requisição POST ou PUT tentar inserir um funcionário com um email já presente no banco de dados uma resposta **409 - Conflict** com uma mensagem de alerta será devolvida pela api, caso o contrário uma resposta **200 - Success**, contanto que todos os dados inseridos sejam válidos, será devolvida, esse processo é feito em adição a validação padrão para verificar se o email inserido é de fato um email.
  * **Ordenação da lista de funcionários pelo salário**:  
    Funcionários podem ser ordenados pelo salário em ordem crescente ou decrescente, feito utilizando JavaScript + jQuery + DataTables.
  * **Filtro de busca de funcionários por nome**:  
    Funcionários podem ser buscados pelo nome utilizando a barra de buscas acima da tabela de funcionários, feito utilizando JavaScript + jQuery + DataTables.
    
## REST Api
A REST Api desenvolvida possui os seguintes métodos:  
* **GET** - 'url'/api  
**200 - Success** : Devolve um json contendo todos os funcionários cadastrados no sistema.
* **GET** - 'url'/api/{id}  
**200 - Success** : Devolve um json contendo o funcionário com o id provido.  
**404 - Not Found**: Devolve uma mensagem avisando que o funcionário não foi encontrado caso a api não encontre um funcionário com o id informado.  
**400 - Bad Request**: Devolve uma mensagem de erro se o id provido não for um valor válido.  
* **GET** - 'url'/api/email/?email={email}  
**200 - Success** : Devolve um json contendo o funcionário com o email provido.  
**404 - Not Found**: Devolve uma mensagem avisando que o funcionário não foi encontrado caso a api não encontre um funcionário com o email informado.  
* **POST** - 'url'/api  
**200 - Success** : Requer um json de entrada, insere um novo funcionário no sistema e devolve o funcionário inserido em formato json.  
**400 - Bad Request** : Devolve uma mensagem de erro se o json de entrada não for válido.  
**409 - Conflict** : Devolve uma mensagem de aviso informando que o email presente no json de entrada já está cadastrado no sistema.  
* **PUT** - 'url'/api/{id}  
**200 - Success** : Requer um json de entrada, altera as informações do funcionário com o id provido usando as informações presentes no json e devolve o funcionário editado em formato json.  
**404 - Not Found**: Devolve uma mensagem avisando que o funcionário não foi encontrado caso a api não encontre um funcionário com o id informado.  
**400 - Bad Request** : Devolve uma mensagem de erro se o json de entrada ou o id não forem válidos.  
**409 - Conflict** : Devolve uma mensagem de aviso informando que o email presente no json de entrada já está cadastrado no sistema.  
* **DELETE** - 'url'/api/{id}  
**200 - Success** : Remove o funcionário com o id especificado do sistema e devolve um json contendo o usuário deletado.  
**404 - Not Found**: Devolve uma mensagem avisando que o funcionário não foi encontrado caso a api não encontre um funcionário com o id informado.  
**400 - Bad Request**: Devolve uma mensagem de erro se o id provido não for um valor válido.  

### Modelo de resposta GET

```json
{
  "id":1,
  "name":"Nome do funcionário",
  "email":"email@email.com",
  "job":"Cargo",
  "salary":1000,
  "hiringDate":"2019-10-14T15:19:37.5137032"
}
```

### Modelo de requisição POST/PUT

Exemplo de json para POST/PUT:
```json
{
  "name":"Nome do funcionário",
  "email":"email@email.com",
  "job":"Cargo",
  "salary":1000
}
```
* **name**:
  * Deve possuir no mínimo 2 caracteres
  * Deve possuir no máximo 40 caracteres
  * Não pode conter caracteres especiais (/[]@*...)
* **email**:
  * Deve possuir no máximo 60 caracteres
  * Deve possuir formato de email
* **job**:
  * Deve possuir no mínimo 2 caracteres
* **salary**:  
  * Valor deve ser no mínimo 0
  * Valor deve ser no máximo 999999
  * Deve ser um número
  * Utiliza até duas casas decimais  

Todos os campos são obrigatórios.  
"hiringDate" (Data de contratação) é gerada automaticamente pelo backend da Api no momento de cadastro, utilizando **DateTime.Now**, portanto não é utilizado para POST/PUT.

## Painel Administrativo / Interface
* Possui duas páginas:
  * **Index**: Contém a form para inserção de novos funcionários e a tabela de funcionários cadastrados.
  * **Edit**: Contém a form para edição de funcionário.
* Validação é feita de forma simples no front end utilizando JavaScript e de forma mais completa no backend;
* O backend é responsável por realizar todas as requisições HTTP para a Rest Api, com exceção do método **DELETE**, que é feito através de JavaScript utilizando AJAX;
* Funcionamento do painel foi testado e comprovado nos navegadores: Google Chrome, Mozilla Firefox, Microsoft Edge, Opera e Internet Explorer 11.  

## Tecnologias utilizadas

* Database:
  * SQLite
* Back End:
  * C#
  * .NET 6.0
  * ASP.NET Core MVC
  * Entity Framework Core
* Front End:
  * HTML5 (Razor pages)
  * CSS3
  * JavaScript
  * Bootstrap 4
  * jQuery
  * DataTables

