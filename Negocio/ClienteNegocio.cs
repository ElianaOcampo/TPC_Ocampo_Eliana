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
    public class ClienteNegocio
    {

        public List<Cliente> listarClientes()
        {
            List<Cliente> listado = new List<Cliente>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Cliente cliente;
            try
            {
                accesoDatos.setearConsulta("SELECT DNI,APELLIDO,NOMBRE,MAIL,ESTADO FROM CLIENTES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    cliente = new Cliente();
                    cliente.Estado = (bool)accesoDatos.Lector["ESTADO"];
                    if (cliente.Estado == true)
                    {
                        cliente.DNI = (int)accesoDatos.Lector["DNI"];
                        cliente.Apellido = accesoDatos.Lector["APELLIDO"].ToString();
                        cliente.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                        cliente.Mail = accesoDatos.Lector["MAIL"].ToString();
                        listado.Add(cliente);
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
                accesoDatos.setearConsulta("SELECT ID,NUMERO,TIPOTEL FROM TELEFONOS INNER JOIN CLIENTES ON TELEFONOS.ID = CLIENTES.IDTELEFONO WHERE CLIENTES.DNI =" + "'" + Dni + "'");
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
                accesoDatos.setearConsulta("SELECT ID,CALLE,ALTURA,CODIGO_POSTAL,LOCALIDAD FROM DOMICILIOS INNER JOIN CLIENTES ON DOMICILIOS.ID = CLIENTES.IDDOMICILIO WHERE CLIENTES.DNI =" + "'" + Dni + "'");
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

        public void AgregarCiente(Cliente nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_AGREGAR_CLIENTE");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@APELLIDO", nuevo.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@NOMBRE", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@MAIL", nuevo.Mail);
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

        public void ModificarCiente(Cliente nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_MODIFICAR_CLIENTE");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@APELLIDO", nuevo.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@NOMBRE", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@MAIL", nuevo.Mail);
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

        public void EliminarCliente(Cliente nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE CLIENTES SET ESTADO=0 WHERE DNI=";
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
    }
}
