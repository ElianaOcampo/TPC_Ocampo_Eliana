namespace PresentacionWinForm
{
    partial class FormEmpleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmpleados));
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.btnBuscarDni = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbxTelefono = new System.Windows.Forms.GroupBox();
            this.txtTipoTel = new System.Windows.Forms.TextBox();
            this.txtNumTel = new System.Windows.Forms.TextBox();
            this.txtIdTel = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.gbxDatosPer = new System.Windows.Forms.GroupBox();
            this.txtCuil = new System.Windows.Forms.TextBox();
            this.lblCuil = new System.Windows.Forms.Label();
            this.cbbtipoempleado = new System.Windows.Forms.ComboBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lvlTipo = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnBuscarApe = new System.Windows.Forms.Button();
            this.txtBuscarApe = new System.Windows.Forms.TextBox();
            this.gbxdireccion = new System.Windows.Forms.GroupBox();
            this.txtlocalidad = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.CodPostal = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblIdDom = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lvlNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.gbxTelefono.SuspendLayout();
            this.gbxDatosPer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.gbxdireccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(16, 262);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.Size = new System.Drawing.Size(898, 228);
            this.dgvEmpleados.TabIndex = 42;
            this.dgvEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellContentClick);
            // 
            // btnBuscarDni
            // 
            this.btnBuscarDni.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnBuscarDni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBuscarDni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDni.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDni.Location = new System.Drawing.Point(542, 225);
            this.btnBuscarDni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscarDni.Name = "btnBuscarDni";
            this.btnBuscarDni.Size = new System.Drawing.Size(88, 28);
            this.btnBuscarDni.TabIndex = 41;
            this.btnBuscarDni.Text = "Buscar DNI";
            this.btnBuscarDni.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(388, 229);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(147, 23);
            this.txtBuscar.TabIndex = 40;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(263, 225);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(115, 28);
            this.btnEliminar.TabIndex = 39;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(137, 225);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(115, 28);
            this.btnModificar.TabIndex = 38;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(14, 225);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(115, 28);
            this.btnAgregar.TabIndex = 37;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbxTelefono
            // 
            this.gbxTelefono.Controls.Add(this.txtTipoTel);
            this.gbxTelefono.Controls.Add(this.txtNumTel);
            this.gbxTelefono.Controls.Add(this.txtIdTel);
            this.gbxTelefono.Controls.Add(this.lblId);
            this.gbxTelefono.Controls.Add(this.lblNumero);
            this.gbxTelefono.Controls.Add(this.lblTipo);
            this.gbxTelefono.Location = new System.Drawing.Point(627, 37);
            this.gbxTelefono.Name = "gbxTelefono";
            this.gbxTelefono.Size = new System.Drawing.Size(284, 120);
            this.gbxTelefono.TabIndex = 35;
            this.gbxTelefono.TabStop = false;
            this.gbxTelefono.Text = "Teléfono:";
            // 
            // txtTipoTel
            // 
            this.txtTipoTel.Location = new System.Drawing.Point(77, 55);
            this.txtTipoTel.Name = "txtTipoTel";
            this.txtTipoTel.Size = new System.Drawing.Size(155, 23);
            this.txtTipoTel.TabIndex = 17;
            // 
            // txtNumTel
            // 
            this.txtNumTel.Location = new System.Drawing.Point(77, 22);
            this.txtNumTel.Name = "txtNumTel";
            this.txtNumTel.Size = new System.Drawing.Size(155, 23);
            this.txtNumTel.TabIndex = 16;
            // 
            // txtIdTel
            // 
            this.txtIdTel.Location = new System.Drawing.Point(77, 86);
            this.txtIdTel.Name = "txtIdTel";
            this.txtIdTel.Size = new System.Drawing.Size(155, 23);
            this.txtIdTel.TabIndex = 15;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(45, 89);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(25, 17);
            this.lblId.TabIndex = 14;
            this.lblId.Text = "ID:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(6, 25);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(64, 17);
            this.lblNumero.TabIndex = 12;
            this.lblNumero.Text = "Número:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(32, 57);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(38, 17);
            this.lblTipo.TabIndex = 13;
            this.lblTipo.Text = "Tipo:";
            // 
            // gbxDatosPer
            // 
            this.gbxDatosPer.Controls.Add(this.txtCuil);
            this.gbxDatosPer.Controls.Add(this.lblCuil);
            this.gbxDatosPer.Controls.Add(this.cbbtipoempleado);
            this.gbxDatosPer.Controls.Add(this.txtMail);
            this.gbxDatosPer.Controls.Add(this.txtDni);
            this.gbxDatosPer.Controls.Add(this.txtNombre);
            this.gbxDatosPer.Controls.Add(this.lvlTipo);
            this.gbxDatosPer.Controls.Add(this.txtApellido);
            this.gbxDatosPer.Controls.Add(this.lblDni);
            this.gbxDatosPer.Controls.Add(this.lblApellido);
            this.gbxDatosPer.Controls.Add(this.lblNombre);
            this.gbxDatosPer.Controls.Add(this.lblMail);
            this.gbxDatosPer.Location = new System.Drawing.Point(14, 37);
            this.gbxDatosPer.Name = "gbxDatosPer";
            this.gbxDatosPer.Size = new System.Drawing.Size(600, 120);
            this.gbxDatosPer.TabIndex = 34;
            this.gbxDatosPer.TabStop = false;
            this.gbxDatosPer.Text = "Datos Personales";
            // 
            // txtCuil
            // 
            this.txtCuil.Location = new System.Drawing.Point(44, 86);
            this.txtCuil.Name = "txtCuil";
            this.txtCuil.Size = new System.Drawing.Size(198, 23);
            this.txtCuil.TabIndex = 28;
            // 
            // lblCuil
            // 
            this.lblCuil.AutoSize = true;
            this.lblCuil.Location = new System.Drawing.Point(3, 89);
            this.lblCuil.Name = "lblCuil";
            this.lblCuil.Size = new System.Drawing.Size(40, 17);
            this.lblCuil.TabIndex = 27;
            this.lblCuil.Text = "CUIL:";
            // 
            // cbbtipoempleado
            // 
            this.cbbtipoempleado.FormattingEnabled = true;
            this.cbbtipoempleado.Location = new System.Drawing.Point(380, 86);
            this.cbbtipoempleado.Name = "cbbtipoempleado";
            this.cbbtipoempleado.Size = new System.Drawing.Size(169, 25);
            this.cbbtipoempleado.TabIndex = 26;
            this.cbbtipoempleado.SelectedIndexChanged += new System.EventHandler(this.cbbtipoempleado_SelectedIndexChanged);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(44, 54);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(198, 23);
            this.txtMail.TabIndex = 25;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(44, 22);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(198, 23);
            this.txtDni.TabIndex = 24;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(319, 54);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(258, 23);
            this.txtNombre.TabIndex = 11;
            // 
            // lvlTipo
            // 
            this.lvlTipo.AutoSize = true;
            this.lvlTipo.Location = new System.Drawing.Point(248, 89);
            this.lvlTipo.Name = "lvlTipo";
            this.lvlTipo.Size = new System.Drawing.Size(131, 17);
            this.lvlTipo.TabIndex = 22;
            this.lvlTipo.Text = "Tipo de empleado:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(319, 22);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(258, 23);
            this.txtApellido.TabIndex = 10;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(8, 25);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(35, 17);
            this.lblDni.TabIndex = 8;
            this.lblDni.Text = "DNI:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(248, 25);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(65, 17);
            this.lblApellido.TabIndex = 9;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(248, 57);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 17);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(5, 57);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(38, 17);
            this.lblMail.TabIndex = 11;
            this.lblMail.Text = "Mail:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(943, -2);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 29);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 33;
            this.btnCerrar.TabStop = false;
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleados.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEmpleados.Location = new System.Drawing.Point(-594, -2);
            this.btnEmpleados.Margin = new System.Windows.Forms.Padding(5);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(1566, 32);
            this.btnEmpleados.TabIndex = 32;
            this.btnEmpleados.Text = "EMPLEADOS";
            this.btnEmpleados.UseVisualStyleBackColor = false;
            // 
            // btnBuscarApe
            // 
            this.btnBuscarApe.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnBuscarApe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBuscarApe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarApe.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarApe.Location = new System.Drawing.Point(801, 226);
            this.btnBuscarApe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscarApe.Name = "btnBuscarApe";
            this.btnBuscarApe.Size = new System.Drawing.Size(110, 28);
            this.btnBuscarApe.TabIndex = 44;
            this.btnBuscarApe.Text = "Buscar Apellido";
            this.btnBuscarApe.UseVisualStyleBackColor = false;
            // 
            // txtBuscarApe
            // 
            this.txtBuscarApe.Location = new System.Drawing.Point(637, 228);
            this.txtBuscarApe.Name = "txtBuscarApe";
            this.txtBuscarApe.Size = new System.Drawing.Size(157, 23);
            this.txtBuscarApe.TabIndex = 43;
            this.txtBuscarApe.TextChanged += new System.EventHandler(this.txtBuscarApe_TextChanged);
            // 
            // gbxdireccion
            // 
            this.gbxdireccion.Controls.Add(this.txtlocalidad);
            this.gbxdireccion.Controls.Add(this.lblLocalidad);
            this.gbxdireccion.Controls.Add(this.txtCodPostal);
            this.gbxdireccion.Controls.Add(this.txtNumero);
            this.gbxdireccion.Controls.Add(this.txtCalle);
            this.gbxdireccion.Controls.Add(this.CodPostal);
            this.gbxdireccion.Controls.Add(this.txtId);
            this.gbxdireccion.Controls.Add(this.lblIdDom);
            this.gbxdireccion.Controls.Add(this.lblCalle);
            this.gbxdireccion.Controls.Add(this.lvlNum);
            this.gbxdireccion.Location = new System.Drawing.Point(14, 161);
            this.gbxdireccion.Name = "gbxdireccion";
            this.gbxdireccion.Size = new System.Drawing.Size(897, 55);
            this.gbxdireccion.TabIndex = 45;
            this.gbxdireccion.TabStop = false;
            this.gbxdireccion.Text = "Dirección:";
            // 
            // txtlocalidad
            // 
            this.txtlocalidad.Location = new System.Drawing.Point(712, 22);
            this.txtlocalidad.Name = "txtlocalidad";
            this.txtlocalidad.Size = new System.Drawing.Size(156, 23);
            this.txtlocalidad.TabIndex = 23;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(634, 26);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(77, 17);
            this.lblLocalidad.TabIndex = 22;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.Location = new System.Drawing.Point(564, 23);
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(56, 23);
            this.txtCodPostal.TabIndex = 21;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(391, 23);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(56, 23);
            this.txtNumero.TabIndex = 18;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(134, 23);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(192, 23);
            this.txtCalle.TabIndex = 17;
            // 
            // CodPostal
            // 
            this.CodPostal.AutoSize = true;
            this.CodPostal.Location = new System.Drawing.Point(458, 26);
            this.CodPostal.Name = "CodPostal";
            this.CodPostal.Size = new System.Drawing.Size(105, 17);
            this.CodPostal.TabIndex = 20;
            this.CodPostal.Text = "Código Postal:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(34, 23);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(46, 23);
            this.txtId.TabIndex = 16;
            this.txtId.Text = "0";
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIdDom
            // 
            this.lblIdDom.AutoSize = true;
            this.lblIdDom.Location = new System.Drawing.Point(12, 26);
            this.lblIdDom.Name = "lblIdDom";
            this.lblIdDom.Size = new System.Drawing.Size(25, 17);
            this.lblIdDom.TabIndex = 15;
            this.lblIdDom.Text = "ID:";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(91, 26);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(46, 17);
            this.lblCalle.TabIndex = 16;
            this.lblCalle.Text = "Calle:";
            // 
            // lvlNum
            // 
            this.lvlNum.AutoSize = true;
            this.lvlNum.Location = new System.Drawing.Point(338, 26);
            this.lvlNum.Name = "lvlNum";
            this.lvlNum.Size = new System.Drawing.Size(50, 17);
            this.lvlNum.TabIndex = 17;
            this.lvlNum.Text = "Altura:";
            // 
            // FormEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 566);
            this.Controls.Add(this.gbxdireccion);
            this.Controls.Add(this.btnBuscarApe);
            this.Controls.Add(this.txtBuscarApe);
            this.Controls.Add(this.dgvEmpleados);
            this.Controls.Add(this.btnBuscarDni);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gbxTelefono);
            this.Controls.Add(this.gbxDatosPer);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEmpleados);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEmpleados";
            this.Text = "FormEmpleados";
            this.Load += new System.EventHandler(this.FormEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.gbxTelefono.ResumeLayout(false);
            this.gbxTelefono.PerformLayout();
            this.gbxDatosPer.ResumeLayout(false);
            this.gbxDatosPer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.gbxdireccion.ResumeLayout(false);
            this.gbxdireccion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Button btnBuscarDni;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gbxTelefono;
        private System.Windows.Forms.TextBox txtNumTel;
        private System.Windows.Forms.TextBox txtIdTel;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.GroupBox gbxDatosPer;
        private System.Windows.Forms.ComboBox cbbtipoempleado;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lvlTipo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.TextBox txtCuil;
        private System.Windows.Forms.Label lblCuil;
        private System.Windows.Forms.TextBox txtTipoTel;
        private System.Windows.Forms.Button btnBuscarApe;
        private System.Windows.Forms.TextBox txtBuscarApe;
        private System.Windows.Forms.GroupBox gbxdireccion;
        private System.Windows.Forms.TextBox txtlocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.TextBox txtCodPostal;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label CodPostal;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblIdDom;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lvlNum;
    }
}