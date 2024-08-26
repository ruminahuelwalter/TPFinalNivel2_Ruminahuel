using System;
using System.Collections.Generic;
using dominio;
namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Codigo, Nombre, A.Descripcion, ImagenUrl, C.Descripcion Categoria, M.Descripcion Marca, A.IdCategoria, A.IdMarca, A.Id From ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca And C.Id = A.IdCategoria ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["Id"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    }

                    aux.Precio = (double)datos.Lector["Precio"];


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

        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion,IdMarca, IdCategoria, ImagenUrl, Precio) values (" + nuevo.Codigo + ",'" + nuevo.Nombre + "','" + nuevo.Descripcion+"',@idMarca, @idCategoria, @imagenUrl,'" + nuevo.Precio + "')");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@urlImagen", nuevo.UrlImagen);

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


        public void Modificar(Articulo article)
        {
            AccesoDatos datos = new AccesoDatos();
     
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCategoria, UrlImagen = @img, Precio = @precio Where Id = @id");
                datos.setearParametro("@numero", article.Codigo);
                datos.setearParametro("@nombre", article.Nombre);
                datos.setearParametro("@desc", article.Descripcion);
                datos.setearParametro("@img", article.UrlImagen);
                datos.setearParametro("@precio", article.Precio);
                datos.setearParametro("@idMarca", article.Marca.Id);
                datos.setearParametro("@idCategoria", article.Categoria.Id);
                datos.setearParametro("@id", article.Id);
    
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

            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
