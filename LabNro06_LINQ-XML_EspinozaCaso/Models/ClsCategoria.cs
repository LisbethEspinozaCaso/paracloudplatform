using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LabNro06_LINQ_XML_EspinozaCaso.Models
{
    [Serializable]
    [XmlRoot("categoria"), XmlType("categoria")]
    public class ClsCategoria
    {
        public string codigo { get; set; }
        public string nombre { get; set; }

        public List<ClsProducto> ListarCategoria()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/Categoria.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);
            var objProducto{  } = new List<ClsProducto>();
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

        public List<ClsCategoria> ListarCategoriaX()
        {
            XDocument xmlData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Categorias.xml"));
            var objCategoria = new List<ClsCategoria>();
            objCategoria = (from col in xmlData.Descendants("categoria")
                           orderby col.Element("nombre").ToString()
                           select new ClsCategoria
                           {
                               codigo = col.Element("codigo").Value,
                               nombre = col.Element("nombre").Value
                           }).ToList();
            return objCategoria;
        }

        public List<ClsCategoria> buscarCategoriaX(string busqueda)
        {
            XDocument xmlData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Categorias.xml"));
            var objCategoria = new List<ClsCategoria>();
            objCategoria= (from col in xmlData.Descendants("categoria")
                           orderby col.Element("nombre").ToString()
                           where col.Element("codigo").ToString().Equals(busqueda) || col.Element("nombre").ToString().Equals(busqueda)
                           select new ClsCategoria
                           {
                               codigo = col.Element("codigo").Value,
                               nombre = col.Element("nombre").Value
                           }).ToList();
            return objCategoria;
        }
    }
}