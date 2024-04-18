using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace aplicacion
{
    public partial class Catalogo : Form
    {
        public Catalogo()
        {
            InitializeComponent();
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            cargar();
        }

        
        private void cargar()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            dataGridViewArticulos.DataSource = articuloNegocio.listar(); 
            ocultarColumnas();
            cargarImagen(articuloNegocio.listar()[0].UrlImagen);
        }

        private void cargarImagen(string UrlImagen) 
        {
            try
            {
                pictureBoxArticulos.Load(UrlImagen);
            }
            catch (Exception)
            {

                pictureBoxArticulos.Load("https://static.vecteezy.com/system/resources/previews/005/337/799/original/icon-image-not-found-free-vector.jpg");
            }
        }
        
        private void ocultarColumnas() 
        {
            dataGridViewArticulos.Columns["UrlImagen"].Visible = false;
            dataGridViewArticulos.Columns["Id"].Visible = false;
        }

        private void dataGridViewArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Articulo articuloSeleccionado = (Articulo)dataGridViewArticulos.CurrentRow.DataBoundItem;
            cargarImagen(articuloSeleccionado.UrlImagen);
        }
    }
}
