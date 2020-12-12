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
    public partial class FormProveedores : Form
    {
        private List<Proveedor> listarProveedoresLocal;
        private List<Producto> listarProductosLocal;
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtRazSoc.CharacterCasing = CharacterCasing.Upper;
            txtContacto.CharacterCasing = CharacterCasing.Upper;
            txtTipo.CharacterCasing = CharacterCasing.Upper;
            txtIdProd.Enabled = false;
            txtDescProd.Enabled = false;
            cargarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarGrilla()
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            try
            {
                listarProveedoresLocal = negocio.listarProveedores();
                dgvProveedores.DataSource = listarProveedoresLocal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                dgvProveedores.DataSource = listarProveedoresLocal;
            }
            else
            {
                if (txtBuscar.Text.Length >= 2)
                {
                    List<Proveedor> lista;
                    lista = listarProveedoresLocal.FindAll(X => X.CUIT.ToString().Contains(txtBuscar.Text));
                    dgvProveedores.DataSource = lista;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Proveedor local;
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            try
            {
                local = new Proveedor();
                local.CUIT = Convert.ToInt32(txtCuit.Text);

                negocio.EliminarProveedor(local);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor cliente = new Proveedor();
            ProveedoresNegocio negocio = new ProveedoresNegocio();

            if (txtCuit.Text.Length > 0 && txtRazSoc.Text.Length > 0 && txtContacto.Text.Length > 0 && txtNumero.Text.Length > 0 && txtTipo.Text.Length > 0)
            {
                cliente.CUIT = Convert.ToInt32(txtCuit.Text);
                cliente.RazonSocial = txtRazSoc.Text;
                cliente.NombreContacto = txtContacto.Text;
                cliente.telefono = new Telefono();
                cliente.telefono.Id = Convert.ToInt32(txtId.Text);
                cliente.telefono.Numero = Convert.ToInt32(txtNumero.Text);
                cliente.telefono.TipoDeTelefono = txtTipo.Text;

                negocio.agregarProveedor(cliente);

                cargarGrilla();
            }
            else
                MessageBox.Show("DEBEN ESTAR TODOS LOS CAMPOS COMPLETOS!!");
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCuit.Text = dgvProveedores.CurrentRow.Cells[0].Value.ToString();
                txtRazSoc.Text = dgvProveedores.CurrentRow.Cells[1].Value.ToString();
                txtContacto.Text = dgvProveedores.CurrentRow.Cells[2].Value.ToString();

                ProveedoresNegocio negocio = new ProveedoresNegocio();

                Telefono telefono = new Telefono();
                telefono = negocio.buscarTelefono(Convert.ToInt32(txtCuit.Text));
                txtId.Text = telefono.Id.ToString();
                txtNumero.Text = telefono.Numero.ToString();
                txtTipo.Text = telefono.TipoDeTelefono;

                cargarGrillaProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Telefono_Enter(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Proveedor cliente = new Proveedor();
            ProveedoresNegocio negocio = new ProveedoresNegocio();

            if (txtCuit.Text.Length > 0 && txtRazSoc.Text.Length > 0 && txtContacto.Text.Length > 0 && txtNumero.Text.Length > 0 && txtTipo.Text.Length > 0)
            {
                cliente.CUIT = Convert.ToInt32(txtCuit.Text);
                cliente.RazonSocial = txtRazSoc.Text;
                cliente.NombreContacto = txtContacto.Text;
                cliente.telefono = new Telefono();
                cliente.telefono.Id = Convert.ToInt32(txtId.Text);
                cliente.telefono.Numero = Convert.ToInt32(txtNumero.Text);
                cliente.telefono.TipoDeTelefono = txtTipo.Text;

                if (cliente.telefono.Id > 0)
                {
                    negocio.ModificarProveedor(cliente);
                }
                else
                    MessageBox.Show("EL PROVEEDOR NO EXISTE!! INTENTE CON AGREGAR");

                cargarGrilla();
            }
            else
                MessageBox.Show("DEBEN ESTAR TODOS LOS CAMPOS COMPLETOS!!");
        }

        private void cargarGrillaProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                listarProductosLocal = negocio.listarProductosTotales();
                dgvProductos.DataSource = listarProductosLocal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdProd.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
            txtDescProd.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = "0";
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            try
            {
                Proveedor proveedor = new Proveedor();
                proveedor.CUIT = Convert.ToInt32(txtCuit.Text);
                Producto producto = new Producto();
                producto.Id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value.ToString());
                int precio = Convert.ToInt32(txtPrecio.Text);

                negocio.agregarProductoXProveedor(proveedor, producto, precio);

                txtPrecio.Text = "";
                MessageBox.Show("AGREGADO!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
