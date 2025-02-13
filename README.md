# TodoApi
TodoApi is a simple ASP.NET Core Web API for managing a to-do list. It provides endpoints to create, read, update, and delete to-do items. The project uses Entity Framework Core for data access, AutoMapper for object mapping, and a custom global exception handler for error handling.


## Features

- CRUD operations for to-do items
- Swagger for API documentation
- Global exception handling
- Dependency injection for services
- Logging

## Technologies

- ASP.NET Core
- Entity Framework Core
- AutoMapper
- Swagger

## Getting Started
1. Clone the repository
2. Update the connection string in appsettings.json
3. Run dotnet ef migrations add InitialCreate to create the database
4. Run dotnet run to start the application