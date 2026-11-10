using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Windows.Forms;

namespace el_amparo
{
    public partial class FrmConsulta : Form
    {
        private readonly string urlApi;

        public FrmConsulta()
        {
            InitializeComponent();
            urlApi = ConfigurationManager.AppSettings["ApiBaseUrl"];
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                string url = urlApi + "/api/mascota";
                if (!String.IsNullOrWhiteSpace(txCodigo.Text))
                    url += "/" + txCodigo.Text;
                else if (!String.IsNullOrWhiteSpace(txNombre.Text))
                    url += "/buscar/" + Uri.EscapeDataString(txNombre.Text);

                MascotaApi mascota = ApiClient.Get<MascotaApi>(url);
                if (mascota != null)
                    grMascotas.DataSource = new List<MascotaApi> { mascota };
                else
                    grMascotas.DataSource = ApiClient.Get<List<MascotaApi>>(url);

                if (grMascotas.DataSource == null)
                    MessageBox.Show("No se encontraron mascotas.");
            }
            catch (WebException ex)
            {
                MessageBox.Show("Fallo la consulta: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la consulta: " + ex.Message);
            }
        }
    }
}
