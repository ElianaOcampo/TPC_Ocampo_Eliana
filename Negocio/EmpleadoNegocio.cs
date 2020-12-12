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
    public class EmpleadoNegocio
    {
        public List<String> listarTipos()
        {
            List<String> lista = new List<string>();
            lista.Add("GERENTE");
            lista.Add("VENDEDOR");

            return lista;
        }

        public List<Empleado> listarEmpleados()
        {
            List<Empleado> listado = new List<Empleado>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Empleado empleado;
            try
            {
                accesoDatos.setearConsulta("SELECT DNI,APELLIDO,NOMBRE,CUIL,MAIL,TIPO,IDTELEFONO,IDDOMICILIO,ESTADO FROM EMPLEADOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    empleado = new Empleado();
                    empleado.Estado = (bool)accesoDatos.Lector["ESTADO"];
                    if (empleado.Estado==true)
                    {
                        empleado.DNI = (int)accesoDatos.Lector["DNI"];
                        empleado.Apellido = accesoDatos.Lector["APELLIDO"].ToString();
                        empleado.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                        empleado.CUIL = (long)accesoDatos.Lector["CUIL"];
                        empleado.Mail = accesoDatos.Lector["MAIL"].ToString();
                        empleado.Tipo = accesoDatos.Lector["TIPO"].ToString();
                        empleado.telefono = new Telefono();
                        empleado.telefono.Id = (long)accesoDatos.Lector["IDTELEFONO"];
                        empleado.domicilio = new Domicilio();
                        empleado.domicilio.Id = (long)accesoDatos.Lector["IDDOMICILIO"];
                        listado.Add(empleado);
                    }
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

        public Telefono buscarTelefono(int Dni)
        {
            Telefono telefono = new Telefono();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("SELECT ID,NUMERO,TIPOTEL FROM TELEFONOS INNER JOIN EMPLEADOS ON TELEFONOS.ID = EMPLEADOS.IDTELEFONO WHERE EMPLEADOS.DNI ="+"'"+Dni+"'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                accesoDatos.Lector.Read();
                telefono.Id = (long)accesoDatos.Lector["ID"];
                telefono.Numero = (int)accesoDatos.Lector["NUMERO"];
                telefono.TipoDeTelefono = accesoDatos.Lector["TIPOTEL"].ToString();

                return telefono;
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

        public Domicilio buscarDomicilio(int Dni)
        {
            Domicilio domicilio = new Domicilio();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("SELECT ID,CALLE,ALTURA,CODIGO_POSTAL,LOCALIDAD FROM DOMICILIOS INNER JOIN EMPLEADOS ON DOMICILIOS.ID = EMPLEADOS.IDTELEFONO WHERE EMPLEADOS.DNI =" + "'" + Dni + "'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                accesoDatos.Lector.Read();
                domicilio.Id = (long)accesoDatos.Lector["ID"];
                domicilio.Calle = accesoDatos.Lector["CALLE"].ToString();
                domicilio.Altura = (int)accesoDatos.Lector["ALTURA"];
                domicilio.CodigoPostal = (int)accesoDatos.Lector["CODIGO_POSTAL"];
                domicilio.Localidad = accesoDatos.Lector["LOCALIDAD"].ToString();

                return domicilio;
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

        public void AgregarEmpleado(Empleado nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_AGREGAR_EMPLEADO");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@APELLIDO", nuevo.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@NOMBRE", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@MAIL", nuevo.Mail);
                accesoDatos.Comando.Parameters.AddWithValue("@CUIL", nuevo.CUIL);
                accesoDatos.Comando.Parameters.AddWithValue("@TIPO", nuevo.Tipo);
                accesoDatos.Comando.Parameters.AddWithValue("@NUMERO", nuevo.telefono.Numero);
                accesoDatos.Comando.Parameters.AddWithValue("@TIPOTEL", nuevo.telefono.TipoDeTelefono);
                accesoDatos.Comando.Parameters.AddWithValue("@CALLE", nuevo.domicilio.Calle);
                accesoDatos.Comando.Parameters.AddWithValue("@ALTURA", nuevo.domicilio.Altura);
                accesoDatos.Comando.Parameters.AddWithValue("@CODPOS", nuevo.domicilio.CodigoPostal);
                accesoDatos.Comando.Parameters.AddWithValue("@LOCALIDAD", nuevo.domicilio.Localidad);
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

        public void ModificarEmpleado(Empleado nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_MODIFICAR_EMPLEADO");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@APELLIDO", nuevo.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@NOMBRE", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@MAIL", nuevo.Mail);
                accesoDatos.Comando.Parameters.AddWithValue("@CUIL", nuevo.CUIL);
                accesoDatos.Comando.Parameters.AddWithValue("@TIPO", nuevo.Tipo);
                accesoDatos.Comando.Parameters.AddWithValue("@NUMERO", nuevo.telefono.Numero);
                accesoDatos.Comando.Parameters.AddWithValue("@TIPOTEL", nuevo.telefono.TipoDeTelefono);
                accesoDatos.Comando.Parameters.AddWithValue("@CALLE", nuevo.domicilio.Calle);
                accesoDatos.Comando.Parameters.AddWithValue("@ALTURA", nuevo.domicilio.Altura);
                accesoDatos.Comando.Parameters.AddWithValue("@CODPOS", nuevo.domicilio.CodigoPostal);
                accesoDatos.Comando.Parameters.AddWithValue("@LOCALIDAD", nuevo.domicilio.Localidad);
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

        public void EliminarEmpleado(Empleado nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE EMPLEADOS SET ESTADO=0 WHERE DNI=";
                comando.CommandText += "(" + nuevo.DNI + ")";
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

        public List<Empleado> ListarEmpleadosSinUsuario()
        {
            List<Empleado> listado = new List<Empleado>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Empleado empleado;
            try
            {
                accesoDatos.setearConsulta("SELECT DNI,APELLIDO,NOMBRE,ESTADO FROM EMPLEADOS WHERE DNI NOT IN (SELECT DNI FROM USUARIOS)");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    empleado = new Empleado();
                    empleado.Estado = (bool)accesoDatos.Lector["ESTADO"];
                    if (empleado.Estado == true)
                    {
                        empleado.DNI = (int)accesoDatos.Lector["DNI"];
                        empleado.Apellido = accesoDatos.Lector["APELLIDO"].ToString();
                        empleado.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                        listado.Add(empleado);
                    }
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
    }
}
