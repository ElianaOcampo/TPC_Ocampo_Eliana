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
    public partial class FormClientes : Form
    {
        List<Cliente> listarClientesLocal;
        public FormClientes()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtIdTel.Enabled = false;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtApellido.CharacterCasing = CharacterCasing.Upper;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtMail.CharacterCasing = CharacterCasing.Upper;
            txtTipoTel.CharacterCasing = CharacterCasing.Upper;
            txtlocalidad.CharacterCasing = CharacterCasing.Upper;
            txtCalle.CharacterCasing = CharacterCasing.Upper;
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                listarClientesLocal = negocio.listarClientes();
                dgvClientes.DataSource = listarClientesLocal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDni.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                txtApellido.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtMail.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();

                ClienteNegocio negocio = new ClienteNegocio();

                Telefono telefono = new Telefono();
                telefono = negocio.buscarTelefono(Convert.ToInt32(txtDni.Text));
                txtIdTel.Text = telefono.Id.ToString();
                txtNumTel.Text = telefono.Numero.ToString();
                txtTipoTel.Text = telefono.TipoDeTelefono;

                Domicilio domicilio = new Domicilio();
                domicilio = negocio.buscarDomicilio(Convert.ToInt32(txtDni.Text));
                txtId.Text = domicilio.Id.ToString();
                txtCalle.Text = domicilio.Calle;
                txtNumero.Text = domicilio.Altura.ToString();
                txtCodPostal.Text = domicilio.CodigoPostal.ToString();
                txtlocalidad.Text = domicilio.Localidad;

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
                dgvClientes.DataSource = listarClientesLocal;
            }
            else
            {
                if (txtBuscar.Text.Length >= 2)
                {
                    List<Cliente> lista;
                    lista = listarClientesLocal.FindAll(X => X.DNI.ToString().Contains(txtBuscar.Text));
                    dgvClientes.DataSource = lista;
                }
            }
        }

        private void txtBuscarApe_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarApe.Text == "")
            {
                dgvClientes.DataSource = listarClientesLocal;
            }
            else
            {
                if (txtBuscarApe.Text.Length >= 2)
                {
                    List<Cliente> lista;
                    lista = listarClientesLocal.FindAll(X => X.Apellido.Contains(txtBuscarApe.Text));
                    dgvClientes.DataSource = lista;
                }
            }
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();

            if (txtDni.Text.Length > 0 && txtApellido.Text.Length > 0 && txtNombre.Text.Length > 0 && txtMail.Text.Length > 0 && txtNumTel.Text.Length > 0 && txtTipoTel.Text.Length > 0 && txtCalle.Text.Length > 0 && txtNumero.Text.Length > 0 && txtCodPostal.Text.Length > 0 && txtlocalidad.Text.Length > 0)
            {
                cliente.DNI = Convert.ToInt32(txtDni.Text);
                cliente.Apellido = txtApellido.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Mail = txtMail.Text;
                cliente.telefono = new Telefono();
                cliente.telefono.Id = Convert.ToInt32(txtIdTel.Text);
                cliente.telefono.Numero = Convert.ToInt32(txtNumTel.Text);
                cliente.telefono.TipoDeTelefono = txtTipoTel.Text;
                cliente.domicilio = new Domicilio();
                cliente.domicilio.Id = Convert.ToInt32(txtId.Text);
                cliente.domicilio.Calle = txtCalle.Text;
                cliente.domicilio.Altura = Convert.ToInt32(txtNumero.Text);
                cliente.domicilio.CodigoPostal = Convert.ToInt32(txtCodPostal.Text);
                cliente.domicilio.Localidad = txtlocalidad.Text;

                negocio.AgregarCiente(cliente);

                cargarGrilla();
            }
            else
                MessageBox.Show("DEBEN ESTAR TODOS LOS CAMPOS COMPLETOS!!");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente local;
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                local = new Cliente();
                local.DNI = Convert.ToInt32(txtDni.Text);

                negocio.EliminarCliente(local);
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
            Cliente cliente = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();

            if (txtDni.Text.Length > 0 && txtApellido.Text.Length > 0 && txtNombre.Text.Length > 0 && txtMail.Text.Length > 0 && txtNumTel.Text.Length > 0 && txtTipoTel.Text.Length > 0 && txtCalle.Text.Length > 0 && txtNumero.Text.Length > 0 && txtCodPostal.Text.Length > 0 && txtlocalidad.Text.Length > 0)
            {
                cliente.DNI = Convert.ToInt32(txtDni.Text);
                cliente.Apellido = txtApellido.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Mail = txtMail.Text;
                cliente.telefono = new Telefono();
                cliente.telefono.Id = Convert.ToInt32(txtIdTel.Text);
                cliente.telefono.Numero = Convert.ToInt32(txtNumTel.Text);
                cliente.telefono.TipoDeTelefono = txtTipoTel.Text;
                cliente.domicilio = new Domicilio();
                cliente.domicilio.Id = Convert.ToInt32(txtId.Text);
                cliente.domicilio.Calle = txtCalle.Text;
                cliente.domicilio.Altura = Convert.ToInt32(txtNumero.Text);
                cliente.domicilio.CodigoPostal = Convert.ToInt32(txtCodPostal.Text);
                cliente.domicilio.Localidad = txtlocalidad.Text;

                if (cliente.telefono.Id > 0 || cliente.domicilio.Id > 0)
                    negocio.ModificarCiente(cliente);
                else
                    MessageBox.Show("EL CLIENTE NO EXISTE!! INTENTE CON AGREGAR");

                cargarGrilla();
            }
            else
                MessageBox.Show("NO ESTAN TODOS LOS CAMPOS COMPLETOS!!");

        }
        
    }
}
