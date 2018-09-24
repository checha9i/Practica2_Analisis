using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.Utils.DTO;
using PetShop.Models;
using System.Net.Mail;


namespace PetShop.Controllers
{
    public class UsuarioController : Controller
    {
        bd_dogeEntitiesSqlServer bd_doge = new bd_dogeEntitiesSqlServer();

        [HttpPost]
        public ActionResult RegistrarUsuario(Usuario usu)
        {
            tb_usuario usuario = new tb_usuario();
            usuario.correoUsuario = usu.correoUsuario;
            usuario.claveUsuario = usu.claveUsuario;
            usuario.nombresUsuario = usu.nombresUsuario;
            usuario.apePatUsuario = usu.apePatUsuario;
            usuario.apeMatUsuario = usu.apeMatUsuario;
            usuario.dniUsuario = usu.dniUsuario;
            usuario.fecNacimientoUsuario = usu.fecNacimientoUsuario;
            usuario.telefonoUsuario = usu.telefonoUsuario;
            usuario.celularUsuario = usu.celularUsuario;
            usuario.idRol = 1;

            bd_doge.registrarUsuario(usuario.correoUsuario,usuario.claveUsuario,usuario.nombresUsuario,usuario.apePatUsuario,usuario.apeMatUsuario,
                                usuario.dniUsuario,usuario.fecNacimientoUsuario,usuario.telefonoUsuario,usuario.celularUsuario,usuario.idRol);
            bd_doge.SaveChanges();

            Correo correo = new Correo();
//            correo.to = new string[]{"renzodelgadoguerra@gmail.com","ric.qgv@gmail.com","felixapaza19@gmail.com","cvargasnavarrete@gmail.com"};
            
            correo.to = new string[] { usuario.correoUsuario };
            correo.subject = "Correo de confirmación de cuenta (PRUEBA)";
            correo.isHtml = true;
            correo.body = "Sr. "+usuario.nombresUsuario +" debe confirmar su correo electrónico, para ello debe hacer click en el siguiente link: <br/> <a>link :D</a>";
            try
            {
            enviarCorreo(correo);
            }
            catch (Exception e)
            {

            }
            Session["mensaje"] = "Sr. " + usuario.nombresUsuario +" " + usuario.apePatUsuario + ", se ha enviado un e-mail de confirmación a su cuenta de correo";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult loginUsuario(Usuario usu)
        {
            var varUsu = from u in bd_doge.tb_usuario
                             where u.correoUsuario == usu.correoUsuario
                             select new Usuario {
                             idUsuario = u.idUsuario,
                             correoUsuario = u.correoUsuario,
                             nombresUsuario = u.nombresUsuario,
                             apePatUsuario = u.apePatUsuario,
                             apeMatUsuario = u.apeMatUsuario,
                             dniUsuario = u.dniUsuario,
                             idRol = u.idRol,
                             verificadoUsuario = u.verificadoUsuario,
                             estadoUsuario = u.estadoUsuario
                             };

            Usuario usuario = (Usuario)varUsu.FirstOrDefault();
            if (usuario == null)
            {
                Session["mensaje"] = "Correo o contraseña incorrectos, intente nuevamente";
            }
            else
            {
                Session["usuario"] = usuario;
                Session["carro"] = new List<Producto>();
                Session["mensaje"] = "Bienvenido, " + usuario.nombresUsuario;
            }
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult logouUsuario()
        {
            Session["usuario"] = null;
            Session["carro"] = null;
            return RedirectToAction("Index", "Home");
        }

        public void enviarCorreo(Correo correo) 
        {
            MailMessage mail = new MailMessage();
            foreach (string to in correo.to) {
                mail.To.Add(to);
            }

            mail.From = new MailAddress("doge.dew@gmail.com");
            mail.Subject = correo.subject;
            mail.Body = correo.body; 
            mail.IsBodyHtml = correo.isHtml;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("doge.dew@gmail.com", "damaso2014");// Enter seders User name and password
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

    }
}
