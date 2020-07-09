# ProtoLogger

This is a small handmade logger written using .NET Core 3.1, it can log to a file, the console or a SQLite database.
The logger could eventually.

It also supports the command `dotnet pack` to be shared as a *Nuget* package.

## Requirements

* .NET Core 3.1 SDK

## How to run the examples

Once you downloaded the repository you can build it with the following command while in the root folder of the solution

```bash
    dotnet build
```

Then move to the console folder to launch the project with this command

```bash
    cd .\ProtoLoggerConsole\
    dotnet run
```

You can also open the solution with VS Code or VS 2019 and simply launch the console project. Tweak each of the example to try different combinations, inspect variables to see how the code works.

## Code structure

|Name|Description|
|--|--|
| ProtoLogger | the core of the logger framework|
| ProtoLogger.UnitTests | Unit test for the logger using Xunit|
| ProtoLogger.Console | a console project to showcase examples|
| SQLiteDb | A small project that handles a SQLite model and database operations|

## Design choices

Generally the design favors flexibility, software get updated quite often and the ability to easily update a piece of code is very important.

### Dependency injection

I took advantage of the default dependency injection provided by the .NET Core engine to get an easy setup of the logger. In Projects using a startup file like a worker service or an ASP Core application the setup is extremely easy.

Small caveats : the console applications don't have the default DI setup you would find in an ASP Core web app, in that case the setup for the logger would be in the `ConfigureServices()` method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    var protoLoggerOptions = new new LoggerOptions
    {
        ...
        //setup for the options omitted, check the examples to see how to use it
    }
    services.AddProtoLogger(protoLoggerOptions);
}
```

### Interfaces and abstractions

The main logger is an abstract class called `BaseLogger`, all the other loggers (console, file or Db) derived from this one to ensure feature parity and make easy to add a new type of Logger.

```csharp
public class ConsoleLogger : BaseLogger
{
    ...
}

public class FileLogger : BaseLogger
{
    ...
}

public class DatabaseLogger : BaseLogger
{
    ...
}
```

The `IBaseLogger` interface is implemented on the BaseLogger and allow for *dependency injection* and *Unit Testing* (even though I didn't use it for the unit testing in this case).

Each classes must implement the 2 Log methods but are free on how to implement them which give a nice flexibility to the solution.

### Database project

I used EntityFramework Core to communicate with the database, it's an efficient and flexible ORM which will easily allow to change the provider to a real SQL Instance instead of a SQLite file and simplify the setup for database operations.

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(_connectionString);
           ///Change the line above to use SQL Server or PostgreSQL for example
```

For the database logger I used a very simple model to represent the log in the database

```csharp
public class Log
{
    [Key] //to represent the primary key of the SQL table
    public int LogId { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }
}
```

I also used the simple class called `DbRepository` to setup and control what can be done on the DB. This way, my `LoggerContext` is marked as **internal** making it not accessible to the other projects to prevent direct access to the DB.

## Caveats and possible improvements

* Right now the database Logger works only with SQLite but could be improved to use other providers
* The `Log` methods return void at the moment which make them hard to be tested correctly
* For the moment the logging to File can add logs in one file only, but could be improve to let user choose how to cut the files (by date or by logLevel for example)
