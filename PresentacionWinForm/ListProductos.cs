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
    public partial class ListProductos : Form
    {
        List<Producto> local;
        public ListProductos()
        {
            InitializeComponent();
        }

        private void ListProductos_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                local = negocio.ListarInforme();
                dgvProductos.DataSource = local;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
