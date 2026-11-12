namespace el_amparo
{
    partial class FrmAdopciones
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
            this.lbMascota = new System.Windows.Forms.Label();
            this.lbAdopcion = new System.Windows.Forms.Label();
            this.lbAdoptante = new System.Windows.Forms.Label();
            this.lbTelefono = new System.Windows.Forms.Label();
            this.lbDocumento = new System.Windows.Forms.Label();
            this.txMascota = new System.Windows.Forms.TextBox();
            this.txAdopcion = new System.Windows.Forms.TextBox();
            this.txDocumento = new System.Windows.Forms.TextBox();
            this.txTelefono = new System.Windows.Forms.TextBox();
            this.txAdoptante = new System.Windows.Forms.TextBox();
            this.btRealizar = new System.Windows.Forms.Button();
            this.btCargar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.grAdopciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grAdopciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMascota
            // 
            this.lbMascota.AutoSize = true;
            this.lbMascota.Location = new System.Drawing.Point(13, 13);
            this.lbMascota.Name = "lbMascota";
            this.lbMascota.Size = new System.Drawing.Size(172, 16);
            this.lbMascota.TabIndex = 0;
            this.lbMascota.Text = "Codigo mascota disponible";
            // 
            // lbAdopcion
            // 
            this.lbAdopcion.AutoSize = true;
            this.lbAdopcion.Location = new System.Drawing.Point(13, 184);
            this.lbAdopcion.Name = "lbAdopcion";
            this.lbAdopcion.Size = new System.Drawing.Size(111, 16);
            this.lbAdopcion.TabIndex = 1;
            this.lbAdopcion.Text = "Codigo adopcion";
            // 
            // lbAdoptante
            // 
            this.lbAdoptante.AutoSize = true;
            this.lbAdoptante.Location = new System.Drawing.Point(13, 53);
            this.lbAdoptante.Name = "lbAdoptante";
            this.lbAdoptante.Size = new System.Drawing.Size(120, 16);
            this.lbAdoptante.TabIndex = 2;
            this.lbAdoptante.Text = "Nombre adoptante";
            // 
            // lbTelefono
            // 
            this.lbTelefono.AutoSize = true;
            this.lbTelefono.Location = new System.Drawing.Point(13, 139);
            this.lbTelefono.Name = "lbTelefono";
            this.lbTelefono.Size = new System.Drawing.Size(61, 16);
            this.lbTelefono.TabIndex = 3;
            this.lbTelefono.Text = "Telefono";
            // 
            // lbDocumento
            // 
            this.lbDocumento.AutoSize = true;
            this.lbDocumento.Location = new System.Drawing.Point(13, 96);
            this.lbDocumento.Name = "lbDocumento";
            this.lbDocumento.Size = new System.Drawing.Size(76, 16);
            this.lbDocumento.TabIndex = 4;
            this.lbDocumento.Text = "Documento";
            // 
            // txMascota
            // 
            this.txMascota.Location = new System.Drawing.Point(202, 10);
            this.txMascota.Name = "txMascota";
            this.txMascota.Size = new System.Drawing.Size(170, 22);
            this.txMascota.TabIndex = 5;
            // 
            // txAdopcion
            // 
            this.txAdopcion.Location = new System.Drawing.Point(147, 184);
            this.txAdopcion.Name = "txAdopcion";
            this.txAdopcion.Size = new System.Drawing.Size(100, 22);
            this.txAdopcion.TabIndex = 6;
            // 
            // txDocumento
            // 
            this.txDocumento.Location = new System.Drawing.Point(97, 96);
            this.txDocumento.Name = "txDocumento";
            this.txDocumento.Size = new System.Drawing.Size(100, 22);
            this.txDocumento.TabIndex = 7;
            // 
            // txTelefono
            // 
            this.txTelefono.Location = new System.Drawing.Point(97, 139);
            this.txTelefono.Name = "txTelefono";
            this.txTelefono.Size = new System.Drawing.Size(100, 22);
            this.txTelefono.TabIndex = 8;
            // 
            // txAdoptante
            // 
            this.txAdoptante.Location = new System.Drawing.Point(157, 53);
            this.txAdoptante.Name = "txAdoptante";
            this.txAdoptante.Size = new System.Drawing.Size(100, 22);
            this.txAdoptante.TabIndex = 9;
            // 
            // btRealizar
            // 
            this.btRealizar.Location = new System.Drawing.Point(479, 13);
            this.btRealizar.Name = "btRealizar";
            this.btRealizar.Size = new System.Drawing.Size(75, 23);
            this.btRealizar.TabIndex = 10;
            this.btRealizar.Text = "Realizar adopcion";
            this.btRealizar.UseVisualStyleBackColor = true;
            this.btRealizar.Click += new System.EventHandler(this.btRealizar_Click);
            // 
            // btCargar
            // 
            this.btCargar.Location = new System.Drawing.Point(479, 177);
            this.btCargar.Name = "btCargar";
            this.btCargar.Size = new System.Drawing.Size(75, 23);
            this.btCargar.TabIndex = 11;
            this.btCargar.Text = "Consultar";
            this.btCargar.UseVisualStyleBackColor = true;
            this.btCargar.Click += new System.EventHandler(this.btCargar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(479, 89);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 12;
            this.btCancelar.Text = "Cancelar Adopcion";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // grAdopciones
            // 
            this.grAdopciones.AllowUserToAddRows = false;
            this.grAdopciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grAdopciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grAdopciones.Location = new System.Drawing.Point(16, 291);
            this.grAdopciones.MultiSelect = false;
            this.grAdopciones.Name = "grAdopciones";
            this.grAdopciones.ReadOnly = true;
            this.grAdopciones.RowHeadersWidth = 51;
            this.grAdopciones.RowTemplate.Height = 24;
            this.grAdopciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grAdopciones.Size = new System.Drawing.Size(677, 270);
            this.grAdopciones.TabIndex = 13;
            this.grAdopciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grAdopciones_CellContentClick);
            // 
            // FrmAdopciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 573);
            this.Controls.Add(this.grAdopciones);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btCargar);
            this.Controls.Add(this.btRealizar);
            this.Controls.Add(this.txAdoptante);
            this.Controls.Add(this.txTelefono);
            this.Controls.Add(this.txDocumento);
            this.Controls.Add(this.txAdopcion);
            this.Controls.Add(this.txMascota);
            this.Controls.Add(this.lbDocumento);
            this.Controls.Add(this.lbTelefono);
            this.Controls.Add(this.lbAdoptante);
            this.Controls.Add(this.lbAdopcion);
            this.Controls.Add(this.lbMascota);
            this.Name = "FrmAdopciones";
            this.Text = "Novedades_Adopciones";
            this.Load += new System.EventHandler(this.FrmAdopciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grAdopciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMascota;
        private System.Windows.Forms.Label lbAdopcion;
        private System.Windows.Forms.Label lbAdoptante;
        private System.Windows.Forms.Label lbTelefono;
        private System.Windows.Forms.Label lbDocumento;
        private System.Windows.Forms.TextBox txMascota;
        private System.Windows.Forms.TextBox txAdopcion;
        private System.Windows.Forms.TextBox txDocumento;
        private System.Windows.Forms.TextBox txTelefono;
        private System.Windows.Forms.TextBox txAdoptante;
        private System.Windows.Forms.Button btRealizar;
        private System.Windows.Forms.Button btCargar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.DataGridView grAdopciones;
    }
}