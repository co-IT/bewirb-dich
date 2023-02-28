# Fullstack

## Bevor Du beginnst...

Bitte stell sicher, dass auf deinem System die folgenden Plattformen installiert sind.

- [.Net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Node LTS](https://nodejs.org/)

## Setup

### Das Projekt herunterladen und die Pakete installieren

Wir haben ein Repository, in dem wir alle Aufgaben für verschiedene Kandidaten
sammeln.
Für Dich haben wir eine Fullstack-Aufgabe.
Diese haben wir mit [Nx](https://nx.dev) aufgesetzt, damit der Code für
API und Client nahe beieinander liegen und sich komfortabel entwickeln lässt.

Das Projekt kannst du wie folgt laden und installieren.
Übrigens wird der Befehl `npm ci` auch die NuGet-Pakete installieren.

```bash
git clone https://github.com/co-IT/bewirb-dich.git
cd bewirb-dich/src/fullstack
npm ci
```

### .NET Web API starten

> Den Source Code findest Du unter apps/documents-api.

```bash
npx nx run documents-api:serve
## API erreichbar unter https://localhost:7157
```

### .NET Web API testen

> Den Source Code findest Du unter apps/documents-api-test.

```bash
npx nx run documents-api-test:test
```

### UI starten

> Den Source Code findest Du unter apps/documents.

```bash
npx nx run documents:serve
## Client erreichbar unter https://localhost:4200
```

### UI Tests Ausführen

> Den Source Code findest Du unter apps/documents-e2e.

```bash
npx nx run documents-e2e:e2e --watch
## Öffnet Cypress App
```

## Troubleshooting

Beim Start der Web API kann es passieren, dass sie mit einem Fehler abbricht,
wenn die Developer Zertifikate noch nicht installiert wurden oder abgelaufen sind.

Die Fehlermeldungen sehen wie folgt aus:

![](./assets/trouble-shooting-1.png)
![](./assets/trouble-shooting-2.png)

Wie in den Bildern zu sehen werden in den Fehlermeldungen auch Commandos genannt,
mit denen die Probleme behoben werden können

```bash
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

This project was generated using [Nx](https://nx.dev).

<p style="text-align: center;"><img src="https://raw.githubusercontent.com/nrwl/nx/master/images/nx-logo.png" width="450"></p>

🔎 **Smart, Fast and Extensible Build System**

## Quick Start & Documentation

[Nx Documentation](https://nx.dev/getting-started/intro)

[Mental model is a good starting point for those who like to understand things theoretically first.](https://nx.dev/concepts/mental-model)

[Interactive Tutorial](https://nx.dev/getting-started/angular-tutorial)

## Adding capabilities to your workspace

Nx supports many plugins which add capabilities for developing different types of applications and different tools.

These capabilities include generating applications, libraries, etc as well as the devtools to test, and build projects as well.

Below are our core plugins:

- [Angular](https://angular.io)
  - `ng add @nrwl/angular`
- [React](https://reactjs.org)
  - `ng add @nrwl/react`
- Web (no framework frontends)
  - `ng add @nrwl/web`
- [Nest](https://nestjs.com)
  - `ng add @nrwl/nest`
- [Express](https://expressjs.com)
  - `ng add @nrwl/express`
- [Node](https://nodejs.org)
  - `ng add @nrwl/node`

There are also many [community plugins](https://nx.dev/community) you could add.

## Generate an application

Run `ng g @nrwl/angular:app my-app` to generate an application.

> You can use any of the plugins above to generate applications as well.

When using Nx, you can create multiple applications and libraries in the same workspace.

## Generate a library

Run `ng g @nrwl/angular:lib my-lib` to generate a library.

> You can also use any of the plugins above to generate libraries as well.

Libraries are shareable across libraries and applications. They can be imported from `@fullstack/mylib`.

## Development server

Run `ng serve my-app` for a dev server. Navigate to http://localhost:4200/. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng g component my-component --project=my-app` to generate a new component.

## Build

Run `ng build my-app` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test my-app` to execute the unit tests via [Jest](https://jestjs.io).

Run `nx affected:test` to execute the unit tests affected by a change.

## Running end-to-end tests

Run `ng e2e my-app` to execute the end-to-end tests via [Cypress](https://www.cypress.io).

Run `nx affected:e2e` to execute the end-to-end tests affected by a change.

## Understand your workspace

Run `nx graph` to see a diagram of the dependencies of your projects.

## Further help

Visit the [Nx Documentation](https://nx.dev/angular) to learn more.

## ☁ Nx Cloud

### Distributed Computation Caching & Distributed Task Execution

<p style="text-align: center;"><img src="https://raw.githubusercontent.com/nrwl/nx/master/images/nx-cloud-card.png"></p>

Nx Cloud pairs with Nx in order to enable you to build and test code more rapidly, by up to 10 times. Even teams that are new to Nx can connect to Nx Cloud and start saving time instantly.

Teams using Nx gain the advantage of building full-stack applications with their preferred framework alongside Nx’s advanced code generation and project dependency graph, plus a unified experience for both frontend and backend developers.

Visit [Nx Cloud](https://nx.app/) to learn more.
