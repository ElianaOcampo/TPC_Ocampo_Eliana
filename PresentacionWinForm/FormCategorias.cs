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
    public partial class FormCategorias : Form
    {
        List<Categorias> listarCategoriasLocal;
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            cargarGrilla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Categorias catLocal;
            CategoriasNegocio negocio = new CategoriasNegocio();
            try
            {
                catLocal = new Categorias();
                catLocal.Id = Convert.ToInt32(txtId.Text);
                catLocal.Nombre = txtNombre.Text;

                negocio.EliminarCategoria(catLocal);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Categorias local;
            CategoriasNegocio negocio = new CategoriasNegocio();
            try
            {
                local = new Categorias();
                local.Id = Convert.ToInt32(txtId.Text);
                local.Nombre = txtNombre.Text;

                negocio.ModificarCategoria(local);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarGrilla()
        {
            CategoriasNegocio negocio = new CategoriasNegocio();
            try
            {
                listarCategoriasLocal = negocio.listarCategorias();
                dgvCategorias.DataSource = listarCategoriasLocal;
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
                dgvCategorias.DataSource = listarCategoriasLocal;
            }
            else
            {
                if (txtBuscar.Text.Length >= 2)
                {
                    List<Categorias> lista;
                    lista = listarCategoriasLocal.FindAll(X => X.Nombre.Contains(txtBuscar.Text));
                    dgvCategorias.DataSource = lista;
                }
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
            txtId.Text = dgvCategorias.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvCategorias.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categorias catLocal;
            CategoriasNegocio negocio = new CategoriasNegocio();
            try
            {
                catLocal = new Categorias();

                catLocal.Nombre = txtNombre.Text;

                negocio.agregarCategoria(catLocal);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
