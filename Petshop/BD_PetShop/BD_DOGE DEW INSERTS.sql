INSERT INTO tb_rol(descRol) VALUES ('Cliente')
INSERT INTO tb_rol(descRol) VALUES ('Administrador')
GO
SELECT * FROM tb_rol
GO

INSERT INTO tb_categoria(descCategoria) VALUES ('Alimentos')
INSERT INTO tb_categoria(descCategoria) VALUES ('Ropa')
INSERT INTO tb_categoria(descCategoria) VALUES ('Juguetes')
GO
SELECT * FROM tb_categoria
GO

INSERT INTO tb_producto(nomProducto,descProducto,precioproducto,stockProducto,idCategoria)
VALUES ('Abrigo Tartán Blanco y Negro','Este abrigo para perros con estilo es de la gama de "República de mascotas',50,20,2)
INSERT INTO tb_producto(nomProducto,descProducto,precioproducto,stockProducto,idCategoria)
VALUES ('Abrigo para perro Verona','',79.90,15,2)
INSERT INTO tb_producto(nomProducto,descProducto,precioproducto,stockProducto,idCategoria)
VALUES ('Ricocan','pqte de comida para perro x900 gr',7.50,58,1)
INSERT INTO tb_producto(nomProducto,descProducto,precioproducto,stockProducto,idCategoria)
VALUES ('Pollo de latex','Este pollo desplumado está hecho de durable latex.', 15.99 ,4,3)
INSERT INTO tb_producto(nomProducto,descProducto,precioproducto,stockProducto,idCategoria)
VALUES ('Caramelo','no me quites mi caramelo', 3.40 ,100,3)
SELECT * FROM tb_producto
GO

SELECT * FROM tb_usuario
GO

DELETE FROM tb_usuario WHERE idUsuario = 4