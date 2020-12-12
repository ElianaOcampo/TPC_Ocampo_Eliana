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
    public partial class FormSeguridad : Form
    {
        public Usuarios usuarioLocal = new Usuarios();

        public FormSeguridad()
        {
            InitializeComponent();
        }

        private void FormSeguridad_Load(object sender, EventArgs e)
        {
            txtUsuario.CharacterCasing = CharacterCasing.Upper;
            txtUsuarioN.CharacterCasing = CharacterCasing.Upper;

            gbxUsuario.Enabled = false;
            gbxCambiar.Enabled = false;

            EmpleadoNegocio negocioE = new EmpleadoNegocio();
            cboEmpleados.DataSource = negocioE.ListarEmpleadosSinUsuario();
            cboEmpleados.DisplayMember = "APELLIDO";
            cboEmpleados.ValueMember = "DNI";
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            UsuariosNegocio negocio = new UsuariosNegocio();

            usuario.NombreUsuario = txtUsuario.Text;
            usuario.Contraseña = txtContraseña.Text;
            usuario.Dni = 0;

            usuario = negocio.IniciarSesion(usuario);
            if (usuario.Dni > 0 && usuario.Permiso > 0)
            {
                gbxCambiar.Enabled = true;
                if(usuario.Permiso>1)
                {
                    gbxUsuario.Enabled = true;
                    usuarioLocal.NombreUsuario = txtUsuario.Text;
                    usuarioLocal.Dni = usuario.Dni;
                }
            }
            else
                MessageBox.Show("DATOS INVALIDOS..");
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (txtnueva.Text.Equals(txtRepetir.Text))
            {
                usuarioLocal.Contraseña = txtnueva.Text;
                UsuariosNegocio negocio = new UsuariosNegocio();
                negocio.ModificarContraseña(usuarioLocal);
            }
            else
                MessageBox.Show("LA CONTRASEÑA NO COINCIDE");
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (cboEmpleados.SelectedIndex > -1 && txtUsuarioN.Text.Length > 0 && txtContraseñaN.Text.Length > 0)
            {
                Usuarios nuevo = new Usuarios();
                nuevo.NombreUsuario = txtUsuarioN.Text;
                nuevo.Contraseña = txtContraseñaN.Text;
                nuevo.Dni = Convert.ToInt32(cboEmpleados.SelectedValue);
                UsuariosNegocio negocio = new UsuariosNegocio();
                negocio.AgregarUsuario(nuevo);

                EmpleadoNegocio negocioE = new EmpleadoNegocio();
                cboEmpleados.DataSource = negocioE.ListarEmpleadosSinUsuario();
                cboEmpleados.DisplayMember = "APELLIDO";
                cboEmpleados.ValueMember = "DNI";

                txtContraseñaN.Text = "";
                txtUsuarioN.Text = "";
                txtPermiso.Text = "";
                cboEmpleados.SelectedIndex = -1;

                MessageBox.Show("USUARIO AGREGADO CORRECTAMENTE!!");
            }
            else
                MessageBox.Show("COMPLETE TODOS LOS CAMPOS");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
