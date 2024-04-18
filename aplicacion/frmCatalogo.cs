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
using negocio;

namespace aplicacion
{
    public partial class frmCatalogo : Form
    {
        public frmCatalogo()
        {
            InitializeComponent();
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            
            List<Articulo> listadoArticulos = negocio.listar();

            foreach (Articulo articulo in listadoArticulos)
            {
                ArticuloBox contenedor = new ArticuloBox(articulo);
                flpArticuloBox.Controls.Add(contenedor);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmInformacion formularioAgregar = new frmInformacion();
            
            formularioAgregar.ShowDialog();
        }
    }
}
