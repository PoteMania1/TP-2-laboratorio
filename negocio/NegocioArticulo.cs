using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using acceso_a_datos;


namespace negocio
{
    public class NegocioArticulo
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio FROM ARTICULOS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    //aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Precio = (Decimal)datos.Lector["Precio"];

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
                datos.CerrarConexion();
            }
            
        }

        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try{
                datos.SetearConsulta("insert into ARTICULOS values(@Id, @Codigo, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.SetearParametro("@Id",nuevo.Id);
                datos.SetearParametro("@Codigo",nuevo.Codigo);
                //datos.SetearParametro("@Nombre",nuevo.Nombre);
                datos.SetearParametro("@Descripcion",nuevo.Descripcion);
                datos.SetearParametro("@IdMarca",nuevo.IdMarca);
                datos.SetearParametro("@IdCategoria",nuevo.IdCategoria);
                datos.SetearParametro("@Precio",nuevo.Precio);
                datos.EjecutarLectura();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
