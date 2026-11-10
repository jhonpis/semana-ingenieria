namespace el_amparo
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbUsuario = new System.Windows.Forms.Label();
            this.txUsuario = new System.Windows.Forms.TextBox();
            this.lbClave = new System.Windows.Forms.Label();
            this.txClave = new System.Windows.Forms.TextBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.btSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(116, 47);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(54, 16);
            this.lbUsuario.TabIndex = 0;
            this.lbUsuario.Text = "Usuario";
            // 
            // txUsuario
            // 
            this.txUsuario.Location = new System.Drawing.Point(205, 47);
            this.txUsuario.Name = "txUsuario";
            this.txUsuario.Size = new System.Drawing.Size(210, 22);
            this.txUsuario.TabIndex = 1;
            // 
            // lbClave
            // 
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(119, 111);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(42, 16);
            this.lbClave.TabIndex = 2;
            this.lbClave.Text = "Clave";
            // 
            // txClave
            // 
            this.txClave.Location = new System.Drawing.Point(205, 104);
            this.txClave.Name = "txClave";
            this.txClave.Size = new System.Drawing.Size(210, 22);
            this.txClave.TabIndex = 3;
            this.txClave.UseSystemPasswordChar = true;
            // 
            // btEnviar
            // 
            this.btEnviar.Location = new System.Drawing.Point(205, 178);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(100, 23);
            this.btEnviar.TabIndex = 4;
            this.btEnviar.Text = "Ingresar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // btSalir
            // 
            this.btSalir.Location = new System.Drawing.Point(340, 178);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(100, 23);
            this.btSalir.TabIndex = 5;
            this.btSalir.Text = "salir";
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.txClave);
            this.Controls.Add(this.lbClave);
            this.Controls.Add(this.txUsuario);
            this.Controls.Add(this.lbUsuario);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.TextBox txUsuario;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.TextBox txClave;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Button btSalir;
    }
}

