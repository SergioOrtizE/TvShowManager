# TV Shows Manager

TV Shows Manager is a console application built with .NET 6. It allows users to manage their favorite TV shows and see them filtered by different criteria such as by platform or type.

## Features

- Add a new Tv Show to the list
- Get all shows mark as favorites
- List all shows or filter them by type or platform
- Mark or unmark a show as favorite
- Delete a show

## Technical Features

- Monolithic architecture: The application is structured as a single, unified code base.
- Designed in layers: The codebase is organized into layers (Data Access, Service, etc) promoting a separation of concerns.
- Uses interfaces: Interfaces are used throughout the application to define contracts for services, making the code more modular, scalable, and testable.
- Implements Dependency Injection: Dependency Injection (DI) is used to achieve loose coupling between objects and their dependencies, thereby enhancing the modularity and testability of the application.
- Uses AutoMapper: AutoMapper library is used for automatic object-object mapping. It reduces the amount of manual code needed to map between Models and View Models.
- Uses xUnit for testing services: The xUnit.net library is used for writing unit tests, particularly for testing the services layer.
- Uses Entity Framework with a DataContext Factory: Entity Framework is used as an Object-Relational Mapper (ORM) for handling database operations. A DataContext Factory is utilized to manage database contexts       efficiently.
- Asynchronous programming: Asynchronous programming patterns are implemented to optimize the application's performance.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- You have a Windows machine with a SQL Server Express LocalDB instance installed and running. If not, you can download SQL Server Express for free from Microsoft's official website. The application will handle database creation, table creation, and initial data seeding.

## Running the app

- On the first run, the application will create the database, tables, and seed initial data if they don't exist.

- Once you've ensured that the prerequisites are met, you can run the application by following these steps:
- Open a terminal (Command Prompt, PowerShell, or a terminal in an IDE).
- Navigate to the project's root directory (where the .csproj file is located).
- Type the following command and press Enter: `dotnet run`

## Built With

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Entity Framework](https://docs.microsoft.com/en-us/ef/)
- [xUnit](https://xunit.net/)
- [AutoMapper](https://automapper.org/)

## Error Handling

The application implements error handling with try-catch blocks.

## Testing

To run the tests, use the command: `dotnet test`

## Contributing to TV Shows Manager

To contribute to TV Shows Manager, follow these steps:

1. Fork this repository.
2. Create a branch: `git checkout -b <branch_name>`.
3. Make your changes and commit them: `git commit -m '<commit_message>'`
4. Push to the original branch: `git push origin <project_name>/<location>`
5. Create the pull request.

Alternatively, see the GitHub documentation on [creating a pull request](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request).

## Contact

If you want to contact me, you can reach me at `<your_email@address.com>`.

## License

This project uses the following license: [<license_name>](<link>).