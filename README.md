# D-Fitness Gym Web API

This is a **.NET 8 Web API** for managing a gym application including **Users, Trainers, Admins, Memberships, Subscriptions, and Transactions**. 
The project uses **Entity Framework Core** for database access, follows a **layered architecture** with **Repositories, Services, and Controllers**, and supports **dependency injection** for maintainability.

---

## Table of Contents

1. [Project Overview](#project-overview)
2. [Architecture & Design](#architecture--design)
3. [Prerequisites](#prerequisites)
4. [Setup & Installation](#setup--installation)
5. [Environment Variables](#environment-variables)
6. [Running the Project](#running-the-project)
7. [Folder Structure](#folder-structure)
8. [Logging](#logging)
9. [Unit Testing](#unit-testing)

---

## Project Overview

The D-Fitness Gym Web API provides endpoints for:

* **Roles**: Create, read, update, delete roles.
* **Accounts**: Manage Users, Trainers, and Admins.
* **Memberships & Subscriptions**: CRUD operations and tracking subscription status.
* **Transactions**: Handle subscription payments, salaries, and other transactions.

---

## Architecture & Design

The project follows **clean architecture** principles:

1. **Controllers**: Handle HTTP requests and responses (`RolesController`, etc.).
2. **Services**: Contain business logic and communicate with repositories (`RoleService`).
3. **Repositories**: Handle database operations using EF Core (`RoleRepository`).
4. **Data**: Contains `ApplicationDbContext` and migrations.
5. **Models**:
   * `Enumns` → enum fields.
   * `Entities` → database models.
   * `DTOs` → data transfer objects for API requests/responses.
6. **Logging**: Injected into controllers and services using `ILogger<T>`.
7. **Dependency Injection**: Services and repositories registered in `Program.cs` for maintainable code.
8. **Unit Testing**: Each controller and service can be tested independently using xUnit/Moq.

---

## Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code
* SQL Server (local or remote)
* Git

---

## Setup & Installation

1. **Clone the repository**

```bash
git clone https://github.com/jeethendra2000/D_Fitness_Gym_Backend_API.git
cd D_Fitness_Gym_Backend_API
```

2. **Open the solution in Visual Studio**

* Double click `D-Fitness-Gym.sln`

3. **Install NuGet packages** (if not automatically restored):

```bash
dotnet restore
```

* Key packages used:

  * `Microsoft.EntityFrameworkCore`
  * `Microsoft.EntityFrameworkCore.SqlServer`
  * `Microsoft.EntityFrameworkCore.Tools`
  * `Swashbuckle.AspNetCore` (Swagger)
  * `DotNetEnv` (for environment variables)
  * `Moq` / `xUnit` (for unit tests)

4. **Update Database Connection**

* Create a `.env` file in the solution root:

```
DB_CONNECTION_STRING=Server=localhost;Database=D-FitnessDB;Trusted_Connection=True;
```

* The connection string is referenced in `Program.cs` via `DotNetEnv`.

---

## Running the Project

1. **Apply Migrations** (if database not created yet):

```bash
EntityFrameworkCore\Add-Migration "initial Migrations"
EntityFrameworkCore\update-database
```

2. **Run the Web API**

* From Visual Studio → Press `F5` or `Ctrl+F5`


3. **Swagger UI**

* Navigate to: `https://localhost:<port>/swagger` to explore API endpoints.

---

## Folder Structure

```
D-Fitness-Gym/
│
├─ Controllers/             # API endpoints / controllers
├─ Services/                # Business logic layer
│   └─ Interfaces/          # Interfaces for services
├─ Repositories/            # Data access layer for Database operations
│   └─ Interfaces/          # Interfaces for repositories
├─ Data/                    # ApplicationDbContext, seeding, EF migrations
├─ Middleware/              # Custom middlewares (e.g. error handling, logging)
├─ Mappings/                # AutoMapper profiles
├─ Models/
│   ├─ Entities/            # EF Core entities (Account, Role, Subscription, etc.)
│   ├─ DTO/                 # DTOs for API communication
│   │   ├─ AccountDto/
│   │   └─ RoleDto/
│   └─ Enums/               # Enum definitions
├─ Utils/                   # Helper classes (extensions, constants, etc.)
├─ Properties/              # Assembly info
├─ Migrations/              # EF Core migrations (optional inside Data/)
├─ D-Fitness-Gym.sln
├─ Program.cs
├─ Startup.cs               # (optional, if you prefer instead of Program.cs)
├─ appsettings.json
├─ appsettings.Development.json
├─ appsettings.Production.json
├─ .env                     # Env vars (connection strings, secrets)
├─ .gitignore
└─ README.md
```
## Folder Structure For Test
```
D_Fitness_Gym.Tests/
│
├─ Controllers/             # Unit tests for controllers
├─ Services/                # Unit tests for services
├─ Repositories/            # Unit tests for repositories
├─ TestHelpers/             # Test utils (mock data, in-memory DB, etc.)
│
├─ D_Fitness_Gym.Tests.csproj
└─ appsettings.Test.json
```

---

## Logging

* Logging is implemented using `ILogger<T>` in **Controllers, Services, and Repositories**.
* Follows industry standard for monitoring API operations, debugging, and error tracking.

---

## Unit Testing

* Uses **xUnit** for unit testing.
* Separate project: `D-Fitness-Gym.Tests`
* Tests include:

  * Controller actions
  * Service methods
  * Repository operations (optional with in-memory DB)
* Example test class naming convention: `RolesControllerUnitTests.cs`

---

💡 **Industry Practices Followed**:

* DTOs for request/response separation
* Dependency Injection for maintainable, testable code
* Logging with `ILogger`
* Unit tests for critical business logic and APIs
* Environment variables for secrets

---
