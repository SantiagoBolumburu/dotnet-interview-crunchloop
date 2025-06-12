# dotnet-interview / TodoApi

[![Open in Coder](https://dev.crunchloop.io/open-in-coder.svg)](https://dev.crunchloop.io/templates/fly-containers/workspace?param.Git%20Repository=git@github.com:crunchloop/dotnet-interview.git)

This is a simple Todo List API built in .NET 8. This project is currently being used for .NET full-stack candidates.

# Execution setup

## Pre-requisites

* **SQL Server Database**: provisioned on the project's devcontainer (explained on next section)
* **MCP Client**: this guide was written based of **Claude Desktop**.
* **Dotnet SDK**: `.Net 8.0`

## Database

The project comes with a devcontainer that provisions a SQL Server database. If you are not going to use the devcontainer, make sure to provision a SQL Server database and update the connection string at:

`./TodoApi/appsettings.Development.json`

## Project Initial Setup

Generate developer cetificates:

`dotnet dev-certs https`

Restore dependencies:

`dotnet restore`

`dotnet tool restore`

Create Database (SQL Server must be up and running):

`dotnet ef database update --project TodoApi`

## Build

To build the application:

`dotnet build`

## Run the API

To run the TodoApi in your local environment:

`dotnet run --project TodoApi`

## Publish and use the Mcp server

To publish the server (generating a Framework dependent excecutable) run the following command:

`dotnet publish ./TodoApi.McpServer -c Release -o ./TodoApi.McpServer/out`

Then configure it on your MCP Client.
Here is how to do it on **Claude Desktop**:

```json
{
    "mcpServers": {
        "TodoApp": {
            "command": "dotnet",
            "args": [
                "<path to root dir of solution folder>\\TodoApi.McpServer\\out\\TodoApi.McpServer.dll"
            ],
            "env": {
                "TODO_API_URL": "http://localhost:5083"
            }
        }
    }
}
```




# For Development

## Update Database

Create Migration:

` dotnet ef migrations add <MigrationName> --project TodoApi`

Apply latest Migration:

`dotnet ef database update --project TodoApi`

## Test

To run tests:

`dotnet test`

Check integration tests at: (https://github.com/crunchloop/interview-tests)

# Other

## Contact

- Martín Fernández (mfernandez@crunchloop.io)

## About Crunchloop

![crunchloop](https://crunchloop.io/logo-blue.png)

We strongly believe in giving back :rocket:. Let's work together [`Get in touch`](https://crunchloop.io/contact).
