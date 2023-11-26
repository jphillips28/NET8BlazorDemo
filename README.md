# My .NET 8 Blazor Web App Test Drive
Taking the new .NET 8 release for a test drive with a Blazor Web App.

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
- I'm simulating a long running SQL Server 2022 transaction in each of the CRUD operations within the Server's implementation of the `IMovieService`
![alt text](https://github.com/jphillips28/NET8BlazorDemo/blob/master/README_image_01.png?raw=true)