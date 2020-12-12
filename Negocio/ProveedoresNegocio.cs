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
    public class ProveedoresNegocio
    {
        public List<Proveedor> listarProveedores()
        {
            List<Proveedor> listado = new List<Proveedor>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Proveedor proveedor;
            try
            {
                accesoDatos.setearConsulta("SELECT CUIT, RAZON_SOCIAL, CONTACTO, IDTELEFONO, ESTADO FROM PROVEEDORES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    proveedor = new Proveedor();
                    proveedor.Estado = (bool)accesoDatos.Lector["ESTADO"];
                    if (proveedor.Estado == true)
                    {
                        proveedor.CUIT = (long)accesoDatos.Lector["CUIT"];
                        proveedor.RazonSocial = accesoDatos.Lector["RAZON_SOCIAL"].ToString();
                        proveedor.NombreContacto = accesoDatos.Lector["CONTACTO"].ToString();
                        proveedor.telefono = new Telefono();
                        proveedor.telefono.Id = (long)accesoDatos.Lector["IDTELEFONO"];
                        listado.Add(proveedor);
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

        public void agregarProveedor(Proveedor nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_AGREGAR_PROVEEDOR");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@CUIT", nuevo.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@RAZON_SOCIAL", nuevo.RazonSocial);
                accesoDatos.Comando.Parameters.AddWithValue("@CONTACTO", nuevo.NombreContacto);
                accesoDatos.Comando.Parameters.AddWithValue("@NUMERO", nuevo.telefono.Numero);
                accesoDatos.Comando.Parameters.AddWithValue("@TIPOTEL", nuevo.telefono.TipoDeTelefono);
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

        public void agregarProductoXProveedor(Proveedor nuevo, Producto producto, int precio)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_ACTUALIZAR_PRODUCTOSXPROVEEDORES");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IDPROD", producto.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IDPROV", nuevo.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@PRECIO", precio);
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

        public Telefono buscarTelefono(long CUIT)
        {
            Telefono telefono = new Telefono();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("SELECT ID,NUMERO,TIPOTEL FROM TELEFONOS INNER JOIN PROVEEDORES ON TELEFONOS.ID = PROVEEDORES.IDTELEFONO WHERE PROVEEDORES.CUIT =" + "'" + CUIT + "'");
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

        public void EliminarProveedor(Proveedor nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE PROVEEDORES SET ESTADO=0 WHERE CUIT=";
                comando.CommandText += "'" + nuevo.CUIT + "'";
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

        public void ModificarProveedor(Proveedor nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_MODIFICAR_PROVEEDOR");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@CUIT", nuevo.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@RAZON_SOCIAL", nuevo.RazonSocial);
                accesoDatos.Comando.Parameters.AddWithValue("@CONTACTO", nuevo.NombreContacto);
                accesoDatos.Comando.Parameters.AddWithValue("@NUMERO", nuevo.telefono.Numero);
                accesoDatos.Comando.Parameters.AddWithValue("@TIPOTEL", nuevo.telefono.TipoDeTelefono);
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
