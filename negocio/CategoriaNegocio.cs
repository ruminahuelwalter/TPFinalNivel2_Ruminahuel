using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
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

        public void Agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO CATEGORIAS (Descripcion) values ('" + nuevo.Descripcion + "')");
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


        public void Modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE CATEGORIAS SET Descripcion = @desc Where Id = @id");
                datos.setearParametro("@desc", categoria.Descripcion);
                datos.setearParametro("@id", categoria.Id);

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
            try {

                if (!verificarSiHayReferencias(id))
                {
                    datos.setearConsulta("DELETE FROM CATEGORIAS WHERE id = @id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarAccion();
                }
                else
                {
                    throw new Exception("No se puede eliminar la categoría porque está referenciada en uno o más artículos.");
                    
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error al intentar eliminar la categoría: " + ex.Message, ex);
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
                
                datos.setearConsulta("select COUNT(*) from articulos where IdCategoria = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                datos.Lector.Read();
                int contador = datos.Lector.GetInt32(0); 

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
