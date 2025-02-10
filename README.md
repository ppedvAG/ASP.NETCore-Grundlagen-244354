# ASP.NET Core Grundkurs

Kurs Repository zum Kurs ASP.NET Core Grundkurs der ppedv AG.

## M001 | ASP.NET Überblick

-   [x] Historie
-   [x] Projekte und Projektmappen
-   [x] ASP.Net Core Empty: Hello, World

## M002 | Konfiguration

-   [x] IOC mittels Dependency Injection
-   [x] Aufbau appsettings.json
-   [x] Logging in ASP.NET Core

## M003 | Model View Controller (MVC)

-   [x] Overview
-   [x] Links setzen
-   [x] Details

## M004 | Razor Pages

-   [ ] Overview
-   [ ] Links setzen
-   [ ] Details

## M005 | Forms und Validierung

-   [x] ViewModel Mapping
-   [ ] Form Post & Validierung
-   [ ] ModelState

## M006 | FileServer erstellen

-   [ ] Static Files und Directory Browser
-   [ ] File Provider und Dateizugriff
-   [ ] [Hoppscotch](https://hoppscotch.io/) (Postman Alternative)
-   [ ] API mit [httpFile testen](https://learn.microsoft.com/de-de/aspnet/core/test/http-files?view=aspnetcore-8.0)
-   [ ] Middleware

## M007 | HttpClient verwenden

-   [ ] Konfiguration auslesen
-   [ ] HttpClient verwenden
-   [ ] MultipartFormDataContent
-   [ ] HttpContext, Request, Response

## M008 | Entity Framework Code First

-   [ ] O/R Mapping Framework EFCore
-   [ ] Code First Ansatz (Entites + DbContext)
-   [ ] LocalDB
-   [ ] DB Migration

```bash
// Package Manager Console aufrufen

Add-Migration InitMyModel -Context MyAppDbContext

Update-Database

```

## M009 | Entity Framework DB First

-   [ ] Unit Tests mit EntityFramework
-   [ ] OrderService anhand von Tests entwickeln
-   [ ] DB First Ansatz
-   [ ] VS Extension [EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)
-   [ ] Controller mit Scaffolding erstellen (Microsoft.EntityFrameworkCore.Design)
-   [ ] [Northwind DB](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)

## M010 | Benutzerverwaltung

-   [ ] AspNetCore.Identity.EFCore
-   [ ] CodeFirst & Migration
-   [ ] UserManager & SignInManager
-   [ ] Form Post & Validierung
-   [ ] MS Identity Platform gegen EntraId und GraphAPI

## M011 | Weitere Themen

-   [ ] Lokalisierung
-   [ ] Cookie Handling
-   [ ] Server Caching
-   [ ] Deployment IIS Server
