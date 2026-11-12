# El Amparo

Solución de adopción de mascotas para la Sociedad Protectora de Animales El Amparo.

## Componentes

- `el amparo.csproj`: aplicación Windows Forms .NET Framework 4.7.2, con formulario principal MDI.
- `..\ElAmparo\API\API.csproj`: API ASP.NET Web API y aplicación web MVC.
- `..\ElAmparo\Conector\Conector.csproj`: modelo Entity Framework de la base de datos.
- `..\ElAmparo\BaseDatos\ElAmparo.sql`: creación de la base de datos, datos iniciales y vista `vw_MascotasAdopcion`.

## Base de datos local

1. Ejecute `..\ElAmparo\BaseDatos\ElAmparo.sql` en SQL Server Management Studio.
2. La configuración local usa `(localdb)\MSSQLLocalDB` y la base de datos `ElAmparo`.
3. Usuarios de prueba:
   - `admin` / `123` - ADMIN
   - `operador` / `123` - OPERADOR
   - `consulta` / `123` - CONSULTA

## Ejecución

1. Abra `el amparo.sln` en Visual Studio. Esta solución contiene solo el proyecto de escritorio para que F5 inicie el login.
2. Si Visual Studio solicita el proyecto de inicio, seleccione `el amparo` y use **Establecer como proyecto de inicio**.
3. Presione F5. `Program.Main` inicia el escritorio y IIS Express con la API en `http://localhost:59539/` si aún no está ejecutándose.
4. No use `Depurar > Adjuntar al proceso` para iniciar la aplicación; esa ventana solo sirve para depurar procesos ya abiertos.

La solución `ElAmparo-Web.slnx` permite abrir por separado la API, el Conector y las vistas web.

## Ejecutar solamente la API sin Visual Studio

Para dejar la API funcionando como un servicio local independiente:

1. Ejecute `IniciarApi.bat` con doble clic, o ejecute `IniciarApi.ps1` desde PowerShell.
2. El lanzador inicia IIS Express con `C:\jhon\ElAmparo\API` y espera hasta que la página principal responda.
3. Use la API en `http://localhost:59539/` desde Postman, un navegador o cualquier cliente HTTP.
4. Mantenga abierta la ventana del lanzador mientras utilice la API.
5. Presione `Ctrl+C` en esa ventana para detener únicamente la API iniciada por el script.

Endpoints principales:

- `GET /api/raza`, `GET /api/raza/{id}`, `POST`, `PUT` y `DELETE`.
- `GET /api/mascota`, `GET /api/mascota/{id}`, `GET /api/mascota/buscar/{nombre}`, `POST`, `PUT` y `DELETE`.
- `GET /api/adoptante`, `GET /api/adoptante/{id}`, `POST`, `PUT` y `DELETE`.
- `GET /api/adopcion`, `GET /api/adopcion/{id}`, `POST`, `PUT` y `DELETE`.
- `POST /api/usuarios/login` para validar usuario y rol.

Ejemplo de login:

```json
{
  "usuario": "admin",
  "clave": "123"
}
```

La aplicación de escritorio incluye consulta por código/nombre, actualización de mascotas, adopciones, cancelaciones, control de acceso por rol y menú MDI. La aplicación web está disponible en:

- `/`
- `/MascotasWeb/Consulta`
- `/MascotasWeb/MaestroDetalle`
- `/MascotasWeb/Vista`

## Azure

Para publicar la API en Azure App Service:

1. Publique `..\ElAmparo\API\API.csproj` en el App Service.
2. Configure en Azure la cadena `ElAmparoEntities` apuntando a Azure SQL Database.
3. Cambie `ApiBaseUrl` en `App.config` por la URL HTTPS del App Service.
4. Mantenga las credenciales de base de datos en la configuración del App Service, no en el código fuente.
