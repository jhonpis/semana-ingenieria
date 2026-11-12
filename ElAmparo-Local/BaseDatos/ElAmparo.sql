IF DB_ID('ElAmparo') IS NULL
	CREATE DATABASE ElAmparo;
GO

USE ElAmparo;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
GO

IF OBJECT_ID('dbo.RAZA', 'U') IS NULL
BEGIN
	CREATE TABLE RAZA
	(
		codigo INT IDENTITY(1,1) PRIMARY KEY,
		nombre NVARCHAR(50) NOT NULL,
		descripcion NVARCHAR(200)
	);
END;
GO

IF OBJECT_ID('dbo.MASCOTA', 'U') IS NULL
BEGIN
	CREATE TABLE MASCOTA
	(
		id INT IDENTITY(1,1) PRIMARY KEY,
		nombre NVARCHAR(80) NOT NULL,
		codigo_raza INT NOT NULL,
		estado NVARCHAR(20) NOT NULL DEFAULT 'Disponible',
		fecha_ingreso DATE NOT NULL DEFAULT GETDATE(),
		descripcion NVARCHAR(300),
		CONSTRAINT FK_MASCOTA_RAZA FOREIGN KEY (codigo_raza) REFERENCES RAZA(codigo),
		CONSTRAINT CK_MASCOTA_ESTADO CHECK (estado IN ('Disponible', 'Adoptada', 'Retirada'))
	);
END;
GO

IF OBJECT_ID('dbo.ADOPTANTE', 'U') IS NULL
BEGIN
	CREATE TABLE ADOPTANTE
	(
		id INT IDENTITY(1,1) PRIMARY KEY,
		nombre NVARCHAR(100) NOT NULL,
		documento NVARCHAR(30) NOT NULL UNIQUE,
		telefono NVARCHAR(30) NOT NULL,
		correo NVARCHAR(100)
	);
END;
GO

IF OBJECT_ID('dbo.ADOPCION', 'U') IS NULL
BEGIN
	CREATE TABLE ADOPCION
	(
		id INT IDENTITY(1,1) PRIMARY KEY,
		id_mascota INT NOT NULL,
		id_adoptante INT NOT NULL,
		fecha DATE NOT NULL DEFAULT GETDATE(),
		estado NVARCHAR(20) NOT NULL DEFAULT 'Vigente',
		CONSTRAINT FK_ADOPCION_MASCOTA FOREIGN KEY (id_mascota) REFERENCES MASCOTA(id),
		CONSTRAINT FK_ADOPCION_ADOPTANTE FOREIGN KEY (id_adoptante) REFERENCES ADOPTANTE(id),
		CONSTRAINT CK_ADOPCION_ESTADO CHECK (estado IN ('Vigente', 'Cancelada'))
	);
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_ADOPCION_MASCOTA_VIGENTE' AND object_id = OBJECT_ID('dbo.ADOPCION'))
BEGIN
	CREATE UNIQUE INDEX UX_ADOPCION_MASCOTA_VIGENTE
	ON ADOPCION(id_mascota)
	WHERE estado = 'Vigente';
END;
GO

IF OBJECT_ID('dbo.USUARIOS', 'U') IS NULL
BEGIN
	CREATE TABLE USUARIOS
	(
		usuario NVARCHAR(30) PRIMARY KEY,
		clave NVARCHAR(30) NOT NULL,
		rol NVARCHAR(20) NOT NULL,
		CONSTRAINT CK_USUARIOS_ROL CHECK (rol IN ('ADMIN', 'OPERADOR', 'CONSULTA'))
	);
END;
GO

IF NOT EXISTS (SELECT 1 FROM RAZA)
BEGIN
	INSERT INTO RAZA (nombre, descripcion)
	VALUES ('Criolla', 'Mascota mestiza'),
		   ('Labrador', 'Raza mediana o grande'),
		   ('Siames', 'Raza de gato');
END;
GO

IF NOT EXISTS (SELECT 1 FROM MASCOTA)
BEGIN
	INSERT INTO MASCOTA (nombre, codigo_raza, estado, fecha_ingreso, descripcion)
	VALUES ('Luna', 1, 'Disponible', GETDATE(), 'Hembra, adulta'),
		   ('Max', 2, 'Disponible', GETDATE(), 'Macho, joven'),
		   ('Michi', 3, 'Disponible', GETDATE(), 'Gato adulto');
END;
GO

IF NOT EXISTS (SELECT 1 FROM USUARIOS WHERE usuario = 'admin')
	INSERT INTO USUARIOS (usuario, clave, rol) VALUES ('admin', '123', 'ADMIN');
IF NOT EXISTS (SELECT 1 FROM USUARIOS WHERE usuario = 'operador')
	INSERT INTO USUARIOS (usuario, clave, rol) VALUES ('operador', '123', 'OPERADOR');
IF NOT EXISTS (SELECT 1 FROM USUARIOS WHERE usuario = 'consulta')
	INSERT INTO USUARIOS (usuario, clave, rol) VALUES ('consulta', '123', 'CONSULTA');
GO

EXEC('CREATE OR ALTER VIEW dbo.vw_MascotasAdopcion AS
SELECT M.id, M.nombre, R.nombre AS raza, M.estado,
	   ISNULL(A.nombre, '''') AS adoptante
FROM dbo.MASCOTA M
INNER JOIN dbo.RAZA R ON M.codigo_raza = R.codigo
LEFT JOIN dbo.ADOPCION D ON M.id = D.id_mascota AND D.estado = ''Vigente''
LEFT JOIN dbo.ADOPTANTE A ON D.id_adoptante = A.id');
GO