# My .NET 8 Blazor Web App Test Drive w/ EFCore.SqlServer CRUD Operations
I'm taking the new .NET 8 release for a test drive with the new Blazor Web App template. If your system is configured to meet the prerequisites and you flip the 3 configurations mentioned appropriately, then you should be able to simply Start Debugging this project from Visual Studio. It should startup two Linux containers in docker. One for the .NET 8 Blazor Web App and one for the SQL Server 2022 database dependency.

### Future Bonus:
The `docker-compose.yml` is a good template for quickly standing up a locally containerized sand-box environment for development.

## Prerequisites
- Visual Studio Community 2022 v17.8.1
  - ***You should set the `Startup Project` as the `docker-compose` project***
- WSL v2.0.9.0
- Ubuntu 22.04.3 LTS
- Docker Desktop v4.25.2
  - ***You must create a docker-desktop-data `volume` named `mssql-server-2022`***
  - ***You should configure the `Resources: WSL integration` to use the `Ubuntu 22.04` distro***
- Azure Data Studio v1.47.0 (*optional*)
- PowerShell 7.4.0 (*optional*)

## Testing Notes
1. I'm simulating a long running database transaction in each of the CRUD operations for the `IMovieService`
  - This helps demonstrate the snappy `StreamRendering` and *follow-up* data load
![alt text](https://github.com/jphillips28/NET8BlazorDemo/blob/master/README_image_01.png?raw=true)
