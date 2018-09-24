using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShop;

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
            Assert.IsNotNull(Tabla);
        }

        [TestMethod]
        public void Modelo_Usuario()
        {
            var Tabla = new PetShop.tb_usuario();
            Assert.IsNotNull(Tabla);
        }

        [TestMethod]
        public void Modelo_Rol()
        {
            var Tabla = new PetShop.tb_rol();
            Assert.IsNotNull(Tabla);
        }

        [TestMethod]
        public void Modelo_Producto()
        {
            var Tabla = new PetShop.tb_producto();
            Assert.IsNotNull(Tabla);
        }

        [TestMethod]
        public void Modelo_Categoria()
        {
            var Tabla = new PetShop.tb_categoria();
            Assert.IsNotNull(Tabla);
        }

        //Se comenzara a probar el controlador de usuario
        [TestMethod]
        public void Login_UsuarioInexistente()
        {
            var ControladorUSuario = new PetShop.Controllers.UsuarioController();
            PetShop.Models.Usuario usuario = new PetShop.Models.Usuario();
            usuario.correoUsuario = "gerson@epicgames.com";
            var login = ControladorUSuario.loginUsuario(usuario);
            Assert.AreNotEqual(login, null);
        }

        [TestMethod]
        public void Login_UsuarioValido()
        {
            var ControladorUSuario = new PetShop.Controllers.UsuarioController();
            PetShop.Models.Usuario usuario = new PetShop.Models.Usuario();
            var login = ControladorUSuario.loginUsuario(usuario);
            Assert.IsNotNull(login);
        }
    }
}
