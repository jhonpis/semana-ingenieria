# El Amparo - ejecución local completa

Esta carpeta contiene la API local, el modelo de base de datos y el script para ejecutarla. El proyecto de escritorio único está en la raíz del repositorio.

## Abrir en Visual Studio

1. Abra `ElAmparo-Local.sln` para cargar el escritorio, la API y el conector en una sola solución, o `..\el amparo.sln` para cargar solamente el escritorio.
2. Seleccione `el amparo` como proyecto de inicio y presione F5.
3. El selector permite elegir **Aplicación de escritorio** o **API en el navegador**. La API solo inicia si se selecciona esa opción.

Desde el login se accede al menú MDI y a:

- Consulta de mascotas.
- Ingreso, actualización y retiro de mascotas.
- Realización y cancelación de adopciones.
- Cierre de sesión y salida.

## Ejecutar sin Visual Studio

Primero compile `..\el amparo.sln` en configuración Debug. Después ejecute `EjecutarTodo.bat` para abrir el selector del escritorio, o `IniciarApi.bat` para iniciar solo la API.

## Base de datos

Ejecute `BaseDatos\ElAmparo.sql` en SQL Server Management Studio. La configuración local usa `localhost` con autenticación integrada de Windows.

Base de datos:

`ElAmparo`

Usuarios de prueba:

- `admin / 123` - ADMIN
- `operador / 123` - OPERADOR
- `consulta / 123` - CONSULTA

## API local

La API se inicia con `IniciarApi.bat` y abre en el navegador:

`http://localhost:59539/`

Endpoints principales:

- `/api/raza`
- `/api/mascota`
- `/api/mascota/buscar/{nombre}`
- `/api/adoptante`
- `/api/adopcion`
- `/api/usuarios/login`

La aplicación web también está disponible en `/`, `/MascotasWeb/Consulta`, `/MascotasWeb/MaestroDetalle` y `/MascotasWeb/Vista`.
