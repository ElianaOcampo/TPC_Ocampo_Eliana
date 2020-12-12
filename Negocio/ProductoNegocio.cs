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
    public class ProductoNegocio
    {
        public List<Producto> listarProductos()
        {
            List<Producto> listado = new List<Producto>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Producto producto;

            try
            {
                accesoDatos.setearConsulta("SELECT P.ID, P.DESCRIPCION, P.STOCK_ACTUAL, P.STOCK_MINIMO, P.IDCATEGORIA, P.PRECIO_COMPRA, P.IDMARCA, C.NOMBRE, M.NOMBRE FROM PRODUCTOS AS P, CATEGORIAS AS C, MARCAS AS M WHERE C.ID=IDCATEGORIA AND M.ID=IDMARCA AND P.ESTADO=1");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    producto = new Producto();
                    producto.Id = Convert.ToInt64(accesoDatos.Lector["ID"]);
                    producto.Descripcion = accesoDatos.Lector["DESCRIPCION"].ToString();
                    producto.StockActual = (int)accesoDatos.Lector["STOCK_ACTUAL"];
                    producto.StockMinimo = (int)accesoDatos.Lector["STOCK_MINIMO"];
                    producto.PrecioVenta = (decimal)accesoDatos.Lector["PRECIO_COMPRA"];
                    producto.categoria = new Categorias();
                    producto.categoria.Id = (int)accesoDatos.Lector["IDCATEGORIA"];
                    producto.categoria.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                    producto.marca = new Marcas();
                    producto.marca.Id = (int)accesoDatos.Lector["IDMARCA"];
                    producto.marca.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
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

        public List<Producto> listarProductosXProveedor(long idProv)
        {
            List<Producto> listado = new List<Producto>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Producto producto;

            try
            {
                accesoDatos.setearConsulta("SELECT P.ID, P.DESCRIPCION, P.STOCK_ACTUAL, P.STOCK_MINIMO, P.IDCATEGORIA, P.PRECIO_COMPRA, P.IDMARCA, C.NOMBRE, M.NOMBRE, PP.PRECIO FROM PRODUCTOS AS P, CATEGORIAS AS C, MARCAS AS M, PRODUCTOSXPROVEEDORES AS PP WHERE C.ID=IDCATEGORIA AND M.ID=IDMARCA AND PP.IDPRODUCTO=P.ID AND P.ESTADO=1 AND PP.IDPROVEEDOR=" + idProv);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    producto = new Producto();
                    producto.Id = Convert.ToInt64(accesoDatos.Lector["ID"]);
                    producto.Descripcion = accesoDatos.Lector["DESCRIPCION"].ToString();
                    producto.StockActual = (int)accesoDatos.Lector["STOCK_ACTUAL"];
                    producto.StockMinimo = (int)accesoDatos.Lector["STOCK_MINIMO"];
                    producto.PrecioVenta = (decimal)accesoDatos.Lector["PRECIO_COMPRA"];
                    producto.PrecioCompra = (int)accesoDatos.Lector["PRECIO"];
                    producto.categoria = new Categorias();
                    producto.categoria.Id = (int)accesoDatos.Lector["IDCATEGORIA"];
                    producto.categoria.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                    producto.marca = new Marcas();
                    producto.marca.Id = (int)accesoDatos.Lector["IDMARCA"];
                    producto.marca.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
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

        public List<Producto> listarProductosTotales()
        {
            List<Producto> listado = new List<Producto>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Producto producto;

            try
            {
                accesoDatos.setearConsulta("SELECT P.ID, P.DESCRIPCION, P.STOCK_ACTUAL, P.STOCK_MINIMO, P.IDCATEGORIA, P.PRECIO_COMPRA, P.IDMARCA, C.NOMBRE, M.NOMBRE FROM PRODUCTOS AS P, CATEGORIAS AS C, MARCAS AS M WHERE C.ID=IDCATEGORIA AND M.ID=IDMARCA");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    producto = new Producto();
                    producto.Id = Convert.ToInt64(accesoDatos.Lector["ID"]);
                    producto.Descripcion = accesoDatos.Lector["DESCRIPCION"].ToString();
                    producto.StockActual = (int)accesoDatos.Lector["STOCK_ACTUAL"];
                    producto.StockMinimo = (int)accesoDatos.Lector["STOCK_MINIMO"];
                    producto.PrecioVenta = (decimal)accesoDatos.Lector["PRECIO_COMPRA"];
                    producto.categoria = new Categorias();
                    producto.categoria.Id = (int)accesoDatos.Lector["IDCATEGORIA"];
                    producto.categoria.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                    producto.marca = new Marcas();
                    producto.marca.Id = (int)accesoDatos.Lector["IDMARCA"];
                    producto.marca.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
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

        public Categorias buscarCategoria(long Id)
        {
            Categorias categoria = new Categorias();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("SELECT C.ID,C.NOMBRE FROM CATEGORIAS AS C INNER JOIN PRODUCTOS ON C.ID = PRODUCTOS.IDCATEGORIA WHERE PRODUCTOS.ID =" + "'" + Id + "'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                accesoDatos.Lector.Read();
                categoria.Id = (int)accesoDatos.Lector["ID"];
                categoria.Nombre = accesoDatos.Lector["NOMBRE"].ToString();

                return categoria;
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

        public Marcas buscarMarca(long Id)
        {
            Marcas marca = new Marcas();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("SELECT C.ID,C.NOMBRE FROM MARCAS AS C INNER JOIN PRODUCTOS ON C.ID = PRODUCTOS.IDMARCA WHERE PRODUCTOS.ID =" + "'" + Id + "'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                accesoDatos.Lector.Read();
                marca.Id = (int)accesoDatos.Lector["ID"];
                marca.Nombre = accesoDatos.Lector["NOMBRE"].ToString();

                return marca;
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

        public void AgregarProducto(Producto nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_AGREGAR_PRODUCTO");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@MARCA", nuevo.marca.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@CATEGORIA", nuevo.categoria.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@DESCRIPCION", nuevo.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@STOCK_ACTUAL", nuevo.StockActual);
                accesoDatos.Comando.Parameters.AddWithValue("@STOCK_MINIMO", nuevo.StockMinimo);
                accesoDatos.Comando.Parameters.AddWithValue("@PRECIO", nuevo.PrecioVenta);
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

        public void ModificarProducto(Producto nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_MODIFICAR_PRODUCTO");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@MARCA", nuevo.marca.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@CATEGORIA", nuevo.categoria.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@DESCRIPCION", nuevo.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@STOCK_ACTUAL", nuevo.StockActual);
                accesoDatos.Comando.Parameters.AddWithValue("@ID", nuevo.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@STOCK_MINIMO", nuevo.StockMinimo);
                accesoDatos.Comando.Parameters.AddWithValue("@PRECIO", nuevo.PrecioVenta);
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

        public void ModificarStock(Producto nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("sp_MODIFICAR_STOCK");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@STOCK_ACTUAL", nuevo.StockActual);
                accesoDatos.Comando.Parameters.AddWithValue("@ID", nuevo.Id);
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

        public void EliminarProducto(Producto nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE PRODUCTOS SET ESTADO=0 WHERE ID=";
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

        public int ContarProductos()
        {
            int indice = 0;
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("SELECT COUNT(ID) AS CANT FROM PRODUCTOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                accesoDatos.Lector.Read();
                indice = (int)accesoDatos.Lector["CANT"];

                return indice;
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

        public List<Producto> ListarInforme()
        {
            List<Producto> listado = new List<Producto>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Producto producto;

            try
            {
                accesoDatos.setearConsulta("SELECT P.ID, P.DESCRIPCION, P.STOCK_ACTUAL, P.STOCK_MINIMO, P.IDCATEGORIA, P.PRECIO_COMPRA, P.IDMARCA, C.NOMBRE, M.NOMBRE FROM PRODUCTOS AS P, CATEGORIAS AS C, MARCAS AS M WHERE C.ID=IDCATEGORIA AND M.ID=IDMARCA");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    producto = new Producto();
                    producto.Id = Convert.ToInt64(accesoDatos.Lector["ID"]);
                    producto.Descripcion = accesoDatos.Lector["DESCRIPCION"].ToString();
                    producto.StockActual = (int)accesoDatos.Lector["STOCK_ACTUAL"];
                    producto.StockMinimo = (int)accesoDatos.Lector["STOCK_MINIMO"];
                    producto.PrecioVenta = (decimal)accesoDatos.Lector["PRECIO_COMPRA"];
                    producto.categoria = new Categorias();
                    producto.categoria.Id = (int)accesoDatos.Lector["IDCATEGORIA"];
                    producto.categoria.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                    producto.marca = new Marcas();
                    producto.marca.Id = (int)accesoDatos.Lector["IDMARCA"];
                    producto.marca.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                    if (producto.StockActual <= producto.StockMinimo)
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
