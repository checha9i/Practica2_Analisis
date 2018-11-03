using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShop;
using NUnit.Framework;

namespace Pruebas_Unitarias
{
    [TestClass]
    public class UnitTest1
    {
        //Se probaran que los modelos generados sean correctos
        [TestMethod]
        public void Modelo_Venta()
        {
            var Tabla = new PetShop.tb_venta();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(Tabla);
        }

        [TestMethod]
        public void Modelo_Usuario()
        {
            var Tabla = new PetShop.tb_usuario();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(Tabla);
        }

        [TestMethod]
        public void Modelo_Rol()
        {
            var Tabla = new PetShop.tb_rol();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(Tabla);
        }

        [TestMethod]
        public void Modelo_Producto()
        {
            var Tabla = new PetShop.tb_producto();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(Tabla);
        }

        [TestMethod]
        public void Modelo_Categoria()
        {
            var Tabla = new PetShop.tb_categoria();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(Tabla);
        }

        //Se comenzara a probar el controlador de usuario
        [TestMethod]
        public void Login_UsuarioInexistente()
        {
            var ControladorUSuario = new PetShop.Controllers.UsuarioController();
            PetShop.Models.Usuario usuario = new PetShop.Models.Usuario();
            usuario.correoUsuario = "gerson@epicgames.com";
            var login = ControladorUSuario.loginUsuario(usuario);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(login, null);
        }

        [TestMethod]
        public void Login_UsuarioValido()
        {
            var ControladorUSuario = new PetShop.Controllers.UsuarioController();
            PetShop.Models.Usuario usuario = new PetShop.Models.Usuario();
            var login = ControladorUSuario.loginUsuario(usuario);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void Logout()
        {
            var ControladorUSuario = new PetShop.Controllers.UsuarioController();
            PetShop.Models.Usuario usuario = new PetShop.Models.Usuario();
            var login = ControladorUSuario.logouUsuario();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RegistrarUsuario()
        {
            var ControladorUSuario = new PetShop.Controllers.UsuarioController();
            PetShop.Models.Usuario usuario = new PetShop.Models.Usuario();

            usuario.correoUsuario = Guid.NewGuid().ToString("n").Substring(0, 8) + "@gmail.com";
            usuario.claveUsuario = Guid.NewGuid().ToString("n").Substring(0, 8);
            usuario.nombresUsuario = Guid.NewGuid().ToString("n").Substring(0, 8);
            usuario.apeMatUsuario = Guid.NewGuid().ToString("n").Substring(0, 8);
            usuario.apePatUsuario = Guid.NewGuid().ToString("n").Substring(0, 8);
            usuario.dniUsuario = Guid.NewGuid().ToString("n").Substring(0, 8);
            usuario.fecNacimientoUsuario = new DateTime(2018, 2, 2);
            usuario.telefonoUsuario = Guid.NewGuid().ToString("n").Substring(0, 8);
            usuario.celularUsuario = Guid.NewGuid().ToString("n").Substring(0, 8);
            var login = ControladorUSuario.RegistrarUsuario(usuario);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        //Se comenzara a probar el controlador de productos
        [TestMethod]
        public void RevisarAlimentos()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            var login = ControladorProducto.Alimentos();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RevisarRopa()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            var login = ControladorProducto.Ropa();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RevisarJuguetes()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            var login = ControladorProducto.Juguetes();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RevisarDetalle()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            var login = ControladorProducto.Detalle(1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RevisarCarroCompras()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            var login = ControladorProducto.CarroCompras();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RevisarDescartar()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            var login = ControladorProducto.Descartar(1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RevisarDetalleVenta()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            PetShop.Models.Venta Venta = new PetShop.Models.Venta();
            var login = ControladorProducto.DetalleVenta(Venta);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void AgregarProductoCat1()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            PetShop.Models.Producto Producto = new PetShop.Models.Producto();
            Producto.idProducto = 1123;
            Producto.nomProducto = "jaja";
            Producto.precioProducto = 1234.123;
            Producto.stockProducto = 1;
            Producto.idCategoria = 1;
            var login = ControladorProducto.Agregar(Producto);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void AgregarProductoCat2()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            PetShop.Models.Producto Producto = new PetShop.Models.Producto();
            Producto.idProducto = 1253;
            Producto.nomProducto = "jaja";
            Producto.precioProducto = 1234.123;
            Producto.stockProducto = 1;
            Producto.idCategoria = 2;
            var login = ControladorProducto.Agregar(Producto);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void AgregarProductoCat3()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            PetShop.Models.Producto Producto = new PetShop.Models.Producto();
            Producto.idProducto = 1234;
            Producto.nomProducto = "jaja";
            Producto.precioProducto = 1234.123;
            Producto.stockProducto = 1;
            Producto.idCategoria = 3;
            var login = ControladorProducto.Agregar(Producto);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RevisarCalcularTotal()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            PetShop.Models.Producto Producto = new PetShop.Models.Producto();
            Producto.idProducto = 1234;
            Producto.nomProducto = "jaja";
            Producto.precioProducto = 1234.123;
            Producto.stockProducto = 1;
            Producto.idCategoria = 3;
            var login = ControladorProducto.CalcularTotal(Producto);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RevisarHistorial()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            var login = ControladorProducto.MisCompras();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        [TestMethod]
        public void RealizarCompra()
        {
            var ControladorProducto = new PetShop.Controllers.ProductosController();
            var login = ControladorProducto.RealizarCompra();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        //Se comenzara a probar el controlador de home
        [TestMethod]
        public void RetornarIndex()
        {
            var ControladorHome = new PetShop.Controllers.HomeController();
            var login = ControladorHome.Index();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(login);
        }

        //commit sencillo
    }
}
