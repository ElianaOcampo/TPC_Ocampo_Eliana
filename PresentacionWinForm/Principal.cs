using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TPC_Ocampo;
using Negocio;

namespace PresentacionWinForm
{
    public partial class Principal : Form
    {
        public Principal(Usuarios usuario)
        {
            InitializeComponent();
            AbrirFormInPanel(new Inicio());
            lblUsuarioSesion.Text = usuario.NombreUsuario;
            if (usuario.Permiso == 1)
            {
                btnCategorias.Hide();
                btnProductos.Hide();
                btnProveedores.Hide();
                btnMarcas.Hide();
                btnInformes.Hide();
                btnEmpleados.Hide();
                btnCompras.Hide();
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 230) MenuVertical.Width = 50;
            else MenuVertical.Width = 230;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormProductos());
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormMarcas());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormCategorias());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Inicio());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormClientes());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormEmpleados());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormProveedores());
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormVentas());
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormSeguridad());
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormInformes());
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormCompras());
        }
    }
}
