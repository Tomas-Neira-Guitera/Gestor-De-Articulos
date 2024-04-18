using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> listaDeMarcas = new List<Marca>();
            AccesoADatos accesoADatos = new AccesoADatos();

            try
            {
                accesoADatos.asignarConsulta("SELECT Id, Descripcion FROM marcas");
                accesoADatos.ejecutarLectura();
                while (accesoADatos.Lector.Read())
                {
                    Marca nuevaMarca = new Marca();

                    nuevaMarca.Id = (int)accesoADatos.Lector["Id"];
                    nuevaMarca.Descripcion = (string)accesoADatos.Lector["Descripcion"];

                    listaDeMarcas.Add(nuevaMarca);
                }
                return listaDeMarcas;
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
