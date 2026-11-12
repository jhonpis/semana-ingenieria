using Conector;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    public class MascotasWebController : Controller
    {
        public ActionResult Consulta(int? codigo, string nombre)
        {
            using (ElAmparoEntities objEntidad = new ElAmparoEntities())
            {
                var objMascotas = from objMascota in objEntidad.mascota
                                  join objRaza in objEntidad.raza on objMascota.codigo_raza equals objRaza.codigo
                                  select new MascotaWeb
                                  {
                                      id = objMascota.id,
                                      nombre = objMascota.nombre,
                                      raza = objRaza.nombre,
                                      estado = objMascota.estado,
                                      fecha_ingreso = objMascota.fecha_ingreso
                                  };
                if (codigo.HasValue)
                    objMascotas = objMascotas.Where(obj => obj.id == codigo.Value);
                if (!string.IsNullOrWhiteSpace(nombre))
                    objMascotas = objMascotas.Where(obj => obj.nombre.Contains(nombre));
                return View(objMascotas.ToList());
            }
        }

        public ActionResult MaestroDetalle(int? codigo)
        {
            using (ElAmparoEntities objEntidad = new ElAmparoEntities())
            {
                ViewBag.Razas = objEntidad.raza.ToList();
                ViewBag.Codigo = codigo;
                var objMascotas = from objMascota in objEntidad.mascota
                                  join objRaza in objEntidad.raza on objMascota.codigo_raza equals objRaza.codigo
                                  select new MascotaWeb
                                  {
                                      id = objMascota.id,
                                      nombre = objMascota.nombre,
                                      raza = objRaza.nombre,
                                      codigo_raza = objRaza.codigo,
                                      estado = objMascota.estado,
                                      fecha_ingreso = objMascota.fecha_ingreso
                                  };
                if (codigo.HasValue)
                    objMascotas = objMascotas.Where(obj => obj.codigo_raza == codigo.Value);
                return View(objMascotas.ToList());
            }
        }

        public ActionResult Vista()
        {
            using (ElAmparoEntities objEntidad = new ElAmparoEntities())
            {
                List<VistaMascota> objVista = objEntidad.Database.SqlQuery<VistaMascota>(
                    "SELECT id, nombre, raza, estado, adoptante FROM dbo.vw_MascotasAdopcion").ToList();
                return View(objVista);
            }
        }
    }

    public class MascotaWeb
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string raza { get; set; }
        public int codigo_raza { get; set; }
        public string estado { get; set; }
        public System.DateTime fecha_ingreso { get; set; }
    }

    public class VistaMascota
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string raza { get; set; }
        public string estado { get; set; }
        public string adoptante { get; set; }
    }
}