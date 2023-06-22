# Web | Angular & .NET Web API

## Voraussetzungen

Für den Start benötigst du folgendes Setup.

- [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) ist installiert
- [Node LTS](https://nodejs.org) ist installiert
- Eine IDE deiner Wahl (Visual Studio Code, Visual Studio, Rider, WebStorm)

## Start

### Web API

```bash
cd Api
dotnet restore
dotnet run

# API started unter https://localhost:7054
# Open API Dokumentation ist erreichbar unter https://localhost:7054/swagger
```

### Angular

```bash
cd client
npm ci
npm start -- --open

# Client startet unter http://localhost:4200
```
