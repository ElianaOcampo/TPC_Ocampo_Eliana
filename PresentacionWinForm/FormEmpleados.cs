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
    public partial class FormEmpleados : Form
    {
        List<Empleado> listarEmpleadosLocal;
        List<String> listarTipos;
        public FormEmpleados()
        {
            InitializeComponent();
        }

        private void cbbtipoempleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtIdTel.Enabled = false;
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            listarTipos = negocio.listarTipos();
            cbbtipoempleado.DataSource = listarTipos;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtCalle.CharacterCasing = CharacterCasing.Upper;
            txtCalle.CharacterCasing = CharacterCasing.Upper;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtApellido.CharacterCasing = CharacterCasing.Upper;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtMail.CharacterCasing = CharacterCasing.Upper;
            txtTipoTel.CharacterCasing = CharacterCasing.Upper;
            txtlocalidad.CharacterCasing = CharacterCasing.Upper;
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            try
            {
                listarEmpleadosLocal = negocio.listarEmpleados();
                dgvEmpleados.DataSource = listarEmpleadosLocal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDni.Text = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
                txtApellido.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
                txtCuil.Text = dgvEmpleados.CurrentRow.Cells[4].Value.ToString();
                txtMail.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
                cbbtipoempleado.SelectedIndex = cbbtipoempleado.FindString(dgvEmpleados.CurrentRow.Cells[5].Value.ToString());

                EmpleadoNegocio negocio = new EmpleadoNegocio();

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
            txtCalle.CharacterCasing = CharacterCasing.Upper;
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
                dgvEmpleados.DataSource = listarEmpleadosLocal;
            }
            else
            {
                if (txtBuscar.Text.Length >= 2)
                {
                    List<Empleado> lista;
                    lista = listarEmpleadosLocal.FindAll(X => X.DNI.ToString().Contains(txtBuscar.Text));
                    dgvEmpleados.DataSource = lista;
                }
            }
        }

        private void txtBuscarApe_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarApe.Text == "")
            {
                dgvEmpleados.DataSource = listarEmpleadosLocal;
            }
            else
            {
                if (txtBuscarApe.Text.Length >= 2)
                {
                    List<Empleado> lista;
                    lista = listarEmpleadosLocal.FindAll(X => X.Apellido.Contains(txtBuscarApe.Text));
                    dgvEmpleados.DataSource = lista;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Empleado local;
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            try
            {
                local = new Empleado();
                local.DNI = Convert.ToInt32(txtDni.Text);

                negocio.EliminarEmpleado(local);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Empleado cliente = new Empleado();
            EmpleadoNegocio negocio = new EmpleadoNegocio();

            if (txtDni.Text.Length > 0 && txtApellido.Text.Length > 0 && txtNombre.Text.Length > 0 && txtMail.Text.Length > 0 && txtNumTel.Text.Length > 0 && txtTipoTel.Text.Length > 0 && txtCalle.Text.Length > 0 && txtNumero.Text.Length > 0 && txtCodPostal.Text.Length > 0 && txtlocalidad.Text.Length > 0 && txtCuil.Text.Length>0)
            {
                cliente.DNI = Convert.ToInt32(txtDni.Text);
                cliente.Apellido = txtApellido.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Mail = txtMail.Text;
                cliente.CUIL = Convert.ToInt64(txtCuil.Text);
                if (cbbtipoempleado.SelectedItem.ToString() == "GERENTE") cliente.Tipo = "GERENTE";
                if (cbbtipoempleado.SelectedItem.ToString() == "ENCARGADO") cliente.Tipo = "ENCARGADO";
                if (cbbtipoempleado.SelectedItem.ToString() == "VENDEDOR") cliente.Tipo = "VENDEDOR";
                cliente.telefono = new Telefono();
                cliente.telefono.Numero = Convert.ToInt32(txtNumTel.Text);
                cliente.telefono.TipoDeTelefono = txtTipoTel.Text;
                cliente.domicilio = new Domicilio();
                cliente.domicilio.Calle = txtCalle.Text;
                cliente.domicilio.Altura = Convert.ToInt32(txtNumero.Text);
                cliente.domicilio.CodigoPostal = Convert.ToInt32(txtCodPostal.Text);
                cliente.domicilio.Localidad = txtlocalidad.Text;

                negocio.AgregarEmpleado(cliente);

                cargarGrilla();
            }
            else
                MessageBox.Show("DEBEN ESTAR TODOS LOS CAMPOS COMPLETOS!!");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Empleado cliente = new Empleado();
            EmpleadoNegocio negocio = new EmpleadoNegocio();

            if (txtDni.Text.Length > 0 && txtApellido.Text.Length > 0 && txtNombre.Text.Length > 0 && txtMail.Text.Length > 0 && txtNumTel.Text.Length > 0 && txtTipoTel.Text.Length > 0 && txtCalle.Text.Length > 0 && txtNumero.Text.Length > 0 && txtCodPostal.Text.Length > 0 && txtlocalidad.Text.Length > 0 && txtCuil.Text.Length > 0)
            {
                cliente.DNI = Convert.ToInt32(txtDni.Text);
                cliente.Apellido = txtApellido.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Mail = txtMail.Text;
                cliente.CUIL = Convert.ToInt64(txtCuil.Text);
                if (cbbtipoempleado.SelectedItem.ToString() == "GERENTE") cliente.Tipo = "GERENTE";
                if (cbbtipoempleado.SelectedItem.ToString() == "ENCARGADO") cliente.Tipo = "ENCARGADO";
                if (cbbtipoempleado.SelectedItem.ToString() == "VENDEDOR") cliente.Tipo = "VENDEDOR";
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
                    negocio.ModificarEmpleado(cliente);
                else
                    MessageBox.Show("EL EMPLEADO NO EXISTE!! INTENTE CON AGREGAR");

                cargarGrilla();
            }
            else
                MessageBox.Show("DEBEN ESTAR TODOS LOS CAMPOS COMPLETOS!!");
        }
    }
}
