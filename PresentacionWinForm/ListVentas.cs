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
    public partial class ListVentas : Form
    {
        List<Venta> local;

        public ListVentas()
        {
            InitializeComponent();
        }

        private void btnTodas_Click(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();
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

        private void btnConcluidas_Click(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();
            try
            {
                local = negocio.ListarInformeAltas();
                dgvVentas.DataSource = local;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    

        private void btnSin_Click(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();
            try
            {
                local = negocio.ListarInformeBajas();
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
