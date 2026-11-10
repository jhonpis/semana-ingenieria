namespace el_amparo
{
    partial class FrmMascota
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
            this.lbCodigo = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.IdRaza = new System.Windows.Forms.Label();
            this.lbIngreso = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.txld = new System.Windows.Forms.TextBox();
            this.txDescricion = new System.Windows.Forms.TextBox();
            this.txNombre = new System.Windows.Forms.TextBox();
            this.cbRaza = new System.Windows.Forms.ComboBox();
            this.dtIngreso = new System.Windows.Forms.DateTimePicker();
            this.btNuevo = new System.Windows.Forms.Button();
            this.btCargar = new System.Windows.Forms.Button();
            this.btActuzalizar = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btRetirar = new System.Windows.Forms.Button();
            this.grMascotas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grMascotas)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(22, 13);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(51, 16);
            this.lbCodigo.TabIndex = 0;
            this.lbCodigo.Text = "Codigo";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(22, 59);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(56, 16);
            this.lbNombre.TabIndex = 1;
            this.lbNombre.Text = "Nombre";
            // 
            // IdRaza
            // 
            this.IdRaza.AutoSize = true;
            this.IdRaza.Location = new System.Drawing.Point(22, 105);
            this.IdRaza.Name = "IdRaza";
            this.IdRaza.Size = new System.Drawing.Size(39, 16);
            this.IdRaza.TabIndex = 2;
            this.IdRaza.Text = "Raza";
            // 
            // lbIngreso
            // 
            this.lbIngreso.AutoSize = true;
            this.lbIngreso.Location = new System.Drawing.Point(22, 155);
            this.lbIngreso.Name = "lbIngreso";
            this.lbIngreso.Size = new System.Drawing.Size(52, 16);
            this.lbIngreso.TabIndex = 3;
            this.lbIngreso.Text = "ingreso";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(22, 199);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(79, 16);
            this.lbDescripcion.TabIndex = 4;
            this.lbDescripcion.Text = "Descripcion";
            // 
            // txld
            // 
            this.txld.Location = new System.Drawing.Point(89, 6);
            this.txld.Name = "txld";
            this.txld.ReadOnly = true;
            this.txld.Size = new System.Drawing.Size(100, 22);
            this.txld.TabIndex = 5;
            // 
            // txDescricion
            // 
            this.txDescricion.Location = new System.Drawing.Point(110, 193);
            this.txDescricion.Multiline = true;
            this.txDescricion.Name = "txDescricion";
            this.txDescricion.ReadOnly = true;
            this.txDescricion.Size = new System.Drawing.Size(300, 72);
            this.txDescricion.TabIndex = 6;
            // 
            // txNombre
            // 
            this.txNombre.Location = new System.Drawing.Point(89, 59);
            this.txNombre.Name = "txNombre";
            this.txNombre.Size = new System.Drawing.Size(200, 22);
            this.txNombre.TabIndex = 7;
            // 
            // cbRaza
            // 
            this.cbRaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRaza.FormattingEnabled = true;
            this.cbRaza.Location = new System.Drawing.Point(89, 102);
            this.cbRaza.Name = "cbRaza";
            this.cbRaza.Size = new System.Drawing.Size(121, 24);
            this.cbRaza.TabIndex = 8;
            // 
            // dtIngreso
            // 
            this.dtIngreso.Location = new System.Drawing.Point(98, 155);
            this.dtIngreso.Name = "dtIngreso";
            this.dtIngreso.Size = new System.Drawing.Size(200, 22);
            this.dtIngreso.TabIndex = 9;
            // 
            // btNuevo
            // 
            this.btNuevo.Location = new System.Drawing.Point(485, 6);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(75, 23);
            this.btNuevo.TabIndex = 10;
            this.btNuevo.Text = "Ingresar";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // btCargar
            // 
            this.btCargar.Location = new System.Drawing.Point(485, 199);
            this.btCargar.Name = "btCargar";
            this.btCargar.Size = new System.Drawing.Size(75, 23);
            this.btCargar.TabIndex = 11;
            this.btCargar.Text = "Consultar";
            this.btCargar.UseVisualStyleBackColor = true;
            this.btCargar.Click += new System.EventHandler(this.btCargar_Click);
            // 
            // btActuzalizar
            // 
            this.btActuzalizar.Location = new System.Drawing.Point(485, 52);
            this.btActuzalizar.Name = "btActuzalizar";
            this.btActuzalizar.Size = new System.Drawing.Size(75, 23);
            this.btActuzalizar.TabIndex = 12;
            this.btActuzalizar.Text = "Cambiar datos";
            this.btActuzalizar.UseVisualStyleBackColor = true;
            this.btActuzalizar.Click += new System.EventHandler(this.btActuzalizar_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.Location = new System.Drawing.Point(485, 157);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btLimpiar.TabIndex = 13;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btRetirar
            // 
            this.btRetirar.Location = new System.Drawing.Point(485, 98);
            this.btRetirar.Name = "btRetirar";
            this.btRetirar.Size = new System.Drawing.Size(75, 23);
            this.btRetirar.TabIndex = 14;
            this.btRetirar.Text = "Retirar";
            this.btRetirar.UseVisualStyleBackColor = true;
            this.btRetirar.Click += new System.EventHandler(this.btRetirar_Click);
            // 
            // grMascotas
            // 
            this.grMascotas.AllowUserToAddRows = false;
            this.grMascotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grMascotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMascotas.Location = new System.Drawing.Point(25, 268);
            this.grMascotas.MultiSelect = false;
            this.grMascotas.Name = "grMascotas";
            this.grMascotas.ReadOnly = true;
            this.grMascotas.RowHeadersWidth = 51;
            this.grMascotas.RowTemplate.Height = 24;
            this.grMascotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMascotas.Size = new System.Drawing.Size(548, 245);
            this.grMascotas.TabIndex = 15;
            this.grMascotas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grMascotas_CellContentClick);
            // 
            // FrmMascota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 603);
            this.Controls.Add(this.grMascotas);
            this.Controls.Add(this.btRetirar);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.btActuzalizar);
            this.Controls.Add(this.btCargar);
            this.Controls.Add(this.btNuevo);
            this.Controls.Add(this.dtIngreso);
            this.Controls.Add(this.cbRaza);
            this.Controls.Add(this.txNombre);
            this.Controls.Add(this.txDescricion);
            this.Controls.Add(this.txld);
            this.Controls.Add(this.lbDescripcion);
            this.Controls.Add(this.lbIngreso);
            this.Controls.Add(this.IdRaza);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.lbCodigo);
            this.Name = "FrmMascota";
            this.Text = "Actualizacion de mascotas";
            this.Load += new System.EventHandler(this.FrmMascota_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMascotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label IdRaza;
        private System.Windows.Forms.Label lbIngreso;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox txld;
        private System.Windows.Forms.TextBox txDescricion;
        private System.Windows.Forms.TextBox txNombre;
        private System.Windows.Forms.ComboBox cbRaza;
        private System.Windows.Forms.DateTimePicker dtIngreso;
        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.Button btCargar;
        private System.Windows.Forms.Button btActuzalizar;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btRetirar;
        private System.Windows.Forms.DataGridView grMascotas;
    }
}