# FullstackAngularDotnet

## Voraussetzungen

Für den Start benötigst du folgendes Setup.

- [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) ist installiert
- [Node LTS](https://nodejs.org) ist installiert
- Eine IDE deiner Wahl (Visual Studio Code, Visual Studio, Rider, WebStorm)

Abhängigkeiten installieren: `npm install`.

## Web API

Die WebAPI liegt unter `apps/creepy-api`

Zum Starten: `npm run start:api` (Die API startet unter https://localhost:7054. Die Open API Dokumentation ist erreichbar unter https://localhost:7054/swagger)

Zum Testen: `npm run test:api`

## Angular

Der Client liegt unter `apps/creepy-client`

Zum Starten: `npm run start:client` (Der Client startet unter http://localhost:4200)

Zum Testen: `npm run test:client`

Zum e2e Testen: `npm run e2e:client`


