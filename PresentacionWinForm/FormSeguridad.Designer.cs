namespace PresentacionWinForm
{
    partial class FormSeguridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeguridad));
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnSeguridad = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.txtnueva = new System.Windows.Forms.TextBox();
            this.lblNueva = new System.Windows.Forms.Label();
            this.txtRepetir = new System.Windows.Forms.TextBox();
            this.lblrepetir = new System.Windows.Forms.Label();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.gbxCambiar = new System.Windows.Forms.GroupBox();
            this.gbxUsuario = new System.Windows.Forms.GroupBox();
            this.cboEmpleados = new System.Windows.Forms.ComboBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.btnagregar = new System.Windows.Forms.Button();
            this.txtUsuarioN = new System.Windows.Forms.TextBox();
            this.txtContraseñaN = new System.Windows.Forms.TextBox();
            this.lblUsuarioN = new System.Windows.Forms.Label();
            this.lblContraseñaN = new System.Windows.Forms.Label();
            this.txtPermiso = new System.Windows.Forms.TextBox();
            this.lblPermiso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.gbxCambiar.SuspendLayout();
            this.gbxUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(940, 1);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 29);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 39;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeguridad
            // 
            this.btnSeguridad.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSeguridad.FlatAppearance.BorderSize = 0;
            this.btnSeguridad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeguridad.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeguridad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSeguridad.Location = new System.Drawing.Point(-596, 0);
            this.btnSeguridad.Margin = new System.Windows.Forms.Padding(5);
            this.btnSeguridad.Name = "btnSeguridad";
            this.btnSeguridad.Size = new System.Drawing.Size(1566, 32);
            this.btnSeguridad.TabIndex = 38;
            this.btnSeguridad.Text = "SEGURIDAD";
            this.btnSeguridad.UseVisualStyleBackColor = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(129, 62);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(193, 23);
            this.txtUsuario.TabIndex = 64;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(28, 98);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(88, 17);
            this.lblContraseña.TabIndex = 63;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(60, 65);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(58, 17);
            this.lblUsuario.TabIndex = 62;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(129, 98);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(193, 23);
            this.txtContraseña.TabIndex = 65;
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnVerificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.Location = new System.Drawing.Point(207, 132);
            this.btnVerificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(115, 28);
            this.btnVerificar.TabIndex = 66;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // txtnueva
            // 
            this.txtnueva.Location = new System.Drawing.Point(94, 32);
            this.txtnueva.Name = "txtnueva";
            this.txtnueva.Size = new System.Drawing.Size(193, 23);
            this.txtnueva.TabIndex = 68;
            // 
            // lblNueva
            // 
            this.lblNueva.AutoSize = true;
            this.lblNueva.Location = new System.Drawing.Point(26, 35);
            this.lblNueva.Name = "lblNueva";
            this.lblNueva.Size = new System.Drawing.Size(55, 17);
            this.lblNueva.TabIndex = 67;
            this.lblNueva.Text = "Nueva:";
            // 
            // txtRepetir
            // 
            this.txtRepetir.Location = new System.Drawing.Point(94, 68);
            this.txtRepetir.Name = "txtRepetir";
            this.txtRepetir.Size = new System.Drawing.Size(193, 23);
            this.txtRepetir.TabIndex = 71;
            // 
            // lblrepetir
            // 
            this.lblrepetir.AutoSize = true;
            this.lblrepetir.Location = new System.Drawing.Point(24, 71);
            this.lblrepetir.Name = "lblrepetir";
            this.lblrepetir.Size = new System.Drawing.Size(57, 17);
            this.lblrepetir.TabIndex = 70;
            this.lblrepetir.Text = "Repetir:";
            // 
            // btnCambiar
            // 
            this.btnCambiar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCambiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.Location = new System.Drawing.Point(172, 105);
            this.btnCambiar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(115, 28);
            this.btnCambiar.TabIndex = 72;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // gbxCambiar
            // 
            this.gbxCambiar.Controls.Add(this.txtRepetir);
            this.gbxCambiar.Controls.Add(this.btnCambiar);
            this.gbxCambiar.Controls.Add(this.lblNueva);
            this.gbxCambiar.Controls.Add(this.txtnueva);
            this.gbxCambiar.Controls.Add(this.lblrepetir);
            this.gbxCambiar.Location = new System.Drawing.Point(31, 174);
            this.gbxCambiar.Name = "gbxCambiar";
            this.gbxCambiar.Size = new System.Drawing.Size(315, 146);
            this.gbxCambiar.TabIndex = 73;
            this.gbxCambiar.TabStop = false;
            this.gbxCambiar.Text = "Cambiar Contraseña:";
            // 
            // gbxUsuario
            // 
            this.gbxUsuario.Controls.Add(this.txtPermiso);
            this.gbxUsuario.Controls.Add(this.lblPermiso);
            this.gbxUsuario.Controls.Add(this.cboEmpleados);
            this.gbxUsuario.Controls.Add(this.lblEmpleado);
            this.gbxUsuario.Controls.Add(this.btnagregar);
            this.gbxUsuario.Controls.Add(this.txtUsuarioN);
            this.gbxUsuario.Controls.Add(this.txtContraseñaN);
            this.gbxUsuario.Controls.Add(this.lblUsuarioN);
            this.gbxUsuario.Controls.Add(this.lblContraseñaN);
            this.gbxUsuario.Location = new System.Drawing.Point(378, 50);
            this.gbxUsuario.Name = "gbxUsuario";
            this.gbxUsuario.Size = new System.Drawing.Size(329, 215);
            this.gbxUsuario.TabIndex = 74;
            this.gbxUsuario.TabStop = false;
            this.gbxUsuario.Text = "Nuevo Usuario:";
            // 
            // cboEmpleados
            // 
            this.cboEmpleados.FormattingEnabled = true;
            this.cboEmpleados.Location = new System.Drawing.Point(115, 27);
            this.cboEmpleados.Name = "cboEmpleados";
            this.cboEmpleados.Size = new System.Drawing.Size(193, 25);
            this.cboEmpleados.TabIndex = 80;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(25, 30);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(79, 17);
            this.lblEmpleado.TabIndex = 75;
            this.lblEmpleado.Text = "Empleado:";
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnagregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnagregar.Location = new System.Drawing.Point(193, 171);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(115, 28);
            this.btnagregar.TabIndex = 79;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // txtUsuarioN
            // 
            this.txtUsuarioN.Location = new System.Drawing.Point(115, 62);
            this.txtUsuarioN.Name = "txtUsuarioN";
            this.txtUsuarioN.Size = new System.Drawing.Size(193, 23);
            this.txtUsuarioN.TabIndex = 77;
            // 
            // txtContraseñaN
            // 
            this.txtContraseñaN.Location = new System.Drawing.Point(115, 97);
            this.txtContraseñaN.Name = "txtContraseñaN";
            this.txtContraseñaN.Size = new System.Drawing.Size(193, 23);
            this.txtContraseñaN.TabIndex = 78;
            // 
            // lblUsuarioN
            // 
            this.lblUsuarioN.AutoSize = true;
            this.lblUsuarioN.Location = new System.Drawing.Point(46, 65);
            this.lblUsuarioN.Name = "lblUsuarioN";
            this.lblUsuarioN.Size = new System.Drawing.Size(58, 17);
            this.lblUsuarioN.TabIndex = 75;
            this.lblUsuarioN.Text = "Usuario:";
            // 
            // lblContraseñaN
            // 
            this.lblContraseñaN.AutoSize = true;
            this.lblContraseñaN.Location = new System.Drawing.Point(16, 100);
            this.lblContraseñaN.Name = "lblContraseñaN";
            this.lblContraseñaN.Size = new System.Drawing.Size(88, 17);
            this.lblContraseñaN.TabIndex = 76;
            this.lblContraseñaN.Text = "Contraseña:";
            // 
            // txtPermiso
            // 
            this.txtPermiso.Location = new System.Drawing.Point(115, 133);
            this.txtPermiso.Name = "txtPermiso";
            this.txtPermiso.Size = new System.Drawing.Size(193, 23);
            this.txtPermiso.TabIndex = 82;
            // 
            // lblPermiso
            // 
            this.lblPermiso.AutoSize = true;
            this.lblPermiso.Location = new System.Drawing.Point(42, 136);
            this.lblPermiso.Name = "lblPermiso";
            this.lblPermiso.Size = new System.Drawing.Size(62, 17);
            this.lblPermiso.TabIndex = 81;
            this.lblPermiso.Text = "Permiso:";
            // 
            // FormSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 566);
            this.Controls.Add(this.gbxUsuario);
            this.Controls.Add(this.gbxCambiar);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnSeguridad);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSeguridad";
            this.Text = "FormSeguridad";
            this.Load += new System.EventHandler(this.FormSeguridad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.gbxCambiar.ResumeLayout(false);
            this.gbxCambiar.PerformLayout();
            this.gbxUsuario.ResumeLayout(false);
            this.gbxUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Button btnSeguridad;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.TextBox txtnueva;
        private System.Windows.Forms.Label lblNueva;
        private System.Windows.Forms.TextBox txtRepetir;
        private System.Windows.Forms.Label lblrepetir;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.GroupBox gbxCambiar;
        private System.Windows.Forms.GroupBox gbxUsuario;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.TextBox txtUsuarioN;
        private System.Windows.Forms.TextBox txtContraseñaN;
        private System.Windows.Forms.Label lblUsuarioN;
        private System.Windows.Forms.Label lblContraseñaN;
        private System.Windows.Forms.ComboBox cboEmpleados;
        private System.Windows.Forms.TextBox txtPermiso;
        private System.Windows.Forms.Label lblPermiso;
    }
}