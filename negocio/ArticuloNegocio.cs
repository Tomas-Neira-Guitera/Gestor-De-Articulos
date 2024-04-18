using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {

        private AccesoADatos accesoADatos = new AccesoADatos();
        public List<Articulo> listar()
        {
            List<Articulo> listaDeArticulos = new List<Articulo>();

            try
            {
                accesoADatos.asignarConsulta("select A.Id, codigo, nombre, A.Descripcion , M.Descripcion Marca, M.Id IdMarca, C.Descripcion Categoria, C.Id IdCategoria, ImagenUrl, Precio from ARTICULOS A join MARCAS M on A.IdMarca = M.Id join CATEGORIAS C on A.IdCategoria = C.Id");
                accesoADatos.ejecutarLectura();
                while (accesoADatos.Lector.Read())
                {
                    Articulo nuevoArticulo = new Articulo();
                    Marca marcaDelArticulo = new Marca();
                    Categoria categoriaDelArticulo = new Categoria();

                    nuevoArticulo.Id = (int)accesoADatos.Lector["Id"];
                    nuevoArticulo.Codigo = (string)accesoADatos.Lector["codigo"];
                    nuevoArticulo.Nombre = (string)accesoADatos.Lector["nombre"];
                    nuevoArticulo.Descripcion = (string)accesoADatos.Lector["Descripcion"];
                    nuevoArticulo.Marca = marcaDelArticulo;
                    nuevoArticulo.Marca.Id = (int)accesoADatos.Lector["IdMarca"];
                    nuevoArticulo.Marca.Descripcion = (string)accesoADatos.Lector["Marca"];
                    nuevoArticulo.Categoria = categoriaDelArticulo;
                    nuevoArticulo.Categoria.Id = (int)accesoADatos.Lector["IdCategoria"];
                    nuevoArticulo.Categoria.Descripcion = (string)accesoADatos.Lector["Categoria"];
                    string direccionImagenDB = (string)accesoADatos.Lector["ImagenUrl"];
                    nuevoArticulo.cargarImagen(direccionImagenDB); 
                    nuevoArticulo.Precio = (decimal)accesoADatos.Lector["Precio"];

                    listaDeArticulos.Add(nuevoArticulo);
                }
                return listaDeArticulos;
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

        public void agregar(Articulo articuloAgregar)
        {
            try
            {
                accesoADatos.asignarConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria,ImagenUrl, Precio) VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio);");
                
                accesoADatos.setearParametro("@codigo", articuloAgregar.Codigo);
                accesoADatos.setearParametro("@nombre", articuloAgregar.Nombre);
                accesoADatos.setearParametro("@descripcion", articuloAgregar.Descripcion);
                accesoADatos.setearParametro("@idMarca", articuloAgregar.Marca.Id);
                accesoADatos.setearParametro("@idCategoria", articuloAgregar.Categoria.Id);
                accesoADatos.setearParametro("@imagenUrl", articuloAgregar.RutaImagen);
                accesoADatos.setearParametro("@precio", articuloAgregar.Precio);

                accesoADatos.ejecutarAccion();

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

        public void modificar(Articulo articuloModificar)
        {
            try
            {
                accesoADatos.asignarConsulta("update Articulos set codigo = @codigo, nombre = @nombre, descripcion = @descripcion, idMarca = @idMarca, idCategoria = @idCategoria, imagenUrl = @imagenUrl, precio = @precio where id = @id");

                accesoADatos.setearParametro("@codigo", articuloModificar.Codigo);
                accesoADatos.setearParametro("@nombre", articuloModificar.Nombre);
                accesoADatos.setearParametro("@descripcion", articuloModificar.Descripcion);
                accesoADatos.setearParametro("@idMarca", articuloModificar.Marca.Id);
                accesoADatos.setearParametro("@idCategoria", articuloModificar.Categoria.Id);
                accesoADatos.setearParametro("@imagenUrl", articuloModificar.RutaImagen);
                accesoADatos.setearParametro("@precio", articuloModificar.Precio);
                accesoADatos.setearParametro("@id", articuloModificar.Id);

                accesoADatos.ejecutarAccion();
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
