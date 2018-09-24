using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string correoUsuario { get; set; }
        public string claveUsuario { get; set; }
        public string nombresUsuario { get; set; }
        public string apePatUsuario { get; set; }
        public string apeMatUsuario { get; set; }
        public string dniUsuario { get; set; }
        public DateTime fecNacimientoUsuario { get; set; }
        public string telefonoUsuario { get; set; }
        public string celularUsuario { get; set; }
        public int idRol { get; set; }
        public Rol rol { get; set; }
        public bool verificadoUsuario { get; set; }
        public bool estadoUsuario { get; set; }

        public Usuario()
        {
            idUsuario = 0;
            rol = new Rol();
            verificadoUsuario = false;
            estadoUsuario = false;
        }
    }

}