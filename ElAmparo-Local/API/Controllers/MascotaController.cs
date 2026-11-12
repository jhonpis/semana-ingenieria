using Conector;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MascotaController : ApiController
    {
        public IEnumerable<mascota> Get()
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.mascota.ToList();
                }
            }
            catch { return null; }
        }

        public mascota Get(int id)
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.mascota.FirstOrDefault(obj => obj.id == id);
                }
            }
            catch { return null; }
        }

        [HttpGet]
        [Route("api/mascota/buscar/{nombre}")]
        public IEnumerable<mascota> Buscar(string nombre)
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.mascota.Where(obj => obj.nombre.Contains(nombre)).ToList();
                }
            }
            catch { return null; }
        }

        public HttpResponseMessage Post([FromBody] mascota objMascota)
        {
            EntityState operacion = EntityState.Added;
            return opercion(objMascota, operacion);
        }

        public HttpResponseMessage Put([FromBody] mascota objMascota)
        {
            EntityState operacion = EntityState.Modified;
            return opercion(objMascota, operacion);
        }

        public HttpResponseMessage Delete([FromBody] mascota objMascota)
        {
            EntityState operacion = EntityState.Deleted;
            return opercion(objMascota, operacion);
        }

        private HttpResponseMessage opercion([FromBody] mascota objMascota, EntityState operacion)
        {
            int resp = 0;
            HttpResponseMessage objMenRespuesta = null;
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    if (objMascota == null)
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Debe enviar los datos de la mascota.");
                    if (operacion == EntityState.Added && objMascota.fecha_ingreso == DateTime.MinValue)
                        objMascota.fecha_ingreso = DateTime.Today;
                    if ((operacion == EntityState.Deleted || objMascota.estado == "Retirada") &&
                        objEntidad.adopcion.Any(obj => obj.id_mascota == objMascota.id && obj.estado == "Vigente"))
                        return Request.CreateErrorResponse(HttpStatusCode.Conflict, "No se puede retirar una mascota con adopcion vigente.");
                    objEntidad.Entry(objMascota).State = operacion;
                    resp = objEntidad.SaveChanges();
                    objMenRespuesta = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception er)
            {
                objMenRespuesta = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, er.Message);
            }
            return objMenRespuesta;
        }
    }
}