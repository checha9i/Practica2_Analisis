using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShop.Utils.DTO
{
    public class Correo
    {
        public string subject { get; set; }
        public string[] to { get; set; }
        public string from { get; set; }
        public string body { get; set; }
        public Boolean isHtml { get; set; }

    }
}