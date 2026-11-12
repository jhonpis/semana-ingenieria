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
    public class AdopcionController : ApiController
    {
        public IEnumerable<adopcion> Get()
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.adopcion.ToList();
                }
            }
            catch { return null; }
        }

        public adopcion Get(int id)
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.adopcion.Find(id);
                }
            }
            catch { return null; }
        }

        public HttpResponseMessage Post([FromBody] adopcion objAdopcion)
        {
            EntityState operacion = EntityState.Added;
            return opercion(objAdopcion, operacion);
        }

        public HttpResponseMessage Put([FromBody] adopcion objAdopcion)
        {
            EntityState operacion = EntityState.Modified;
            return opercion(objAdopcion, operacion);
        }

        public HttpResponseMessage Delete([FromBody] adopcion objAdopcion)
        {
            EntityState operacion = EntityState.Deleted;
            return opercion(objAdopcion, operacion);
        }

        private HttpResponseMessage opercion([FromBody] adopcion objAdopcion, EntityState operacion)
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                using (DbContextTransaction objTransaccion = objEntidad.Database.BeginTransaction())
                {
                    if (objAdopcion == null)
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Debe enviar los datos de la adopcion.");

                    mascota objMascota;
                    if (operacion == EntityState.Added)
                    {
                        objMascota = objEntidad.mascota.Find(objAdopcion.id_mascota);
                        if (objMascota == null)
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No existe la mascota.");
                        if (objMascota.estado != "Disponible")
                            return Request.CreateErrorResponse(HttpStatusCode.Conflict, "La mascota no esta disponible.");
                        if (objAdopcion.fecha == DateTime.MinValue)
                            objAdopcion.fecha = DateTime.Today;
                        objAdopcion.estado = "Vigente";
                        objMascota.estado = "Adoptada";
                        objEntidad.Entry(objAdopcion).State = EntityState.Added;
                    }
                    else
                    {
                        adopcion objAdopcionDb = objEntidad.adopcion.Find(objAdopcion.id);
                        if (objAdopcionDb == null)
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No existe la adopcion.");
                        objMascota = objEntidad.mascota.Find(objAdopcionDb.id_mascota);
                        if (objMascota == null)
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No existe la mascota.");
                        if (operacion == EntityState.Modified)
                        {
                            if (objAdopcionDb.estado == "Vigente")
                            {
                                objAdopcionDb.estado = "Cancelada";
                                objMascota.estado = "Disponible";
                            }
                        }
                        else
                        {
                            if (objAdopcionDb.estado == "Vigente")
                                objMascota.estado = "Disponible";
                            objEntidad.Entry(objAdopcionDb).State = EntityState.Deleted;
                        }
                    }

                    int resp = objEntidad.SaveChanges();
                    objTransaccion.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception er)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, er.Message);
            }
        }
    }
}