using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nomProducto { get; set; }
        public string descProducto{ get; set; }
        public double precioProducto{ get; set; }
        public int stockProducto{ get; set; }
        public int idCategoria{ get; set; }
        public bool estadoProducto{ get; set; }

        public int cantidad { get; set; }
    }
}