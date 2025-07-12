-- 1. Verificar si la base de datos existe y crearla si no
IF NOT EXISTS (
    SELECT name FROM sys.databases WHERE name = 'SolicitudesDB'
)
BEGIN
    CREATE DATABASE SolicitudesDB;
END
GO

-- 2. Usar la base de datos
USE SolicitudesAppDB;
GO

-- 3. Verificar si la tabla 'Solicitudes' ya existe y crearla si no
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_NAME = 'Solicitudes' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
    CREATE TABLE Solicitudes (
        Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        Tipo NVARCHAR(MAX) NOT NULL,
        Estado INT NOT NULL, -- Basado en el enum EstadoSolicitud
        FechaCreacion DATETIME2 NOT NULL,
        Datos NVARCHAR(MAX) NOT NULL
    );
END
GO

