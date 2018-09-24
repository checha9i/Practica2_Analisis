DROP PROCEDURE registrarVenta
GO
CREATE PROCEDURE registrarVenta(
@idUsuario INT,
@estadoVenta BIT
)
AS
BEGIN
INSERT INTO tb_venta(idUsuario,fechaVenta,estadoVenta)
	VALUES(@idUsuario,GETDATE(),1)
END
GO

DROP PROCEDURE registrarDetalleVenta
GO
CREATE PROCEDURE registrarDetalleVenta(
@idVenta INT,
@idProducto INT,
@cantidad INT,
@precio DECIMAL(6,2)
)
AS
BEGIN
INSERT INTO tb_ventaxproducto(idVenta,idProducto,cantidad,precio,subtotal,estadoVentaxProd)
	VALUES(@idVenta,@idProducto,@cantidad,@precio,@cantidad*@precio,1)

UPDATE tb_producto
SET stockProducto = stockProducto-@cantidad
WHERE idProducto = @idProducto
END
GO

DROP PROCEDURE registrarUsuario
GO
CREATE PROCEDURE registrarUsuario(
@correoUsuario VARCHAR(100),
@claveUsuario VARCHAR(20),
@nombresUsuario VARCHAR(50),
@apePatUsuario VARCHAR(50),
@apeMatUsuario VARCHAR(50),
@dniUsuario VARCHAR(8),
@fecNacimientoUsuario DATE,
@telefonoUsuario VARCHAR(9),
@celularUsuario VARCHAR(11),
@idRol INT
)
AS
BEGIN
	INSERT INTO tb_usuario(correoUsuario,claveUsuario,nombresUsuario,apePatUsuario,
						apeMatUsuario,dniUsuario,fecNacimientoUsuario,telefonoUsuario,
						celularUsuario,idRol)
	VALUES (@correoUsuario,@claveUsuario,@nombresUsuario,@apePatUsuario,
						@apeMatUsuario,@dniUsuario,@fecNacimientoUsuario,@telefonoUsuario,
						@celularUsuario,@idRol)

END

GO

EXEC registrarUsuario
@correoUsuario='renzo@a.com',
@claveUsuario='123',
@nombresUsuario ='Renzo',
@apePatUsuario ='Delgado',
@apeMatUsuario = 'Guerra',
@dniUsuario ='76527633',
@fecNacimientoUsuario = '1995-04-28',
@telefonoUsuario = '013302597',
@celularUsuario = '976558714',
@idRol = 1
GO
select * from tb_usuario
GO