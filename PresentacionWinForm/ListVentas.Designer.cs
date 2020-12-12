namespace PresentacionWinForm
{
    partial class ListVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.btnTodas = new System.Windows.Forms.Button();
            this.btnSin = new System.Windows.Forms.Button();
            this.btnConcluidas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(12, 53);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.Size = new System.Drawing.Size(863, 342);
            this.dgvVentas.TabIndex = 1;
            // 
            // btnTodas
            // 
            this.btnTodas.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnTodas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTodas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodas.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodas.Location = new System.Drawing.Point(13, 14);
            this.btnTodas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Size = new System.Drawing.Size(184, 28);
            this.btnTodas.TabIndex = 39;
            this.btnTodas.Text = "Todas las Ventas";
            this.btnTodas.UseVisualStyleBackColor = false;
            this.btnTodas.Click += new System.EventHandler(this.btnTodas_Click);
            // 
            // btnSin
            // 
            this.btnSin.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSin.Location = new System.Drawing.Point(442, 14);
            this.btnSin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSin.Name = "btnSin";
            this.btnSin.Size = new System.Drawing.Size(184, 28);
            this.btnSin.TabIndex = 40;
            this.btnSin.Text = "Solo Sin Concluir";
            this.btnSin.UseVisualStyleBackColor = false;
            this.btnSin.Click += new System.EventHandler(this.btnSin_Click);
            // 
            // btnConcluidas
            // 
            this.btnConcluidas.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnConcluidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConcluidas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnConcluidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluidas.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConcluidas.Location = new System.Drawing.Point(227, 14);
            this.btnConcluidas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConcluidas.Name = "btnConcluidas";
            this.btnConcluidas.Size = new System.Drawing.Size(184, 28);
            this.btnConcluidas.TabIndex = 41;
            this.btnConcluidas.Text = "Solo Concluidas";
            this.btnConcluidas.UseVisualStyleBackColor = false;
            this.btnConcluidas.Click += new System.EventHandler(this.btnConcluidas_Click);
            // 
            // ListVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.btnConcluidas);
            this.Controls.Add(this.btnSin);
            this.Controls.Add(this.btnTodas);
            this.Controls.Add(this.dgvVentas);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListVentas";
            this.Text = "ListVentas";
            this.Load += new System.EventHandler(this.ListVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Button btnTodas;
        private System.Windows.Forms.Button btnSin;
        private System.Windows.Forms.Button btnConcluidas;
    }
}