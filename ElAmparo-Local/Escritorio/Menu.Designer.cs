namespace el_amparo
{
    partial class Menu
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
            this.menuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaMascotas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActualizacion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMascota = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNovedades = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarOCancelarAdopcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalirPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConsulta,
            this.menuActualizacion,
            this.menuNovedades,
            this.menuSalir});
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Size = new System.Drawing.Size(800, 30);
            this.menuStripPrincipal.TabIndex = 0;
            this.menuStripPrincipal.Text = "menuStrip1";
            // 
            // menuConsulta
            // 
            this.menuConsulta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConsultaMascotas});
            this.menuConsulta.Name = "menuConsulta";
            this.menuConsulta.Size = new System.Drawing.Size(78, 26);
            this.menuConsulta.Text = "consulta";
            // 
            // menuConsultaMascotas
            // 
            this.menuConsultaMascotas.Name = "menuConsultaMascotas";
            this.menuConsultaMascotas.Size = new System.Drawing.Size(293, 26);
            this.menuConsultaMascotas.Text = "Por codigo o nombre mascota";
            this.menuConsultaMascotas.Click += new System.EventHandler(this.menuConsultaMascotas_Click);
            // 
            // menuActualizacion
            // 
            this.menuActualizacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMascota});
            this.menuActualizacion.Name = "menuActualizacion";
            this.menuActualizacion.Size = new System.Drawing.Size(112, 26);
            this.menuActualizacion.Text = "Actualizacion";
            // 
            // menuMascota
            // 
            this.menuMascota.Name = "menuMascota";
            this.menuMascota.Size = new System.Drawing.Size(323, 26);
            this.menuMascota.Text = "Ingresar, retirar o cambiar mascota";
            this.menuMascota.Click += new System.EventHandler(this.menuMascota_Click);
            // 
            // menuNovedades
            // 
            this.menuNovedades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizarOCancelarAdopcionToolStripMenuItem});
            this.menuNovedades.Name = "menuNovedades";
            this.menuNovedades.Size = new System.Drawing.Size(98, 26);
            this.menuNovedades.Text = "Novedades";
            // 
            // realizarOCancelarAdopcionToolStripMenuItem
            // 
            this.realizarOCancelarAdopcionToolStripMenuItem.Name = "realizarOCancelarAdopcionToolStripMenuItem";
            this.realizarOCancelarAdopcionToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.realizarOCancelarAdopcionToolStripMenuItem.Text = "realizar o cancelar adopcion";
            this.realizarOCancelarAdopcionToolStripMenuItem.Click += new System.EventHandler(this.realizarOCancelarAdopcionToolStripMenuItem_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCerrarSesion,
            this.menuSalirPrograma});
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(52, 26);
            this.menuSalir.Text = "Salir";
            // 
            // menuCerrarSesion
            // 
            this.menuCerrarSesion.Name = "menuCerrarSesion";
            this.menuCerrarSesion.Size = new System.Drawing.Size(224, 26);
            this.menuCerrarSesion.Text = "Cerrar sesion";
            this.menuCerrarSesion.Click += new System.EventHandler(this.menuCerrarSesion_Click);
            // 
            // menuSalirPrograma
            // 
            this.menuSalirPrograma.Name = "menuSalirPrograma";
            this.menuSalirPrograma.Size = new System.Drawing.Size(224, 26);
            this.menuSalirPrograma.Text = "Salir del programa";
            this.menuSalirPrograma.Click += new System.EventHandler(this.menuSalirPrograma_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStripPrincipal);
            this.MainMenuStrip = this.menuStripPrincipal;
            this.Name = "Menu";
            this.Text = "Menu";
            this.menuStripPrincipal.ResumeLayout(false);
            this.menuStripPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuConsulta;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaMascotas;
        private System.Windows.Forms.ToolStripMenuItem menuActualizacion;
        private System.Windows.Forms.ToolStripMenuItem menuMascota;
        private System.Windows.Forms.ToolStripMenuItem menuNovedades;
        private System.Windows.Forms.ToolStripMenuItem realizarOCancelarAdopcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.ToolStripMenuItem menuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem menuSalirPrograma;
    }
}