using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace el_amparo
{
    public partial class FrmAdopciones : Form
    {
        private readonly string urlApi;

        public FrmAdopciones()
        {
            InitializeComponent();
            urlApi = ConfigurationManager.AppSettings["ApiBaseUrl"];
        }

        private void FrmAdopciones_Load(object sender, EventArgs e)
        {
            CargarAdopciones();
        }

        private void btRealizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txMascota.Text) || String.IsNullOrWhiteSpace(txAdoptante.Text) ||
                    String.IsNullOrWhiteSpace(txDocumento.Text) || String.IsNullOrWhiteSpace(txTelefono.Text))
                    throw new Exception("Debe diligenciar los datos del adoptante y la mascota.");

                List<AdoptanteApi> adoptantes = ApiClient.Get<List<AdoptanteApi>>(urlApi + "/api/adoptante") ?? new List<AdoptanteApi>();
                AdoptanteApi adoptante = adoptantes.Find(item => item.documento == txDocumento.Text);
                if (adoptante == null)
                {
                    ApiClient.Post(urlApi + "/api/adoptante", new AdoptanteApi
                    {
                        nombre = txAdoptante.Text,
                        documento = txDocumento.Text,
                        telefono = txTelefono.Text
                    });
                    adoptantes = ApiClient.Get<List<AdoptanteApi>>(urlApi + "/api/adoptante") ?? new List<AdoptanteApi>();
                    adoptante = adoptantes.Find(item => item.documento == txDocumento.Text);
                }

                if (adoptante == null)
                    throw new Exception("No se encontró el adoptante registrado.");

                ApiClient.Post(urlApi + "/api/adopcion", new AdopcionApi
                {
                    id_mascota = Convert.ToInt32(txMascota.Text),
                    id_adoptante = adoptante.id,
                    fecha = DateTime.Today,
                    estado = "Vigente"
                });
                MessageBox.Show("Adopción realizada.");
                CargarAdopciones();
            }
            catch (Exception ex) { MessageBox.Show("Fallo al realizar la adopción: " + ex.Message); }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txAdopcion.Text))
                    throw new Exception("Seleccione una adopción vigente.");
                ApiClient.Put(urlApi + "/api/adopcion/" + txAdopcion.Text, new AdopcionApi { id = Convert.ToInt32(txAdopcion.Text) });
                MessageBox.Show("Adopción cancelada.");
                CargarAdopciones();
            }
            catch (Exception ex) { MessageBox.Show("Fallo al cancelar la adopción: " + ex.Message); }
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            try { CargarAdopciones(); }
            catch (Exception ex) { MessageBox.Show("Fallo la consulta: " + ex.Message); }
        }

        private void grAdopciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grAdopciones.CurrentRow != null && grAdopciones.CurrentRow.DataBoundItem is AdopcionApi adopcion)
                txAdopcion.Text = adopcion.id.ToString();
        }

        private void CargarAdopciones()
        {
            grAdopciones.DataSource = ApiClient.Get<List<AdopcionApi>>(urlApi + "/api/adopcion");
        }
    }
}
