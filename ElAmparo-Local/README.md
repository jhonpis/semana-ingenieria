# El Amparo - ejecución local completa

Esta carpeta contiene la aplicación de escritorio con sus cinco formularios y la API local. No utiliza Azure.

## Abrir en Visual Studio

1. Abra `ElAmparo-Local.sln`.
2. En el Explorador de soluciones, haga clic derecho sobre `Escritorio`.
3. Seleccione **Establecer como proyecto de inicio**.
4. Presione F5.
5. `Program.cs` inicia la API local de `API\` y después abre el login.

Desde el login se accede al menú MDI y a:

- Consulta de mascotas.
- Ingreso, actualización y retiro de mascotas.
- Realización y cancelación de adopciones.
- Cierre de sesión y salida.

## Ejecutar sin Visual Studio

Primero compile la solución en configuración Debug. Después ejecute:

`EjecutarTodo.bat`

El archivo inicia IIS Express con la API local, espera a que responda y abre el ejecutable de escritorio con el login. Al cerrar el escritorio, también cierra la API iniciada por el script.

## Base de datos

Ejecute `BaseDatos\ElAmparo.sql` en SQL Server Management Studio. La configuración local usa:

`(localdb)\MSSQLLocalDB`

Base de datos:

`ElAmparo`

Usuarios de prueba:

- `admin / 123` - ADMIN
- `operador / 123` - OPERADOR
- `consulta / 123` - CONSULTA

## API local

La API se ejecuta en:

`http://localhost:59539/`

Endpoints principales:

- `/api/raza`
- `/api/mascota`
- `/api/mascota/buscar/{nombre}`
- `/api/adoptante`
- `/api/adopcion`
- `/api/usuarios/login`

La aplicación web también está disponible en `/`, `/MascotasWeb/Consulta`, `/MascotasWeb/MaestroDetalle` y `/MascotasWeb/Vista`.
