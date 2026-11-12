# API independiente de El Amparo

Esta carpeta contiene todo lo necesario para abrir y ejecutar la API de El Amparo desde otra instancia de Visual Studio.

## Contenido

- `API-Standalone.sln`: solución de Visual Studio.
- `API\API.csproj`: API ASP.NET Web API y aplicación web MVC.
- `Conector\Conector.csproj`: modelo Entity Framework 6 y conexión con la base de datos.
- `packages`: paquetes NuGet necesarios para compilar.
- `BaseDatos\ElAmparo.sql`: creación de la base de datos, datos iniciales y vista SQL.
- `IniciarApi.bat`: inicia la API sin Visual Studio.
- `IniciarApi.ps1`: script PowerShell utilizado por el archivo BAT.

## Preparación

1. Ejecute `BaseDatos\ElAmparo.sql` en SQL Server Management Studio.
2. Verifique que existe la base `ElAmparo` en `(localdb)\MSSQLLocalDB`.
3. Abra `API-Standalone.sln` con Visual Studio 2022/2026.
4. Restaure los paquetes NuGet si Visual Studio lo solicita.
5. Establezca `API` como proyecto de inicio.
6. Presione F5 para ejecutar la web desde Visual Studio.

## Ejecución sin Visual Studio

Haga doble clic en `IniciarApi.bat`. La API quedará disponible en:

`http://localhost:59539/`

Para detenerla, presione `Ctrl+C` en la ventana de PowerShell.

## Endpoints

- `GET /api/raza`
- `GET /api/raza/{id}`
- `POST`, `PUT` y `DELETE /api/raza`
- `GET /api/mascota`
- `GET /api/mascota/{id}`
- `GET /api/mascota/buscar/{nombre}`
- `POST`, `PUT` y `DELETE /api/mascota`
- `GET /api/adoptante`
- `GET /api/adoptante/{id}`
- `POST`, `PUT` y `DELETE /api/adoptante`
- `GET /api/adopcion`
- `GET /api/adopcion/{id}`
- `POST`, `PUT` y `DELETE /api/adopcion`
- `POST /api/usuarios/login`

La aplicación web incluye también:

- `/MascotasWeb/Consulta`
- `/MascotasWeb/MaestroDetalle`
- `/MascotasWeb/Vista`
