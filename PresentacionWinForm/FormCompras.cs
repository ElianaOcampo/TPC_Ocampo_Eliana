using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using TPC_Ocampo;

namespace PresentacionWinForm
{
    public partial class FormCompras : Form
    {

        public List<Producto> productoLocal;
        public List<Factura> facturaLocal;
        public int Total = 0, CantActual = 0;

        public FormCompras()
        {
            InitializeComponent();
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            iniciarCompra();
        }

        private void iniciarCompra()
        {
            txtId.Enabled = false;
            txtTotal.Enabled = false;
            txtCosto.Enabled = false;
            txtSubtotal.Enabled = false;
            txtCantidad.Enabled = false;
            txtProducto.Enabled = false;
            btnAgregar.Enabled = false;
            btnComprar.Enabled = false;
            txtIdProd.Enabled = false;

            cboProveedor.Enabled = true;
            btnIniciar.Enabled = true;

            txtBuscar.CharacterCasing = CharacterCasing.Upper;

            ProveedoresNegocio negocioC = new ProveedoresNegocio();
            cboProveedor.DataSource = negocioC.listarProveedores();
            cboProveedor.DisplayMember = "RAZON_SOCIAL";
            cboProveedor.ValueMember = "CUIT";

            cboMetodo.Items.Add("EFECTIVO");
            cboMetodo.Items.Add("DÉBITO");
            cboMetodo.Items.Add("CRÉDITO");
        }

        private void cargarGrilla()
        {
            ComprasNegocio negocio = new ComprasNegocio();
            try
            {
                facturaLocal = negocio.listarFacturas(Convert.ToInt64(txtId.Text));
                dgvFacturas.DataSource = facturaLocal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarGrillaProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                long idProv = (long)cboProveedor.SelectedValue;
                productoLocal = negocio.listarProductosXProveedor(idProv);
                dgvProductos.DataSource = productoLocal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            long proveedor = Convert.ToInt32(cboProveedor.SelectedValue);
            ComprasNegocio negocio = new ComprasNegocio();
            txtId.Text = negocio.IniciarCompra(proveedor).ToString();
            cboProveedor.Enabled = false;
            btnIniciar.Enabled = false;
            txtCantidad.Enabled = true;
            btnAgregar.Enabled = true;
            txtCantidad.Text = "0";

            cargarGrillaProductos();
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                if (Convert.ToInt32(txtCantidad.Text) != 0)
                {
                        Factura factura = new Factura();
                        factura.Id = Convert.ToInt32(txtId.Text);
                        factura.Producto = Convert.ToInt32(txtIdProd.Text);
                        factura.Costo = Convert.ToInt32(txtCosto.Text);
                        factura.Cantidad = Convert.ToInt32(txtCantidad.Text);
                        factura.SubTotal = Convert.ToInt32(txtSubtotal.Text);

                        ComprasNegocio negocio = new ComprasNegocio();
                        negocio.AgregarFactura(factura);

                        cargarGrilla();

                        Total = Total + factura.SubTotal;
                        txtTotal.Text = Total.ToString();

                        ProductoNegocio productoN = new ProductoNegocio();
                        Producto prod = new Producto();
                        prod.StockActual = CantActual + factura.Cantidad;
                        prod.Id = Convert.ToInt64(txtIdProd.Text);
                        productoN.ModificarStock(prod);
                        cargarGrillaProductos();
                        CantActual = prod.StockActual;

                    btnComprar.Enabled = true;
                }
                else
                    MessageBox.Show("COMPLETE LA CANTIDAD");
            }
            else
                MessageBox.Show("COMPLETE LA CANTIDAD");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                dgvProductos.DataSource = productoLocal;
            }
            else
            {
                if (txtBuscar.Text.Length >= 1)
                {
                    List<Producto> lista;
                    lista = productoLocal.FindAll(X => X.Descripcion.ToString().Contains(txtBuscar.Text));
                    dgvProductos.DataSource = lista;
                }
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIdProd.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                CantActual = Convert.ToInt32(dgvProductos.CurrentRow.Cells[2].Value);
                txtCosto.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
                if (txtCantidad.Text == "")
                {
                    txtSubtotal.Text = "";
                }
                else
                {
                if (Convert.ToInt32(txtCantidad.Text) == 0)
                {
                    txtSubtotal.Text = "";
                }
                else
                {
                    int costo, cantidad, sub;
                    cantidad = Convert.ToInt32(txtCantidad.Text);
                    costo = Convert.ToInt32(txtCosto.Text);
                    sub = costo * cantidad;
                    txtSubtotal.Text = sub.ToString();
                }
                }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (cboMetodo.SelectedIndex!=0 && (txtTarjeta.Text=="" || txtCodigo.Text==""))
            {
                MessageBox.Show("SELECCIONE METODO DE PAGO - CON TARJETA TODOS LOS CAMPOS DEBEN ESTAR COMPLETOS!!");
            }
            else
            {
                Compra compra = new Compra();
                ComprasNegocio negocio = new ComprasNegocio();
                compra.Id = Convert.ToInt64(txtId.Text);
                compra.CostoTotal = Convert.ToInt32(txtTotal.Text);
                compra.MetodoPago = cboMetodo.SelectedItem.ToString();
                compra.Tarjeta = Convert.ToInt32(txtTarjeta.Text);
                compra.Codigo = Convert.ToInt32(txtCodigo.Text);

                negocio.ModificarCompra(compra);
                MessageBox.Show("COMPRA REALIZADA");
                iniciarCompra();
            }
        }
        
    }
}
