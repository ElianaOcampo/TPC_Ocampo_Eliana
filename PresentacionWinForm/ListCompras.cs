using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPC_Ocampo;
using Negocio;

namespace PresentacionWinForm
{
    public partial class ListCompras : Form
    {
        List<Compra> local;

        public ListCompras()
        {
            InitializeComponent();
            CargarGrilla();
        }

        public void CargarGrilla()
        {
            ComprasNegocio negocio = new ComprasNegocio();
            try
            {
                local = negocio.ListarInforme();
                dgvVentas.DataSource = local;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ListVentas_Load(object sender, EventArgs e)
        {

        }
    }
}
