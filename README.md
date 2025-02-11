# ASP.NET Core Grundkurs

Kurs Repository zum Kurs ASP.NET Core Grundkurs der ppedv AG.

## M001 | ASP.NET Überblick

-   [x] Historie
-   [x] Projekte und Projektmappen
-   [x] ASP.Net Core Empty: Hello, World

## M002 | Konfiguration

-   [x] IOC mittels Dependency Injection
-   [x] Aufbau appsettings.json
-   [x] Logging mit Serilog und Filesink
-   [x] Lab: Dependency Injection OperationService

## M003 | Model View Controller (MVC)

-   [x] Overview
-   [x] Links setzen
-   [x] Index und Details
-   [x] Lab: MovieService und MVC App mit Index und Details

## M004 | Razor Pages

-   [ ] Overview
-   [ ] Links setzen
-   [ ] Details

## M005 | Forms und Validierung

-   [x] ViewModel Mapping
-   [x] Form Post & Validierung
-   [x] ModelState
-   [x] Lab: Create Page für Movies erstellt

## M006 | FileServer erstellen

-   [x] Static Files und Directory Browser
-   [x] File Provider und Dateizugriff
-   [x] [Hoppscotch](https://hoppscotch.io/) (Postman Alternative)
-   [x] API mit [httpFile testen](https://learn.microsoft.com/de-de/aspnet/core/test/http-files?view=aspnetcore-8.0)
-   [x] Api-Key mittels Middleware abfragen
-   [x] Lab: Request Culture Middleware

## M007 | HttpClient verwenden

-   [x] Konfiguration auslesen
-   [x] HttpClient verwenden
-   [x] MultipartFormDataContent
-   [x] HttpContext, Request, Response

## M008 | Entity Framework Code First

-   [x] O/R Mapping Framework EFCore
-   [x] Code First Ansatz (Entites + DbContext)
-   [x] LocalDB verwenden (Kommandozeile: `sqllocaldb create|start|stop|info <instanceName>`)
-   [x] [Testing Strategien gegen Datenbank](https://learn.microsoft.com/de-de/ef/core/testing/)
-   [x] Seed erstellen und Abhängigkeiten modellieren
-   [x] DB Migration 

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
-   [ ] Deployment 
