using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;


namespace aplicacion
{
    public partial class ArticuloBox : UserControl
    {
        private Helper helper = new Helper();

        private Articulo articulo;
        
        public ArticuloBox()
        {
            InitializeComponent();
        }

        public ArticuloBox(Articulo aCargar)
        {
            InitializeComponent();
            articulo = aCargar;
            helper.cargarImagen(pbArticulo, articulo.RutaImagen);
            lblNombre.Text = articulo.Nombre;
            lblMarca.Text = articulo.Marca.Descripcion;
            lblPrecio.Text = "$" + articulo.Precio.ToString("N2");
        }
      
        private void btnMasDetalles_Click(object sender, EventArgs e)
        {
            frmInformacion formulario = new frmInformacion(articulo);

            formulario.ShowDialog();
            

        }
    }
}
