using Conector;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RazaController : ApiController
    {
        public IEnumerable<raza> Get()
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.raza.ToList();
                }
            }
            catch { return null; }
        }

        public raza Get(int id)
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.raza.Find(id);
                }
            }
            catch { return null; }
        }

        public HttpResponseMessage Post([FromBody] raza objRaza)
        {
            EntityState operacion = EntityState.Added;
            return opercion(objRaza, operacion);
        }

        public HttpResponseMessage Put([FromBody] raza objRaza)
        {
            EntityState operacion = EntityState.Modified;
            return opercion(objRaza, operacion);
        }

        public HttpResponseMessage Delete([FromBody] raza objRaza)
        {
            EntityState operacion = EntityState.Deleted;
            return opercion(objRaza, operacion);
        }

        private HttpResponseMessage opercion([FromBody] raza objRaza, EntityState operacion)
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    if (objRaza == null)
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Debe enviar los datos de la raza.");
                    objEntidad.Entry(objRaza).State = operacion;
                    int resp = objEntidad.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (System.Exception er)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, er.Message);
            }
        }
    }
}