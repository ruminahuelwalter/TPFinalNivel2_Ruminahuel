using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO MARCAS (Descripcion) values ('" + nuevo.Descripcion  + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void Modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE MARCAS SET Descripcion = @desc Where Id = @id");
                datos.setearParametro("@desc", marca.Descripcion);
                datos.setearParametro("@id", marca.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                if (!verificarSiHayReferencias(id))
                {
                    datos.setearConsulta("DELETE FROM MARCAS WHERE id = @id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarAccion();
                }
                else
                {
                    throw new Exception("No se puede eliminar la marca porque está referenciada en uno o más artículos.");

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar la marca: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private bool verificarSiHayReferencias(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Verificar si la marca está referenciada en artículos
                datos.setearConsulta("SELECT COUNT(*) FROM ARTICULOS WHERE IdMarca = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                datos.Lector.Read();
                int contador = datos.Lector.GetInt32(0); // Obtiene el primer (y único) valor del lector

                datos.cerrarConexion();

                if (contador > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


    }
}

