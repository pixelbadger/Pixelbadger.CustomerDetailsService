# Pixelbadger.CustomerDetailsService

## External Dependencies

Requires ef tools to perform database migrations.

```powershell
dotnet tool install --global dotnet-ef
```

## Getting started

Create the database:

```powershell
cd Pixelbadger.CustomerDetailsService.Api
dotnet ef database update --project ..\Pixelbadger.CustomerDetailsService.Core\Pixelbadger.CustomerDetailsService.Core.csproj
```

Run the API service:

```powershell
dotnet run
```

Browse to the /swagger endpoint to view API documentation