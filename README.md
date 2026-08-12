# Store API

Projeto criado com o objetivo de estudar, na prática, os fundamentos do desenvolvimento de **APIs REST utilizando ASP.NET Core e C#**.

Este repositório acompanha minha evolução no desenvolvimento de APIs, começando pelos conceitos mais básicos e avançando gradualmente para arquitetura, persistência de dados, validações, autenticação e boas práticas utilizadas em aplicações reais.

## 🎯 Objetivo do estudo

O objetivo deste projeto é compreender todo o fluxo de construção de uma API em .NET, evitando apenas copiar código pronto.

Durante o desenvolvimento, cada recurso é implementado de forma incremental para entender conceitos como:

* Estrutura de uma aplicação ASP.NET Core
* Controllers
* Rotas
* Métodos HTTP
* Parâmetros de rota
* Status Codes
* Injeção de dependência
* Configuração da aplicação
* Persistência de dados
* Arquitetura e separação de responsabilidades
* Boas práticas para APIs REST

---

## 🛠️ Tecnologias

Neste estágio do projeto:

* **C#**
* **.NET / ASP.NET Core**
* **ASP.NET Core Web API**
* **PowerShell**
* **Git**
* **GitHub**

Outras tecnologias poderão ser adicionadas conforme a evolução do estudo.

---

## 📁 Estrutura inicial

A solução foi organizada mantendo o projeto da API dentro do diretório `src`:

```text
Store/
│
├── src/
│   └── Store.Api/
│       ├── Controllers/
│       │   └── ProductsController.cs
│       ├── Properties/
│       │   └── launchSettings.json
│       ├── Program.cs
│       └── Store.Api.csproj
│
├── Store.slnx
├── README.md
└── LICENSE
```

A solução utiliza o formato moderno:

```text
Store.slnx
```

O projeto principal da API está localizado em:

```text
src/Store.Api/Store.Api.csproj
```

---

# 📚 Conceitos estudados

## 1. Solução e projeto

Uma solução `.slnx` funciona como um agrupador dos projetos que fazem parte da aplicação.

O projeto da API foi adicionado à solução com:

```powershell
dotnet sln .\Store.slnx add .\src\Store.Api\Store.Api.csproj
```

Para visualizar os projetos registrados:

```powershell
dotnet sln .\Store.slnx list
```

---

## 2. Executando a API

A aplicação pode ser iniciada através do .NET CLI:

```powershell
dotnet run --project src/Store.Api
```

Durante os estudos, a API foi executada localmente em:

```text
http://localhost:5009
```

Ao iniciar corretamente, o ASP.NET Core informa no terminal:

```text
Now listening on: http://localhost:5009
Application started.
Hosting environment: Development
```

A mensagem `Now listening on` indica em qual endereço a aplicação está aguardando requisições HTTP.

---

## 3. Controllers

Foi criado o primeiro controller da aplicação:

```text
ProductsController
```

Exemplo:

```csharp
using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Listando todos os produtos");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Buscando o produto de ID {id}");
        }
    }
}
```

O atributo:

```csharp
[ApiController]
```

indica que a classe participa do comportamento específico de controllers de uma ASP.NET Core Web API.

O controller herda de:

```csharp
ControllerBase
```

que fornece funcionalidades úteis para construção das respostas HTTP.

---

## 4. Rotas

A rota base foi definida através de:

```csharp
[Route("api/v1/products")]
```

Com a API executando em:

```text
http://localhost:5009
```

a URL completa passa a ser:

```text
http://localhost:5009/api/v1/products
```

A estrutura pode ser entendida como:

```text
http://localhost:5009
        +
api/v1/products
        ↓
http://localhost:5009/api/v1/products
```

---

## 5. Métodos HTTP

O primeiro método estudado foi o `GET`.

```csharp
[HttpGet]
public IActionResult GetAll()
{
    return Ok();
}
```

Ele representa o endpoint:

```http
GET /api/v1/products
```

Um conceito importante aprendido durante o estudo é que `GET` **não faz parte da URL**.

Portanto, isto está incorreto:

```text
http://localhost:5009/GET/api/v1/products
```

O correto é:

```text
http://localhost:5009/api/v1/products
```

`GET` representa o método HTTP utilizado na requisição.

---

## 6. Parâmetros de rota

Também foi estudada a utilização de parâmetros diretamente na URL.

Exemplo:

```csharp
[HttpGet("{id:int}")]
public IActionResult GetById(int id)
{
    return Ok($"Buscando o produto de ID {id}");
}
```

Esse endpoint permite requisições como:

```http
GET /api/v1/products/10
```

No ambiente local:

```text
http://localhost:5009/api/v1/products/10
```

Nesse caso:

```text
10
```

é capturado da URL e disponibilizado para:

```csharp
int id
```

Se a requisição fosse:

```text
http://localhost:5009/api/v1/products/25
```

o parâmetro `id` receberia:

```text
25
```

A restrição:

```csharp
{id:int}
```

determina que aquele segmento da rota deve representar um número inteiro.

---

## 7. IActionResult e respostas HTTP

Os métodos do controller inicialmente utilizam:

```csharp
IActionResult
```

Isso permite que o endpoint retorne diferentes tipos de respostas HTTP.

Por exemplo:

```csharp
return Ok();
```

representa uma resposta HTTP:

```text
200 OK
```

Também é possível retornar conteúdo:

```csharp
return Ok("Minha primeira API está funcionando!");
```

Ou objetos, que posteriormente poderão ser serializados para JSON:

```csharp
return Ok(produto);
```

---

## 8. HTTP e HTTPS

Durante os testes também foi estudada a diferença entre:

```text
http://
```

e:

```text
https://
```

O arquivo:

```text
Properties/launchSettings.json
```

define os profiles utilizados durante o desenvolvimento.

Exemplo:

```json
{
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5009",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:7052;http://localhost:5009",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

Para iniciar explicitamente utilizando o profile HTTPS:

```powershell
dotnet run --project src/Store.Api --launch-profile https
```

---

## 9. HTTPS Redirection

Também foi analisado o middleware:

```csharp
app.UseHttpsRedirection();
```

Quando a aplicação é executada apenas em HTTP e esse middleware está habilitado, pode aparecer o aviso:

```text
Failed to determine the https port for redirect.
```

Isso acontece porque a aplicação está tentando determinar uma porta HTTPS para realizar o redirecionamento.

Durante desenvolvimento exclusivamente HTTP, o middleware pode ser desabilitado temporariamente:

```csharp
// app.UseHttpsRedirection();
```

Ou a aplicação pode ser iniciada utilizando um profile que também disponibilize HTTPS.

---

## 10. Portas e processos

Durante os testes também foi necessário verificar se outra instância da API estava utilizando a porta `5009`.

No Windows:

```powershell
netstat -ano | findstr :5009
```

Também é possível consultar especificamente processos escutando naquela porta:

```powershell
Get-NetTCPConnection -LocalPort 5009 -State Listen
```

Caso exista um processo, o campo:

```text
OwningProcess
```

indica seu PID.

É possível consultar o processo com:

```powershell
Get-Process -Id <PID>
```

E encerrá-lo com:

```powershell
Stop-Process -Id <PID> -Force
```

Ao executar a API diretamente pelo terminal, a forma preferencial de encerrá-la é:

```text
Ctrl + C
```

---

## 11. Entendendo o estado TIME_WAIT

Durante a investigação de portas também apareceu o estado:

```text
TIME_WAIT
```

Exemplo:

```text
TCP    [::1]:5009    [::1]:50399    TIME_WAIT    0
```

Isso não significa necessariamente que existe uma aplicação utilizando a porta.

`TIME_WAIT` faz parte do funcionamento normal do protocolo TCP e representa uma conexão que já foi encerrada, mas que permanece registrada temporariamente pelo sistema operacional.

Para identificar uma aplicação realmente aguardando conexões, o estado relevante é:

```text
LISTENING
```

ou `Listen` nas ferramentas do PowerShell.

---

# 🔄 Fluxo aprendido até aqui

Neste ponto do estudo, o fluxo básico de uma requisição já pode ser representado como:

```text
Cliente / Navegador
        │
        │ GET /api/v1/products/10
        ▼
ASP.NET Core
        │
        ▼
Roteamento
        │
        ▼
ProductsController
        │
        ▼
GetById(10)
        │
        ▼
return Ok(...)
        │
        ▼
HTTP 200 OK
        │
        ▼
Cliente
```

Esse fluxo é a base sobre a qual os próximos recursos da API serão construídos.

---

# 🧪 Endpoints atuais

### Listar produtos

```http
GET /api/v1/products
```

Exemplo local:

```text
http://localhost:5009/api/v1/products
```

### Buscar produto por ID

```http
GET /api/v1/products/{id}
```

Exemplo:

```text
http://localhost:5009/api/v1/products/10
```

---

# 🚀 Próximas etapas

Com a estrutura inicial funcionando, os próximos estudos do projeto poderão incluir:

* Models e entidades
* DTOs
* Retorno de objetos JSON
* `POST`
* `PUT`
* `DELETE`
* Status Codes apropriados
* Validação de dados
* Injeção de dependência
* Services
* Repositories
* Entity Framework Core ou outra estratégia de acesso a dados
* SQL Server
* Migrations
* Tratamento global de exceções
* Logging
* Swagger / OpenAPI
* Autenticação
* Autorização
* JWT
* Testes automatizados
* Arquitetura em camadas

---

## 📈 Status do projeto

Atualmente:

```text
[✓] Solução criada
[✓] Projeto ASP.NET Core criado
[✓] Projeto adicionado à solução
[✓] API compilando
[✓] API executando localmente
[✓] Primeiro Controller criado
[✓] Primeiro endpoint GET
[✓] Parâmetros de rota
[✓] Testes pelo navegador
[✓] Entendimento básico de HTTP/HTTPS
[✓] Diagnóstico de portas TCP
[ ] Models
[ ] DTOs
[ ] Banco de dados
[ ] POST
[ ] PUT
[ ] DELETE
[ ] Services
[ ] Repositories
[ ] Validações
[ ] Autenticação
[ ] Testes automatizados
```

---

## 📝 Sobre o projeto

Este projeto não tem como objetivo apenas produzir uma API funcional.

A proposta é utilizá-lo como um laboratório de estudos para compreender **como uma API ASP.NET Core funciona internamente**, evoluindo a aplicação gradualmente e aplicando boas práticas conforme novos conceitos forem introduzidos.

Cada etapa será construída sobre os conhecimentos adquiridos anteriormente, permitindo acompanhar a evolução desde um endpoint simples até uma API estruturada de forma próxima a aplicações utilizadas profissionalmente.

