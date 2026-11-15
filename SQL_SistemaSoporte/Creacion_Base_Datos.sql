
CREATE DATABASE SistemaSoporte;
GO

USE SistemaSoporte;
GO

-- Tabla de Usuarios
CREATE TABLE Usuarios
(
    UsuarioID INT PRIMARY KEY,
    Nombre VARCHAR(60) NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL
);
GO

-- Tabla de Equipos
CREATE TABLE Equipos
(
    EquipoID INT PRIMARY KEY,
    TipoEquipo VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    UsuarioID INT,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);
GO

-- Comprobar las tablas
SELECT * FROM Usuarios;
SELECT * FROM Equipos;
GO