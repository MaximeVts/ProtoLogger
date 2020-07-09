# ProtoLogger

This is a small handmade logger written using .NET Core 3.1, it can log to a file, the console or a SQLite database.
The logger could eventually.

It also supports the command `dotnet pack` to be shared as a *Nuget* package.

## How to run the examples

Once you downloaded the repository you can build it with the following command while in the root folder of the solution

```bash
    dotnet build
```

Then you can launch the Console project by this command

```bash
    dotnet run
```

You can also open the solution with VS Code or VS 2019 and simply launch the console project. Tweak each of the example to try different combinations, inspect variables to see how the code works.

## Code structure

|Name|Description|
|--|--|
| ProtoLogger | the core of the logger framework|
| ProtoLogger.UnitTests | Unit test for the logger using Xunit|
| ProtoLogger.Console | a console project to showcase example|
| SQLiteDb | A small project that handles a SQLite model and database operations|

## Design choices

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
        //setup for the options omitted
    }
    services.AddProtoLogger(protoLoggerOptions);
}
```

### Interfaces and abstractions

The main logger is an abstract class called `BaseLogger`, all the other loggers (console, file or Db) derived from this one to ensure feature parity and make easy to add a new type of Logger.

The `IBaseLogger` interface is implemented on the BaseLogger and allow for *dependency injection* and *Unit Testing* (even though I didn't use it for the unit testing in this case).

Each classes must implement the 2 Log methods but are free on how to implement them which give a nice flexibility to the solution.

### Caveats and possible improvements

* Right now the database Logger works only with SQLite but could be improved to use other providers
* The `Log` methods return void at the moment which make them hard to be tested correctly
* For the moment the logging to File can add logs in one file only, but could be improve to let user choose how to cut the files (by date or by logLevel for example)
