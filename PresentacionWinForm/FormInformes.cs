using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionWinForm
{
    public partial class FormInformes : Form
    {
        public FormInformes()
        {
            InitializeComponent();
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.PanelContenedorListado.Controls.Count > 0)
                this.PanelContenedorListado.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedorListado.Controls.Add(fh);
            this.PanelContenedorListado.Tag = fh;
            fh.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListProductos());
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListVentas());
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListCompras());
        }
    }
}
