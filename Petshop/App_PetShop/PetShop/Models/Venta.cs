using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Venta
    {
        public int idVenta { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaVenta {get; set;}
        public Boolean estadoVenta { get; set; }


        public double totalventa { get; set; }

    }
}