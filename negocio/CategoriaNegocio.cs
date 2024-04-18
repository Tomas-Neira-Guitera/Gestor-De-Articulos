using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> listaDeCategorias = new List<Categoria>();
            AccesoADatos accesoADatos = new AccesoADatos();

            try
            {
                accesoADatos.asignarConsulta("SELECT Id, Descripcion FROM categorias");
                accesoADatos.ejecutarLectura();
                while (accesoADatos.Lector.Read())
                {
                    Categoria nuevaCategoria = new Categoria();

                    nuevaCategoria.Id = (int)accesoADatos.Lector["Id"];
                    nuevaCategoria.Descripcion = (string)accesoADatos.Lector["Descripcion"];

                    listaDeCategorias.Add(nuevaCategoria);
                }
                return listaDeCategorias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }
    }
}
