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
    public class UsuariosNegocio
    {
        public Usuarios IniciarSesion(Usuarios nuevo)
        {
            Usuarios usuario = new Usuarios();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("SELECT NOMBRE,DNI,PERMISO FROM USUARIOS WHERE NOMBRE =" + "'" + nuevo.NombreUsuario + "'" + "AND CODIGO=" + "'" + nuevo.Contraseña + "'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                accesoDatos.Lector.Read();
                usuario.NombreUsuario = accesoDatos.Lector["NOMBRE"].ToString();
                usuario.Dni = (int)accesoDatos.Lector["DNI"];
                usuario.Permiso = (int)accesoDatos.Lector["PERMISO"];
                accesoDatos.cerrarConexion();

                
                return usuario;
            }
            catch
            {
                usuario.Dni = 0;
                return usuario;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void ModificarContraseña(Usuarios usuario)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE USUARIOS SET CODIGO";
                comando.CommandText += "= '" + usuario.Contraseña + "'";
                comando.CommandText += " WHERE DNI= ";
                comando.CommandText += "'" + usuario.Dni + "'";
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

        public void AgregarUsuario(Usuarios nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_AGREGAR_USUARIO");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.Dni);
                accesoDatos.Comando.Parameters.AddWithValue("@NOMBRE", nuevo.NombreUsuario);
                accesoDatos.Comando.Parameters.AddWithValue("@CODIGO", nuevo.Contraseña);
                accesoDatos.Comando.Parameters.AddWithValue("@PERMISO", nuevo.Permiso);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();

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
    }
}
