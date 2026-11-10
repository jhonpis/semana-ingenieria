using System;
using System.Windows.Forms;

namespace el_amparo
{
    public partial class Menu : Form
    {
        private readonly string rol;
        private readonly Form1 login;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(string rol, Form1 login) : this()
        {
            this.rol = rol;
            this.login = login;
            IsMdiContainer = true;
            WindowState = FormWindowState.Maximized;
            Text = "Sociedad Protectora El Amparo - " + rol;
            if (String.Equals(rol, "CONSULTA", StringComparison.OrdinalIgnoreCase))
            {
                menuActualizacion.Enabled = false;
                menuNovedades.Enabled = false;
            }
        }

        private void menuConsultaMascotas_Click(object sender, EventArgs e)
        {
            FrmConsulta form = new FrmConsulta { MdiParent = this };
            form.Show();
        }

        private void menuMascota_Click(object sender, EventArgs e)
        {
            FrmMascota form = new FrmMascota { MdiParent = this };
            form.Show();
        }

        private void realizarOCancelarAdopcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdopciones form = new FrmAdopciones { MdiParent = this };
            form.Show();
        }

        private void menuCerrarSesion_Click(object sender, EventArgs e)
        {
            if (login != null)
                login.Show();
            Close();
        }

        private void menuSalirPrograma_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
