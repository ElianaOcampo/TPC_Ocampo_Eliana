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
    public class MarcasNegocio
    {
        public List<Marcas> listarMarcas()
        {
            List<Marcas> listado = new List<Marcas>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Marcas marca;
            try
            {
                accesoDatos.setearConsulta("SELECT ID, NOMBRE FROM MARCAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    marca = new Marcas();
                    marca.Id = (int)accesoDatos.Lector["ID"];
                    marca.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                    listado.Add(marca);
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

        public void agregarMarca(Marcas nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO MARCAS (NOMBRE) VALUES";
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

        public void ModificarMarca(Marcas nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE MARCAS SET NOMBRE";
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

        public void EliminarMarca(Marcas nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "DELETE FROM MARCAS WHERE ID=";
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
