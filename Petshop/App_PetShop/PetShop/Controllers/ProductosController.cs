using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class ProductosController : Controller
    {
        bd_dogeEntitiesSqlServer bd_doge = new bd_dogeEntitiesSqlServer();

        public ActionResult Alimentos()
        {
            var productos = from p in bd_doge.tb_producto
                            where p.idCategoria == 1
                            select new Producto
                            {
                                idProducto = p.idProducto,
                                nomProducto = p.nomProducto,
                                descProducto = p.descProducto,
                                precioProducto = (double)p.precioProducto,
                                stockProducto = p.stockProducto,
                                idCategoria = p.idCategoria,
                                estadoProducto = p.estadoProducto
                            };

            ViewBag.ocultarCategorias = false;
            ViewBag.productos = productos.ToList();
            return View();
        }

        public ActionResult Ropa()
        {
            var productos = from p in bd_doge.tb_producto
                            where p.idCategoria == 2
                            select new Producto
                            {
                                idProducto = p.idProducto,
                                nomProducto = p.nomProducto,
                                descProducto = p.descProducto,
                                precioProducto = (double) p.precioProducto,
                                stockProducto = p.stockProducto,
                                idCategoria = p.idCategoria,
                                estadoProducto = p.estadoProducto
                            };

            ViewBag.ocultarCategorias = false;
            ViewBag.productos = productos.ToList();
            return View();
        }

        public ActionResult Juguetes()
        {
            var productos = from p in bd_doge.tb_producto
                            where p.idCategoria == 3
                            select new Producto
                            {
                                idProducto = p.idProducto,
                                nomProducto = p.nomProducto,
                                descProducto = p.descProducto,
                                precioProducto = (double)p.precioProducto,
                                stockProducto = p.stockProducto,
                                idCategoria = p.idCategoria,
                                estadoProducto = p.estadoProducto
                            };

            ViewBag.ocultarCategorias = false;
            ViewBag.productos = productos.ToList();
            return View();
        }

        public ActionResult Detalle(int? idprod)
        {
            // categoria: 1=Alimentos;2=Ropa;3=Juguetes
            var producto = from p in bd_doge.tb_producto
                            where p.idProducto == idprod
                            select new Producto
                            {
                                idProducto = p.idProducto,
                                nomProducto = p.nomProducto,
                                descProducto = p.descProducto,
                                precioProducto = (double)p.precioProducto,
                                stockProducto = p.stockProducto,
                                idCategoria = p.idCategoria,
                                estadoProducto = p.estadoProducto
                            };

            Producto prod = (Producto)producto.FirstOrDefault();

            if (prod == null)
            {
                return RedirectToAction("Alimentos","Productos");
            }

            ViewBag.producto = prod;
            ViewBag.ocultarCategorias = false;
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Producto product){

            if (Session["usuario"] == null)
            {
                Session["mensaje"] = "Lo sentimos, para poder comprar debe ingresar al sistema";
                return RedirectToAction("Index","Home");
            }

            List<Producto> carro = (List<Producto>) Session["carro"];

            var producto = from p in bd_doge.tb_producto
                           where p.idProducto == product.idProducto
                            select new Producto
                            {
                                idProducto = p.idProducto,
                                nomProducto = p.nomProducto,
                                descProducto = p.descProducto,
                                precioProducto = (double)p.precioProducto,
                                stockProducto = p.stockProducto,
                                cantidad = product.cantidad,
                                idCategoria = p.idCategoria,
                                estadoProducto = p.estadoProducto
                            };
            Producto prod = (Producto)producto.FirstOrDefault();

            if (prod == null)
            {
                return RedirectToAction("Alimentos", "Productos");
            }

            carro.Add(prod);
            ViewBag.ocultarCategorias = false;

            switch (prod.idCategoria)
            {
                case 1:
                    return RedirectToAction("Alimentos", "Productos");
                case 2:
                    return RedirectToAction("Ropa", "Productos");
                default:
                    return RedirectToAction("Juguetes", "Productos");
            }
        }

        public ActionResult CarroCompras()
        {
            ViewBag.ocultarCategorias = true;
            return View();
        }

        public ActionResult Descartar(int? idprod)
        {
            List<Producto> carro = (List<Producto>)Session["carro"];
            Producto prod = carro.Find(Producto => Producto.idProducto == idprod);
            carro.Remove(prod);
            return RedirectToAction("CarroCompras");
        }

        [HttpPost]
        public ActionResult CalcularTotal(Producto prod)
        {
            List<Producto> carro = (List<Producto>)Session["carro"];
            Producto producto = carro.Find(Producto => Producto.idProducto == prod.idProducto);
            producto.cantidad = prod.cantidad == 0 ? 1 : prod.cantidad;
            return RedirectToAction("CarroCompras");
        }

        public ActionResult RealizarCompra()
        {
            List<Producto> carro = (List<Producto>)Session["carro"];
            Usuario usuario = (Usuario) Session["usuario"];
            bd_doge.registrarVenta(usuario.idUsuario, true);

            int? idVentaGenerada = bd_doge.tb_venta.Max(v => v.idVenta);

            foreach (Producto prod in carro)
            {
                bd_doge.registrarDetalleVenta(idVentaGenerada, prod.idProducto, prod.cantidad, decimal.Parse(prod.precioProducto.ToString()));
            }

            Session["carro"] = new List<Producto>();
            Session["mensaje"] = "Enhorabuena " + usuario.nombresUsuario +", tu compra se ha realizado.";
            return RedirectToAction("CarroCompras");
        }

        public ActionResult MisCompras()
        {
            Usuario usuario = (Usuario) Session["Usuario"];
            var ventas = from v in bd_doge.tb_venta
                         where v.idUsuario == usuario.idUsuario
                         select new Venta
                         {
                             idVenta = v.idVenta,
                             fechaVenta = v.fechaVenta
                         };


            List<Venta> misCompras = (List<Venta>) ventas.ToList();

            foreach (Venta venta in misCompras)
            {
                var productos = from p in bd_doge.tb_producto
                                join vxp in bd_doge.tb_ventaxproducto on p.idProducto equals vxp.idProducto
                                where vxp.idVenta == venta.idVenta
                                select new Producto
                                {
                                    idProducto = p.idProducto,
                                    descProducto = p.descProducto,
                                    nomProducto = p.nomProducto,
                                    precioProducto = (double)p.precioProducto,
                                    cantidad = vxp.cantidad,
                                };
                List<Producto> detalleCompra = productos.ToList();
                venta.totalventa = detalleCompra.Sum(d => (d.cantidad * d.precioProducto));
            }

            ViewBag.ocultarCategorias = true;
            ViewBag.misCompras = misCompras;


            return View();
        }

        [HttpPost]
        public ActionResult DetalleVenta(Venta venta)
        {
            var productos = from p in bd_doge.tb_producto
                            join vxp in bd_doge.tb_ventaxproducto on p.idProducto equals vxp.idProducto
                            where vxp.idVenta == venta.idVenta
                            select new Producto
                            {
                                idProducto=p.idProducto,
                                descProducto =p.descProducto,
                                nomProducto = p.nomProducto,
                                precioProducto = (double)p.precioProducto,
                                cantidad = vxp.cantidad,
                            };

            List<Producto> detalleCompra = productos.ToList();

            ViewBag.detalleCompra = detalleCompra;
            ViewBag.venta = venta;
            ViewBag.ocultarCategorias = true;
            return View();
        }

    }
}
