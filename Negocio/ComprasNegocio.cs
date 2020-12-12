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
    public class ComprasNegocio
    {
        public void AgregarCompra(long id, long proveedor)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_AGREGAR_COMPRA");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@ID", id);
                accesoDatos.Comando.Parameters.AddWithValue("@IDPROVEEDOR", proveedor);
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

        public long IniciarCompra(long proveedor)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Compra compra;
            accesoDatos.setearConsulta("SELECT TOP(1) ID FROM COMPRAS ORDER BY ID DESC");
            accesoDatos.abrirConexion();
            accesoDatos.ejecutarConsulta();
            accesoDatos.Lector.Read();
            compra = new Compra();
            compra.Id = (long)accesoDatos.Lector["ID"];
            compra.Id = compra.Id + 1;

            AgregarCompra(compra.Id, proveedor);

            return compra.Id;
        }

        public void AgregarFactura(Factura nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_AGREGAR_FACTURAXCOMPRA");
                accesoDatos.Comando.Parameters.Clear();
                Console.WriteLine(nuevo.Id);
                Console.WriteLine(nuevo.Producto);
                Console.WriteLine(nuevo.Costo);
                Console.WriteLine(nuevo.Cantidad);
                Console.WriteLine(nuevo.SubTotal);
                accesoDatos.Comando.Parameters.AddWithValue("@ID", nuevo.Id);
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
                accesoDatos.setearConsulta("SELECT ID, IDPRODUCTO, COSTO, CANTIDAD, SUB_TOTAL FROM FACTURA INNER JOIN FACTURAXCOMPRA AS V ON V.IDFACTURA=ID WHERE V.IDCOMPRA=" + "'" + id + "'");
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

        public void ModificarCompra(Compra nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_MODIFICAR_COMPRA");
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

        public List<Compra> ListarInforme()
        {
            List<Compra> listado = new List<Compra>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Compra producto;

            try
            {
                accesoDatos.setearConsulta("SELECT ID, PROVEEDOR, COSTO_TOTAL, METODOPAGO, TARJETA,  FECHA, ESTADO FROM COMPRAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    producto = new Compra();
                    producto.Id = (long)accesoDatos.Lector["ID"];
                    producto.Proveedor = (long)accesoDatos.Lector["PROVEEDOR"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["COSTO_TOTAL"]))
                        producto.CostoTotal = (int)accesoDatos.Lector["COSTO_TOTAL"];
                    if (!Convert.IsDBNull(accesoDatos.Lector["TARJETA"]))
                        producto.Tarjeta = (long)accesoDatos.Lector["TARJETA"];
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
    }
}
