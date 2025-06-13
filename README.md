⌨️ ASP.NET Core MVC - Group Assignment

This is a group project for building a complete ASP.NET Core MVC web application using Clean Architecture principles. The purpose is to demonstrate a full understanding of ASP.NET Core MVC, authentication, role management, view models, data access, and unit testing.

📌 Assignment Goals

The application is built according to the official course requirements. It demonstrates the core concepts of ASP.NET Core MVC by implementing the following features:

✅ Features

    Clean Architecture
        The solution is divided into separate projects:
        - Domain
        - Application
        - Infrastructure
        - WebUI (MVC)
        - ConsoleClient
        - Tests

    Domain Model
        The application is based on a single entity (e.g., Car, Band, Watch).
        The model contains basic properties like Id, Name, Description, etc.

    Entity List Page
        A page that displays all entities from the database.

    Create Form
        A form allows users to create and add new entities.

    Form Validation
        - Client-side validation using HTML and JavaScript
        - Server-side validation using data annotations and ModelState.IsValid

    ASP.NET Core Identity
        - User registration
        - Login and logout
        - Authorized-only page: /members (requires login)
        - Admin-only page: /admin (requires role "Administrators")

    Razor Views and MVC Features
        - Shared layout using _Layout.cshtml
        - _ViewStart.cshtml and _ViewImports.cshtml configured
        - Exactly one unique ViewModel per View
        - At least two Controller classes: one for the entity, one for account handling

    Data Access
        - Uses Entity Framework Core
        - Database context and migrations configured in the Infrastructure project

    Unit Testing
        - Application services tested in Application.Tests
        - Controllers tested in WebUI.Tests

    Console Application
        - A ConsoleClient project that reads and prints entities using the Application layer

🛠️ Technologies Used

    ASP.NET Core 9.0 MVC
    C#
    Razor Views
    Entity Framework Core
    ASP.NET Core Identity
    xUnit and Moq (for unit testing)
    Visual Studio 2022+
    SQL Server LocalDB
