using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominio
{
    public class Helper
    {
        public bool esUrl(string direccion)
        {
            string patron = @"^(https?|ftp):\/\/[^\s\/$.?#].[^\s]*$";

            return Regex.IsMatch(direccion, patron);
        }

        public bool esUnaRuta(string direccion)
        {
            return(File.Exists(direccion));
        }

        public void descargarImagenDeUrl(string url, Articulo articulo)
        {
            try
            {
                string nombreArchivo = Path.GetFileName(new Uri(url).LocalPath);
                string directorioBase = AppDomain.CurrentDomain.BaseDirectory;
                string carpetaDestino = Path.Combine(directorioBase, "Imagenes");
                Directory.CreateDirectory(carpetaDestino);
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                if (!File.Exists(rutaCompleta))
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(url, rutaCompleta);
                    }
                }
                articulo.RutaImagen = rutaCompleta;
            }
            catch (Exception)
            {
                articulo.RutaImagen = null;
            }

        }

        public void cargarImagen(PictureBox picturebox, string rutaImagen)
        {
            try
            {
                   picturebox.Load(rutaImagen);
            }
            catch (Exception)
            {
                   picturebox.Image = picturebox.ErrorImage;
            }
        }

    }
}
