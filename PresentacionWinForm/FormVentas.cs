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
    public partial class FormVentas : Form
    {

        public List<Producto> productoLocal;
        public List<Factura> facturaLocal;
        public int Total = 0, Maximo = 0;

        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            cargarNuevaVenta();
            cargarGrillaProductos();
        }

        private void cargarNuevaVenta()
        {
            cboEmpleado.Enabled = true;
            cboCliente.Enabled = true;
            btnIniciar.Enabled = true;

            txtId.Enabled = false;
            txtTotal.Enabled = false;
            txtCosto.Enabled = false;
            txtSubtotal.Enabled = false;
            txtCantidad.Enabled = false;
            txtProducto.Enabled = false;
            btnAgregar.Enabled = false;
            btnComprar.Enabled = false;
            txtIdProd.Enabled = false;

            txtBuscar.CharacterCasing = CharacterCasing.Upper;

            EmpleadoNegocio negocioE = new EmpleadoNegocio();
            cboEmpleado.DataSource = negocioE.listarEmpleados();
            cboEmpleado.DisplayMember = "APELLIDO";
            cboEmpleado.ValueMember = "DNI";

            ClienteNegocio negocioC = new ClienteNegocio();
            cboCliente.DataSource = negocioC.listarClientes();
            cboCliente.DisplayMember = "DNI";
            cboCliente.ValueMember = "DNI";

            cboMetodo.Items.Add("EFECTIVO");
            cboMetodo.Items.Add("DÉBITO");
            cboMetodo.Items.Add("CRÉDITO");
        }

        private void cargarGrilla()
        {
            VentaNegocio negocio = new VentaNegocio();
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
                productoLocal = negocio.listarProductos();
                dgvProductos.DataSource = productoLocal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            int dniEmpleado, dniCliente;
            dniEmpleado = Convert.ToInt32(cboEmpleado.SelectedValue);
            dniCliente = Convert.ToInt32(cboCliente.SelectedValue);
            VentaNegocio negocio = new VentaNegocio();
            txtId.Text = negocio.IniciarVenta(dniEmpleado, dniCliente).ToString();
            cboCliente.Enabled = false;
            cboEmpleado.Enabled = false;
            btnIniciar.Enabled = false;
            txtCantidad.Enabled = true;
            btnAgregar.Enabled = true;
            btnComprar.Enabled = true;
            txtCantidad.Text = "0";
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                if (Convert.ToInt32(txtCantidad.Text) != 0)
                {
                    if (Convert.ToInt32(txtCantidad.Text) <= Maximo)
                    {
                        Factura factura = new Factura();
                        factura.Id = Convert.ToInt32(txtId.Text);
                        factura.Producto = Convert.ToInt32(txtIdProd.Text);
                        factura.Costo = Convert.ToInt32(txtCosto.Text);
                        factura.Cantidad = Convert.ToInt32(txtCantidad.Text);
                        factura.SubTotal = Convert.ToInt32(txtSubtotal.Text);

                        VentaNegocio negocio = new VentaNegocio();
                        negocio.AgregarFactura(factura);

                        cargarGrilla();

                        Total = Total + factura.SubTotal;
                        txtTotal.Text = Total.ToString();

                        ProductoNegocio productoN = new ProductoNegocio();
                        Producto prod = new Producto();
                        prod.StockActual = Maximo - factura.Cantidad;
                        prod.Id = Convert.ToInt64(txtIdProd.Text);
                        productoN.ModificarStock(prod);
                        cargarGrillaProductos();
                        Maximo = prod.StockActual;
                    }
                    else
                        MessageBox.Show("LA CANTIDAD NO PUEDE SER MAYOR AL STOCK ACTUAL");

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
                Maximo = Convert.ToInt32(dgvProductos.CurrentRow.Cells[2].Value);
                txtCosto.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
                txtCantidad.Text = "0";
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
                Venta venta = new Venta();
                VentaNegocio negocio = new VentaNegocio();
                venta.Id = Convert.ToInt64(txtId.Text);
                venta.CostoTotal = Convert.ToInt32(txtTotal.Text);
                venta.MetodoPago = cboMetodo.SelectedItem.ToString();
                venta.Tarjeta = Convert.ToInt32(txtTarjeta.Text);
                venta.Codigo = Convert.ToInt32(txtCodigo.Text);

                negocio.ModificarVenta(venta);
                cargarNuevaVenta();
                dgvFacturas.Columns.Clear();
            }
        }
        
    }
}
