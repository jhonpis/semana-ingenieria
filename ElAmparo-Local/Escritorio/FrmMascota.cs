using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace el_amparo
{
    public partial class FrmMascota : Form
    {
        private readonly string urlApi;

        public FrmMascota()
        {
            InitializeComponent();
            urlApi = ConfigurationManager.AppSettings["ApiBaseUrl"];
            txDescricion.ReadOnly = false;
        }

        private void FrmMascota_Load(object sender, EventArgs e)
        {
            try
            {
                cbRaza.DataSource = ApiClient.Get<List<RazaApi>>(urlApi + "/api/raza");
                cbRaza.DisplayMember = "nombre";
                cbRaza.ValueMember = "codigo";
                CargarMascotas();
            }
            catch (Exception ex) { MessageBox.Show("Fallo la carga: " + ex.Message); }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                MascotaApi mascota = DatosFormulario();
                mascota.estado = "Disponible";
                ApiClient.Post(urlApi + "/api/mascota", mascota);
                MessageBox.Show("Mascota ingresada.");
                CargarMascotas();
            }
            catch (Exception ex) { MessageBox.Show("Fallo el ingreso: " + ex.Message); }
        }

        private void btActuzalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txld.Text))
                    throw new Exception("Seleccione una mascota.");
                ApiClient.Put(urlApi + "/api/mascota/" + txld.Text, DatosFormulario());
                MessageBox.Show("Datos actualizados.");
                CargarMascotas();
            }
            catch (Exception ex) { MessageBox.Show("Fallo la actualización: " + ex.Message); }
        }

        private void btRetirar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txld.Text))
                    throw new Exception("Seleccione una mascota.");
                MascotaApi mascota = DatosFormulario();
                mascota.estado = "Retirada";
                ApiClient.Put(urlApi + "/api/mascota/" + txld.Text, mascota);
                MessageBox.Show("Mascota retirada.");
                CargarMascotas();
            }
            catch (Exception ex) { MessageBox.Show("Fallo al retirar: " + ex.Message); }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txld.Clear();
            txNombre.Clear();
            txDescricion.Clear();
            cbRaza.SelectedIndex = -1;
            dtIngreso.Value = DateTime.Today;
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            try { CargarMascotas(); }
            catch (Exception ex) { MessageBox.Show("Fallo la consulta: " + ex.Message); }
        }

        private void grMascotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grMascotas.CurrentRow != null && grMascotas.CurrentRow.DataBoundItem is MascotaApi mascota)
            {
                txld.Text = mascota.id.ToString();
                txNombre.Text = mascota.nombre;
                txDescricion.Text = mascota.descripcion;
                dtIngreso.Value = mascota.fecha_ingreso < dtIngreso.MinDate || mascota.fecha_ingreso > dtIngreso.MaxDate
                    ? DateTime.Today : mascota.fecha_ingreso;
                cbRaza.SelectedValue = mascota.codigo_raza;
            }
        }

        private void CargarMascotas()
        {
            grMascotas.DataSource = ApiClient.Get<List<MascotaApi>>(urlApi + "/api/mascota");
        }

        private MascotaApi DatosFormulario()
        {
            if (String.IsNullOrWhiteSpace(txNombre.Text) || cbRaza.SelectedValue == null)
                throw new Exception("Debe ingresar nombre y raza.");
            return new MascotaApi
            {
                id = String.IsNullOrWhiteSpace(txld.Text) ? 0 : Convert.ToInt32(txld.Text),
                nombre = txNombre.Text,
                codigo_raza = Convert.ToInt32(cbRaza.SelectedValue),
                estado = "Disponible",
                fecha_ingreso = dtIngreso.Value.Date,
                descripcion = txDescricion.Text
            };
        }
    }
}
