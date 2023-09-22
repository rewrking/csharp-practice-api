# csharp-practice-api

Following a .NET 7.0 tutorial... and exploring generics.

### Instructions

- Install Visual Studio, .NET 7.0 / C# components
- Install [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Install [SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16#download-ssms)
- To initialize the database, run the following:

```
dotnet tool install --global dotnet-ef
dotnet ef migrations add Initial
```

- To run the last db migration, use:
```
dotnet ef database update
```

- Run locally, via the following at the command line:

```
dotnet watch
```

### Notes

Right now the Architecture is setup so that the ViewModels represent the data exposed to the front-end, while the Models represent what's available in the database tables. Use-cases outside of basic CRUD operations between the two types would be custom endpoints.

