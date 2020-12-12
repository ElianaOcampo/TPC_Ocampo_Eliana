using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Negocio;
using TPC_Ocampo;

namespace PresentacionWinForm
{
    public partial class FormProductos : Form
    {
        private List<Producto> listarProductoLocal;
        public FormProductos()
        {
            InitializeComponent();
        }

        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtDescripcion.CharacterCasing = CharacterCasing.Upper;
            CategoriasNegocio categoriasNegocio = new CategoriasNegocio();
            try
            {
                cboCategoria.DataSource = categoriasNegocio.listarCategorias();
                cboCategoria.DisplayMember = "Nombre";
                cboCategoria.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MarcasNegocio marcasNegocio = new MarcasNegocio();
            try
            {
                cboMarca.DataSource = marcasNegocio.listarMarcas();
                cboMarca.DisplayMember = "Nombre";
                cboMarca.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto productoLocal = new Producto();
            ProductoNegocio negocio = new ProductoNegocio();
         
            if(txtDescripcion.Text.Length>0&&txtPrecio.Text.Length>0&&txtSAct.Text.Length>0&&txtSMin.Text.Length>0)
            {
                productoLocal = new Producto();
                productoLocal.categoria = new Categorias();
                productoLocal.marca = new Marcas();

                productoLocal.Descripcion = txtDescripcion.Text;
                productoLocal.marca.Nombre = cboMarca.SelectedItem.ToString();
                productoLocal.categoria.Nombre = cboCategoria.SelectedItem.ToString();
                productoLocal.PrecioVenta = Convert.ToDecimal(txtPrecio.Text);
                productoLocal.StockMinimo = Convert.ToInt32(txtSMin.Text);
                productoLocal.StockActual = Convert.ToInt32(txtSAct.Text);

                negocio.AgregarProducto(productoLocal);
                cargarGrilla();
            }
            else
                MessageBox.Show("DEBEN ESTAR TODOS LOS CAMPOS COMPLETOS!!");

        }

        private void cargarGrilla()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                listarProductoLocal = negocio.listarProductos();
                dgvProductos.DataSource = listarProductoLocal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                txtSAct.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                txtSMin.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();

                ProductoNegocio negocio = new ProductoNegocio();

                Categorias categoria = new Categorias();
                categoria = negocio.buscarCategoria(Convert.ToInt64(txtId.Text));
                cboCategoria.Text = categoria.Nombre.ToString();

                Marcas marca = new Marcas();
                marca = negocio.buscarMarca(Convert.ToInt64(txtId.Text));
                cboMarca.Text = marca.Nombre.ToString();
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
                dgvProductos.DataSource = listarProductoLocal;
            }
            else
            {
                if (txtBuscar.Text.Length >= 1)
                {
                    List<Producto> lista;
                    lista = listarProductoLocal.FindAll(X => X.Descripcion.ToString().Contains(txtBuscar.Text));
                    dgvProductos.DataSource = lista;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto local;
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                local = new Producto();
                local.Id = Convert.ToUInt32(txtId.Text);

                negocio.EliminarProducto(local);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Producto productoLocal = new Producto();
            ProductoNegocio negocio = new ProductoNegocio();

            if (txtDescripcion.Text.Length > 0 && txtPrecio.Text.Length > 0 && txtSAct.Text.Length > 0 && txtSMin.Text.Length > 0)
            {
                productoLocal = new Producto();
                productoLocal.categoria = new Categorias();
                productoLocal.marca = new Marcas();

                productoLocal.Id = Convert.ToInt32(txtId.Text);
                productoLocal.Descripcion = txtDescripcion.Text;
                productoLocal.marca.Nombre = cboMarca.SelectedItem.ToString();
                productoLocal.categoria.Nombre = cboCategoria.SelectedItem.ToString();
                productoLocal.PrecioVenta = Convert.ToDecimal(txtPrecio.Text);
                productoLocal.StockMinimo = Convert.ToInt32(txtSMin.Text);
                productoLocal.StockActual = Convert.ToInt32(txtSAct.Text);

                if (productoLocal.Id>0)
                    negocio.ModificarProducto(productoLocal);
                else
                    MessageBox.Show("EL PRODUCTO NO EXISTE!! INTENTE CON AGREGAR");

                cargarGrilla();
            }
            else
                MessageBox.Show("NO ESTAN TODOS LOS CAMPOS COMPLETOS!!");
        }
    }
}
