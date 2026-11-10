using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace el_amparo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txUsuario.Text) || String.IsNullOrWhiteSpace(txClave.Text))
            {
                MessageBox.Show("Debe ingresar toda la información.");
                return;
            }

            try
            {
                using (SqlConnection connection = Db.Open("ElAmparo"))
                using (SqlCommand command = new SqlCommand(
                    "SELECT clave, rol FROM USUARIOS WHERE usuario = @usuario", connection))
                {
                    command.Parameters.AddWithValue("@usuario", txUsuario.Text);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read() || reader[0].ToString() != txClave.Text)
                        {
                            MessageBox.Show("Usuario o clave incorrectos");
                            txClave.Clear();
                            return;
                        }

                        string rol = reader[1].ToString();
                        Hide();
                        new Menu(rol, this).Show();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("No fue posible iniciar sesión: " + ex.Message); }
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
