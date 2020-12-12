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
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {
            txtUsuario.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Length>0&&txtUsuario.Text.Length>0)
            {
                Usuarios usuario = new Usuarios();
                UsuariosNegocio negocio = new UsuariosNegocio();

                usuario.NombreUsuario = txtUsuario.Text;
                usuario.Contraseña = txtContraseña.Text;
                usuario.Dni = 0;

                usuario = negocio.IniciarSesion(usuario);
                if (usuario.Dni > 0 && usuario.Permiso > 0)
                {
                    Principal principal = new Principal(usuario);
                    principal.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("DATOS INVALIDOS..");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ADMIN USUARIO EOCAMPO Y CONTRASEÑA 1234 - VENDEDOR USUARIO ALORENZO Y CONTRASEÑA 5678");
        }
    }
}
