# Library API

A clean and scalable ASP.NET Core Web API for managing library books and authors. Built using a 3-tier architecture and the Generic Repository Pattern.

## Tech Stack
* **Framework:** .NET 8 / C#
* **Data Access:** Entity Framework Core
* **Database:** SQL Server (LocalDB)
* **Documentation:** Swagger UI

## Architecture
The solution is split into three separate projects to ensure clean code and separation of concerns:
* **Library.API:** The main entry point containing the HTTP controllers and Dependency Injection setup.
* **Library.BackendData:** The domain layer containing the data models (`Book` and `Author`).
* **Library.DBInfrastructure:** The data access layer containing the EF Core `LibraryContext` and the generic `IRepository<T>` implementation.

## Features
* **Full CRUD:** Create, Read, Update, and Delete endpoints for Books and Authors.
* **Generic Repository Pattern:** Keeps controllers thin and avoids repetitive database code.
* **Relational Data:** Manages One-to-Many relationships gracefully.
* **Auto-Validation:** Utilizes built-in `ModelState` validation for clean incoming requests.
