using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatos;
using TPC_Ocampo;


namespace Negocio
{
    public class CategoriasNegocio
    {
        public List<Categorias> listarCategorias()
        {
            List<Categorias> listado = new List<Categorias>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Categorias categoria;
            try
            {
                accesoDatos.setearConsulta("SELECT ID, NOMBRE FROM CATEGORIAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    categoria = new Categorias();
                    categoria.Id = (int)accesoDatos.Lector["ID"];
                    categoria.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                    listado.Add(categoria);
                }

                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void agregarCategoria(Categorias nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO CATEGORIAS (NOMBRE) VALUES";
                comando.CommandText += "('" + nuevo.Nombre + "')";
                comando.Connection = conexion;
                conexion.Open();

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void ModificarCategoria(Categorias nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE CATEGORIAS SET NOMBRE ";
                comando.CommandText += "= '" + nuevo.Nombre + "'";
                comando.CommandText += " WHERE ID= ";
                comando.CommandText += "'" + nuevo.Id + "'";
                comando.Connection = conexion;
                conexion.Open();

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void EliminarCategoria(Categorias nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "DELETE FROM CATEGORIAS WHERE ID=";
                comando.CommandText += "'" + nuevo.Id + "'";
                comando.Connection = conexion;
                conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
