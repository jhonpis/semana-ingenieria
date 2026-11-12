using System;

namespace el_amparo
{
    public class MascotaApi
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int codigo_raza { get; set; }
        public string estado { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string descripcion { get; set; }
        public RazaApi raza { get; set; }
    }

    public class RazaApi
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }

    public class AdoptanteApi
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
    }

    public class AdopcionApi
    {
        public int id { get; set; }
        public int id_mascota { get; set; }
        public int id_adoptante { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public MascotaApi mascota { get; set; }
        public AdoptanteApi adoptante { get; set; }
    }

    public class UsuarioApi
    {
        public string usuario { get; set; }
        public string rol { get; set; }
    }
}
