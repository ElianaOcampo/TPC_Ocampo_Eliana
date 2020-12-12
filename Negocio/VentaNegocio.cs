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
    public class VentaNegocio
    {
        public void AgregarVenta(long id, int dniEmpleado, int dniCliente)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_AGREGAR_VENTA");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@ID", id);
                accesoDatos.Comando.Parameters.AddWithValue("@IDEMPLEADO", dniEmpleado);
                accesoDatos.Comando.Parameters.AddWithValue("@DNICLIENTE", dniCliente);
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

        public long IniciarVenta(int dniEmpleado, int dniCliente)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Venta venta;
            accesoDatos.setearConsulta("SELECT TOP(1) ID FROM VENTAS ORDER BY ID DESC");
            accesoDatos.abrirConexion();
            accesoDatos.ejecutarConsulta();
            accesoDatos.Lector.Read();
            venta = new Venta();
            venta.Id = (long)accesoDatos.Lector["ID"];
            venta.Id = venta.Id + 1;

            AgregarVenta(venta.Id, dniEmpleado, dniCliente);

            return venta.Id;
        }

        public void AgregarFactura(Factura nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_AGREGAR_FACTURAXVENTA");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@ID", nuevo.Producto);
                accesoDatos.Comando.Parameters.AddWithValue("@IDPRODUCTO", nuevo.Producto);
                accesoDatos.Comando.Parameters.AddWithValue("@COSTO", nuevo.Costo);
                accesoDatos.Comando.Parameters.AddWithValue("@CANTIDAD", nuevo.Cantidad);
                accesoDatos.Comando.Parameters.AddWithValue("@SUBTOTAL", nuevo.SubTotal);
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

        public List<Factura> listarFacturas(long id)
        {
            List<Factura> listado = new List<Factura>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Factura factura;
            try
            {
                accesoDatos.setearConsulta("SELECT ID, IDPRODUCTO, COSTO, CANTIDAD, SUB_TOTAL FROM FACTURA INNER JOIN FACTURAXVENTA AS V ON V.IDFACTURA=ID WHERE V.IDVENTA=" + "'" + id + "'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    factura = new Factura();
                    factura.Id = Convert.ToInt64(accesoDatos.Lector["ID"]);
                    factura.Producto = Convert.ToInt64(accesoDatos.Lector["IDPRODUCTO"]);
                    factura.Costo = (int)accesoDatos.Lector["COSTO"];
                    factura.Cantidad = (int)accesoDatos.Lector["CANTIDAD"];
                    factura.SubTotal = (int)accesoDatos.Lector["SUB_TOTAL"];
                    listado.Add(factura);
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

        public void ModificarVenta(Venta nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_MODIFICAR_VENTA");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@ID", nuevo.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@COSTOTOTAL", nuevo.CostoTotal);
                accesoDatos.Comando.Parameters.AddWithValue("@METODOPAGO", nuevo.MetodoPago);
                accesoDatos.Comando.Parameters.AddWithValue("@TARJETA", nuevo.Tarjeta);
                accesoDatos.Comando.Parameters.AddWithValue("@CODIGO", nuevo.Codigo);
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

        public List<Venta> ListarInforme()
        {
            List<Venta> listado = new List<Venta>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Venta producto;

            try
            {
                accesoDatos.setearConsulta("SELECT ID, IDEMPLEADO, COSTO_TOTAL, METODOPAGO, FECHA, ESTADO FROM VENTAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    producto = new Venta();
                    producto.Id = Convert.ToInt64(accesoDatos.Lector["ID"]);
                    producto.Empleado = (int)accesoDatos.Lector["IDEMPLEADO"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["COSTO_TOTAL"]))
                        producto.CostoTotal = (int)accesoDatos.Lector["COSTO_TOTAL"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["METODOPAGO"]))
                        producto.MetodoPago = accesoDatos.Lector["METODOPAGO"].ToString();
                    producto.Estado = (bool)accesoDatos.Lector["ESTADO"];
                    listado.Add(producto);
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

        public List<Venta> ListarInformeBajas()
        {
            List<Venta> listado = new List<Venta>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Venta producto;

            try
            {
                accesoDatos.setearConsulta("SELECT ID, IDEMPLEADO, COSTO_TOTAL, METODOPAGO, FECHA, ESTADO FROM VENTAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    producto = new Venta();
                    producto.Id = Convert.ToInt64(accesoDatos.Lector["ID"]);
                    producto.Empleado = (int)accesoDatos.Lector["IDEMPLEADO"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["COSTO_TOTAL"]))
                        producto.CostoTotal = (int)accesoDatos.Lector["COSTO_TOTAL"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["METODOPAGO"]))
                        producto.MetodoPago = accesoDatos.Lector["METODOPAGO"].ToString();
                    producto.Estado = (bool)accesoDatos.Lector["ESTADO"];
                    if (producto.Estado == false)
                    {
                        listado.Add(producto);
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

        public List<Venta> ListarInformeAltas()
        {
            List<Venta> listado = new List<Venta>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Venta producto;

            try
            {
                accesoDatos.setearConsulta("SELECT ID, IDEMPLEADO, COSTO_TOTAL, METODOPAGO, FECHA, ESTADO FROM VENTAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    producto = new Venta();
                    producto.Id = Convert.ToInt64(accesoDatos.Lector["ID"]);
                    producto.Empleado = (int)accesoDatos.Lector["IDEMPLEADO"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["COSTO_TOTAL"]))
                        producto.CostoTotal = (int)accesoDatos.Lector["COSTO_TOTAL"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["METODOPAGO"]))
                        producto.MetodoPago = accesoDatos.Lector["METODOPAGO"].ToString();
                    producto.Estado = (bool)accesoDatos.Lector["ESTADO"];
                    if (producto.Estado == true)
                    {
                        listado.Add(producto);
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
