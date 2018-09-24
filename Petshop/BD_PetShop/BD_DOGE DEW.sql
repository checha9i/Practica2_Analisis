USE master
GO
DROP DATABASE bd_doge
GO
CREATE DATABASE bd_doge
GO
USE bd_doge
GO
SET dateformat ymd
GO


CREATE TABLE tb_rol(
idRol INT IDENTITY(1,1) NOT NULL,
descRol VARCHAR(60) NOT NULL,
estadoRol BIT NOT NULL DEFAULT 1,
CONSTRAINT pk_tb_rol PRIMARY KEY (idRol)
)
GO

CREATE TABLE tb_usuario(
idUsuario INT IDENTITY(1,1) NOT NULL,
correoUsuario VARCHAR(100) NOT NULL UNIQUE,
claveUsuario VARCHAR(20) NOT NULL,
nombresUsuario VARCHAR(50) NOT NULL,
apePatUsuario VARCHAR(50) NOT NULL,
apeMatUsuario VARCHAR(50) NOT NULL,
dniUsuario VARCHAR(8) NOT NULL UNIQUE,
fecNacimientoUsuario DATE NOT NULL,
telefonoUsuario VARCHAR(9) NULL,
celularUsuario VARCHAR(11) NULL,
idRol INT NOT NULL,
verificadoUsuario BIT NOT NULL DEFAULT 0,
estadoUsuario BIT NOT NULL DEFAULT 1,
CONSTRAINT pk_tb_usuario PRIMARY KEY (idUsuario),
CONSTRAINT fk_tb_usuario_tb_rol FOREIGN KEY (idRol) REFERENCES tb_rol(idRol)
)
GO

CREATE TABLE tb_categoria(
idCategoria INT IDENTITY(1,1),
descCategoria VARCHAR(60) NOT NULL,
estadoCategoria BIT NOT NULL DEFAULT 1,
CONSTRAINT pk_tb_categoria PRIMARY KEY (idCategoria)
)
GO

CREATE TABLE tb_producto(
idProducto INT IDENTITY(1,1) NOT NULL,
nomProducto VARCHAR(60) NOT NULL,
descProducto TEXT NULL,
precioProducto DECIMAL(16,3) NOT NULL,
stockProducto INT NOT NULL,
idCategoria INT NOT NULL,
estadoProducto BIT NOT NULL DEFAULT 1,
CONSTRAINT pk_tb_producto PRIMARY KEY (idProducto),
CONSTRAINT fk_tb_producto_tb_categoria FOREIGN KEY (idCategoria) REFERENCES tb_categoria(idCategoria)
)
GO

CREATE TABLE tb_venta(
idVenta INT IDENTITY(1,1) NOT NULL,
idUsuario INT NOT NULL,
fechaVenta DATETIME NOT NULL,
estadoVenta BIT NOT NULL DEFAULT 1,
CONSTRAINT pk_tb_venta PRIMARY KEY (idVenta),
CONSTRAINT fk_tb_producto_tb_usuario FOREIGN KEY (idUsuario) REFERENCES tb_usuario(idUsuario)
)
GO

CREATE TABLE tb_ventaxproducto(
idVenta INT NOT NULL,
idProducto INT NOT NULL,
cantidad INT NOT NULL,
precio DECIMAL(6,2) NOT NULL,
subtotal DECIMAL(6,2) NOT NULL,
estadoVentaxProd BIT NOT NULL DEFAULT 1
CONSTRAINT pk_tb_ventaxproducto PRIMARY KEY (idVenta,idProducto),
CONSTRAINT fk_tb_ventaxproducto_tb_venta FOREIGN KEY (idVenta) REFERENCES tb_venta(idVenta),
CONSTRAINT fk_tb_ventaxproducto_tb_producto FOREIGN KEY (idProducto) REFERENCES tb_producto(idProducto)
)
GO