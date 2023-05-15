using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabNro06_LINQ_XML_EspinozaCaso.Models;

namespace LabNro06_LINQ_XML_EspinozaCaso.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListarDataSet()
        {
            ClsProducto objProducto = new ClsProducto();
            var data = objProducto.ListarProducto();


            return View(data.ToList());
        }

        public ActionResult ListarXDocument(ClsProducto objProducto)
        {
            return View(objProducto.ListarProductoX());
        }

        public ActionResult BuscarDataSet(string busqueda)
        {
            ClsProducto objProducto = new ClsProducto();
            if (!string.IsNullOrEmpty(busqueda))
            {
                return View(objProducto.buscarProducto(busqueda).ToList());
            }
            return View(objProducto.ListarProducto().ToList());
        }
        public ActionResult BuscarXDocument(string busqueda)
        {
            ClsProducto objProducto = new ClsProducto();
            if (!string.IsNullOrEmpty(busqueda))
            {
                return View(objProducto.buscarProductoX(busqueda).ToList());
            }
            return View(objProducto.ListarProductoX().ToList());
        }
    }
}