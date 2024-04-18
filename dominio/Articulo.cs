using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominio
{
    public class Articulo
    {
        private Helper helper = new Helper();
        public int Id { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public string Nombre { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public Marca Marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public string RutaImagen { get; set; }

        public decimal Precio {  get; set; }

        public void cargarImagen(string direccion)
        {
            if (helper.esUrl(direccion))
            {
                helper.descargarImagenDeUrl(direccion, this);
            }
            else if( helper.esUnaRuta(direccion))
            {
                RutaImagen = direccion;
            }
            else
            {
                RutaImagen = null;
            }
        }
    }
}
