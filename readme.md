# Cliente JSON

![Badge em Desenvolvimento](https://img.shields.io/static/v1?label=STATUS&message=FINALIZADO&color=GREEN&style=for-the-badge)

## Introdução
Este projeto é um cliente JSON destinado a testes de comunicação de API com a aplicação Servidor JSON. Ele inclui classes para leitura de dados e permite realizar requisições a endpoints específicos. A cada nova execução do sistema no lado Cliente, um novo usuário é criado do lado Server. As principais tecnologias utilizadas são:

* C#
* MVC
* Console Application

## Dependência
Esta aplicação necessita que o projeto Servidor JSON esteja em execução para funcionar corretamente. Você pode encontrar o projeto Servidor JSON no seguinte repositório:
* [Servidor JSON](https://github.com/Rey-Leal/servidorjson)

## Caminhos de Acesso aos Dados da API em Execução
Abaixo estão os endpoints que podem ser acessados quando a API do Servidor JSON estiver em execução:

- **Produtos**: `http://localhost:64195/api/produto`
- **Usuários**: `http://localhost:64195/api/usuario`
- **Usuário por ID**: `http://localhost:64195/api/usuario/{idUsuario}`

## Estrutura do Projeto
O projeto está organizado da seguinte forma:
* **Controllers**: Contém os controllers que gerenciam as requisições HTTP ao servidor JSON.
* **Models**: Contém as classes de modelo que representam os dados recebidos da API.

## Funcionalidades
* **Realizar requisições à API**: Permite enviar solicitações HTTP aos endpoints do Servidor JSON e processar as respostas.
* **Criar novos usuários**: A cada execução, um novo usuário é criado no servidor.

## Configuração e Execução
Para executar este projeto localmente, siga os passos abaixo:

1. **Clone o repositório**:
   ```bash
   git clone <URL-do-repositorio>
   ```

2. **Navegue até o diretório do projeto**:
   ```bash
   cd nome-do-projeto
   ```

3. **Instale as dependências**:
   Certifique-se de que você tenha o .NET SDK instalado em sua máquina. Instale as dependências com:
   ```bash
   dotnet restore
   ```

4. **Execute o Servidor JSON**:
   Certifique-se de que o projeto [Servidor JSON](https://github.com/Rey-Leal/servidorjson) está em execução.

5. **Atualize as configurações do cliente**:
   Configure as definições necessárias no arquivo `appsettings.json` do cliente para apontar para os endpoints corretos do servidor.

6. **Execute o projeto Cliente JSON**:
   ```bash
   dotnet run
   ```
