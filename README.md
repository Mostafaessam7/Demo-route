## Demo Project
### This project is a multi-layered application built using ASP.NET Core MVC and Entity Framework Core. It follows the N-tier architecture (Business Logic Layer, Data Access Layer, and Presentation Layer), making the system modular and easy to maintain. The application leverages Microsoft Identity for authentication and Entity Framework Core to interact with a SQL Server database.

## Key Features:
#### User Authentication: Integrated with ASP.NET Core Identity for secure login and role-based authorization.
#### Entity Framework Core Integration: Provides seamless interaction with a SQL Server database using code-first migrations and entities.
#### Layered Architecture: Implements a clear separation of concerns, with different layers for handling business logic, data access, and presentation.
#### Localization: Includes resources for language localization, enhancing the user experience for different regions (as seen with the SharedResource.resx file).

## Project Structure:

### Demo.BLL (Business Logic Layer):
#### Contains core business logic and operations.
#### Folders like Helper, Interface, Mapper, Models, and Repository indicate a clean separation of responsibilities within the business layer.
#### Example files: Class1.cs for business operations.

### Demo.DAL (Data Access Layer):
#### Manages all database-related operations.
#### Contains Database, Entity, and Migrations for database schema creation and updates.
#### Integrates Entity Framework Core for ORM functionality and database interactions.
#### Example files: Class1.cs and entity models for data persistence.

### Demo.PL (Presentation Layer):
#### The user interface of the application, which handles web requests and returns views to the user.
#### Includes Controllers, Views, and the wwwroot folder for static assets.
#### Implements localization through resources (SharedResource.resx) for multi-language support.
#### Example files: Program.cs, appsettings.json for configuring the web application and services.

## Technologies Used:
####.NET 6.0: The latest version of the .NET framework, providing performance improvements and modern development features.
#### ASP.NET Core MVC: For building a web-based application with a robust, scalable structure.
#### Entity Framework Core: For data access, allowing easy interaction with the SQL Server database using LINQ and migrations.
#### ASP.NET Identity: For handling user authentication and authorization securely.
#### SQL Server: As the relational database system for persisting data.
#### AutoMapper: For mapping between domain models and DTOs (Data Transfer Objects).
#### Localization: Supports multi-language applications using .resx resource files.

## Installation
### Clone the repository:
#### git clone https://github.com/your-username/demo.git

### Navigate into the project directory:
#### cd demo

### Restore dependencies:
#### dotnet restore

### Apply database migrations:
#### dotnet ef database update

### Run the application:
#### dotnet run

## Usage
### After running the application, users can:
#### Register and log in using the built-in authentication system.
#### Browse, add, and manage products or services (if applicable).
#### Manage orders and view history (if applicable).
#### Access an admin panel (if role-based authorization is enabled).
