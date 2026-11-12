using Conector;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AdoptanteController : ApiController
    {
        public IEnumerable<adoptante> Get()
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.adoptante.ToList();
                }
            }
            catch { return null; }
        }

        public adoptante Get(int id)
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.adoptante.Find(id);
                }
            }
            catch { return null; }
        }

        public HttpResponseMessage Post([FromBody] adoptante objAdoptante)
        {
            EntityState operacion = EntityState.Added;
            return opercion(objAdoptante, operacion);
        }

        public HttpResponseMessage Put([FromBody] adoptante objAdoptante)
        {
            EntityState operacion = EntityState.Modified;
            return opercion(objAdoptante, operacion);
        }

        public HttpResponseMessage Delete([FromBody] adoptante objAdoptante)
        {
            EntityState operacion = EntityState.Deleted;
            return opercion(objAdoptante, operacion);
        }

        private HttpResponseMessage opercion([FromBody] adoptante objAdoptante, EntityState operacion)
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    if (objAdoptante == null)
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Debe enviar los datos del adoptante.");
                    objEntidad.Entry(objAdoptante).State = operacion;
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