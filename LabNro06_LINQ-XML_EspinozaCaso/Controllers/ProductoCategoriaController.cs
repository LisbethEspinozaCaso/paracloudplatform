using LabNro06_LINQ_XML_EspinozaCaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabNro06_LINQ_XML_EspinozaCaso.Controllers
{
    public class ProductoCategoriaController : Controller
    {
        // GET: ProductoCategoria
        public ActionResult Index()
        {
            return View();
        }

        //Stock = 0 -> Agotado (color rojo)
        //Stock > 0 y <= 10 -> por Agotar (color azul)
        //Stock >= 11 -> Suficiente (color verde)

        public ActionResult ListarXDocument(ClsCategoria objCategoria)
        {
            //return View(objProducto.ListarProductos2());
            return View();
        }

        public ActionResult BuscarXDocument(string busqueda)
        {
            ClsCategoria objCategoria = new ClsCategoria();
            if (!string.IsNullOrEmpty(busqueda))
            {
               // return View(objProducto.buscarProductoX(busqueda).ToList());
            }
            //return View(objProducto.ListarProductosX().ToList());
            return View();
        }
    }
}