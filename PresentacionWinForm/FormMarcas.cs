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
    public partial class FormMarcas : Form
    {
        private List<Marcas> listarMarcasLocal;
        public FormMarcas()
        {
            InitializeComponent();
        }

        private void FormMarcas_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            MarcasNegocio negocio = new MarcasNegocio();
            try
            {
                listarMarcasLocal = negocio.listarMarcas ();
                dgvMarcas.DataSource = listarMarcasLocal;
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
                dgvMarcas.DataSource = listarMarcasLocal;
            }
            else
            {
                if (txtBuscar.Text.Length >= 2)
                {
                    List<Marcas> lista;
                    lista = listarMarcasLocal.FindAll(X => X.Nombre.Contains(txtBuscar.Text));
                    dgvMarcas.DataSource = lista;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dgvMarcas.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgvMarcas.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Marcas marcasLocal;
            MarcasNegocio negocio = new MarcasNegocio();
            try
            {
                marcasLocal = new Marcas();

                marcasLocal.Nombre = txtNombre.Text;

                negocio.agregarMarca(marcasLocal);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Marcas marcaLocal;
            MarcasNegocio negocio = new MarcasNegocio();
            try
            {
                marcaLocal = new Marcas();
                marcaLocal.Id = Convert.ToInt32(txtId.Text);
                marcaLocal.Nombre = txtNombre.Text;

                negocio.EliminarMarca(marcaLocal);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Marcas marcaLocal;
            MarcasNegocio negocio = new MarcasNegocio();
            try
            {
                marcaLocal = new Marcas();
                marcaLocal.Id = Convert.ToInt32(txtId.Text);
                marcaLocal.Nombre = txtNombre.Text;

                negocio.ModificarMarca(marcaLocal);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
