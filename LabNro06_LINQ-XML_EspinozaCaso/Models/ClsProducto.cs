using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LabNro06_LINQ_XML_EspinozaCaso.Models
{
    [Serializable]
    [XmlRoot("productos"), XmlType("productos")]
    public class ClsProducto
    {
        public string codigo { get; set; }
        public string categoria { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public string imagen { get; set; }
        public List<ClsProducto> ListarProducto()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/Productos.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);
            var objProducto = new List<ClsProducto>();
            objProducto = (from col in ds.Tables[0].AsEnumerable()
                           orderby col[1].ToString()
                           select new ClsProducto
                           {
                               codigo = col[0].ToString(),
                               categoria = col[1].ToString(),
                               nombre = col[2].ToString(),
                               marca = col[3].ToString(),
                               descripcion = col[4].ToString(),
                               precio = Convert.ToDouble(col[5].ToString()),
                               stock = Convert.ToInt32(col[6].ToString()),
                               imagen = col[7].ToString()
                           }).ToList();
            return objProducto;
        }
        public List<ClsProducto> ListarProductoX()
        {
            XDocument xmlData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Productos.xml"));
            var objProducto = new List<ClsProducto>();
            objProducto = (from col in xmlData.Descendants("producto")
                           orderby col.Element("nombre").ToString()
                           select new ClsProducto
                           {
                               codigo = col.Element("codigo").Value,
                               nombre = col.Element("nombre").Value,
                               marca = col.Element("marca").Value,
                               descripcion = col.Element("descripcion").Value,
                               precio = Convert.ToDouble(col.Element("precio").Value),
                               stock = Convert.ToInt32(col.Element("stock").Value),
                               imagen = col.Element("imagen").Value
                           }).ToList();
            return objProducto;
        }
        public List<ClsProducto> buscarProducto(string busqueda)
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/Productos.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);
            var objProducto = new List<ClsProducto>();
            objProducto = (from col in ds.Tables[0].AsEnumerable()
                           orderby col[1].ToString()
                           where col[0].ToString().Equals(busqueda) || col[1].ToString().Equals(busqueda)
                           select new ClsProducto
                           {
                               codigo = col[0].ToString(),
                               nombre = col[1].ToString(),
                               marca = col[2].ToString(),
                               descripcion = col[3].ToString(),
                               precio = Convert.ToDouble(col[4].ToString()),
                               stock = Convert.ToInt32(col[5].ToString()),
                               imagen = col[6].ToString()
                           }).ToList();
            return objProducto;
        }
        public List<ClsProducto> buscarProductoX(string busqueda)
        {
            XDocument xmlData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Productos.xml"));
            var objProducto = new List<ClsProducto>();
            objProducto = (from col in xmlData.Descendants("producto")
                           orderby col.Element("nombre").ToString()
                           where col.Element("codigo").ToString().Equals(busqueda) || col.Element("nombre").ToString().Equals(busqueda)
                           select new ClsProducto
                           {
                               codigo = col.Element("codigo").Value,
                               nombre = col.Element("nombre").Value,
                               marca = col.Element("marca").Value,
                               descripcion = col.Element("descripcion").Value,
                               precio = Convert.ToDouble(col.Element("precio").Value),
                               stock = Convert.ToInt32(col.Element("stock").Value),
                               imagen = col.Element("imagen").Value
                           }).ToList();
            return objProducto;
        }

    }
}