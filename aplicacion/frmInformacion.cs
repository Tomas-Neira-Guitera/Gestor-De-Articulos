using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;

namespace aplicacion
{
    public partial class frmInformacion : Form
    {
        private Helper helper = new Helper();

        private Articulo articuloAModificar = null;

        private ArticuloNegocio articuloNegocio = new ArticuloNegocio();

        public frmInformacion()
        {
            InitializeComponent();
            btnAgregarImagen.Visible = true;
            btnAgregar.Visible = true;
            habilitarTxtbox();
            cargarCb();
        }

        private void habilitarTxtbox()
        {
            txtNombre.ReadOnly = false;
            txtPrecio.ReadOnly = false;
            txtCodigo.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            txtImagen.ReadOnly = false;
        }

        private void deshabilitarTxtbox()
        {
            txtNombre.ReadOnly = true;
            txtPrecio.ReadOnly = true;
            txtCodigo.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            txtImagen.ReadOnly = true;
        }

        private void cargarCb()
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();  
            cbCategoria.DataSource = categoriaNegocio.listar();

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            cbMarca.DataSource = marcaNegocio.listar();
        }


        public frmInformacion(Articulo articulo)
        {
            InitializeComponent();
            btnEliminar.Visible = true;
            btnAgregar.Visible = true;
            btnEditar.Visible = true;
            btnAgregar.Text = "Aceptar";
            cargarParaModificar(articulo);
            articuloAModificar = articulo;
        }

        private void cargarParaModificar(Articulo articulo)
        {
            txtNombre.Text = articulo.Nombre;
            txtPrecio.Text = articulo.Precio.ToString("N2");
            txtCodigo.Text = articulo.Codigo;
            txtDescripcion.Text = articulo.Descripcion;
            helper.cargarImagen(pbArticulo, articulo.RutaImagen);
            txtImagen.Text = articulo.RutaImagen;

            cbCategoria.DataSource = null;
            cbMarca.DataSource = null;
 
            cbCategoria.Items.Add(articulo.Categoria);
            cbCategoria.SelectedIndex = 0;
            cbMarca.Items.Add(articulo.Marca);
            cbMarca.SelectedIndex = 0;
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog exploradorArchivos = new OpenFileDialog();
            exploradorArchivos.Filter = "Archivos de imagen|*.png;*.jpg|Todos los archivos|*.*";
            exploradorArchivos.Multiselect = false;

            if (exploradorArchivos.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = exploradorArchivos.FileName;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(articuloAModificar == null)
            {
                articuloAModificar = new Articulo();
            }

            articuloAModificar.Nombre = txtNombre.Text;
            articuloAModificar.Precio = Convert.ToDecimal(txtPrecio.Text);
            articuloAModificar.Categoria = (Categoria)cbCategoria.SelectedItem;
            articuloAModificar.Marca = (Marca)cbMarca.SelectedItem;
            articuloAModificar.Descripcion = txtDescripcion.Text;
            articuloAModificar.Codigo = txtCodigo.Text;
            articuloAModificar.RutaImagen = txtImagen.Text;

            if(articuloAModificar.Id != 0)
            {
                articuloNegocio.modificar(articuloAModificar);
                MessageBox.Show("Se modificó exitosamente");
            }
            else
            {
                articuloNegocio.agregar(articuloAModificar);
                MessageBox.Show("Se agregó exitosamente");
            }
            Close();

        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if(txtNombre.ReadOnly)
            {
                habilitarTxtbox();
                cargarCb();
                //falta hacer que cuando le des a editar en los combo box se carge lo del artituclo actual
                btnEditar.BackgroundImage = Properties.Resources._4;
                btnAgregarImagen.Visible = true;
            }
            else
            {
                cargarParaModificar(articuloAModificar);
                deshabilitarTxtbox();
                btnEditar.BackgroundImage = Properties.Resources.imgEditar2;
                btnAgregarImagen.Visible = false;
            }
        }
    }
}