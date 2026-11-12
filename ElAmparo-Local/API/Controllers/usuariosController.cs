using Conector;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class usuariosController : ApiController
    {
        public IEnumerable<UsuarioDatos> Get()
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    return objEntidad.usuarios.Select(obj => new UsuarioDatos { usuario = obj.usuario, rol = obj.rol }).ToList();
                }
            }
            catch { return null; }
        }

        [HttpPost]
        [Route("api/usuarios/login")]
        public HttpResponseMessage Login([FromBody] UsuarioLogin objLogin)
        {
            try
            {
                if (objLogin == null || string.IsNullOrWhiteSpace(objLogin.usuario) || string.IsNullOrWhiteSpace(objLogin.clave))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Debe enviar usuario y clave.");

                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    usuarios objUsuario = objEntidad.usuarios.FirstOrDefault(obj => obj.usuario == objLogin.usuario && obj.clave == objLogin.clave);
                    if (objUsuario == null)
                        return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Usuario o clave incorrectos.");
                    return Request.CreateResponse(HttpStatusCode.OK, new UsuarioDatos { usuario = objUsuario.usuario, rol = objUsuario.rol });
                }
            }
            catch (System.Exception er)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, er.Message);
            }
        }

        public HttpResponseMessage Post([FromBody] usuarios objUsuario)
        {
            EntityState operacion = EntityState.Added;
            return opercion(objUsuario, operacion);
        }

        public HttpResponseMessage Put([FromBody] usuarios objUsuario)
        {
            EntityState operacion = EntityState.Modified;
            return opercion(objUsuario, operacion);
        }

        public HttpResponseMessage Delete([FromBody] usuarios objUsuario)
        {
            EntityState operacion = EntityState.Deleted;
            return opercion(objUsuario, operacion);
        }

        private HttpResponseMessage opercion([FromBody] usuarios objUsuario, EntityState operacion)
        {
            try
            {
                using (ElAmparoEntities objEntidad = new ElAmparoEntities())
                {
                    if (objUsuario == null)
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Debe enviar los datos del usuario.");
                    objEntidad.Entry(objUsuario).State = operacion;
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

    public class UsuarioLogin
    {
        public string usuario { get; set; }
        public string clave { get; set; }
    }

    public class UsuarioDatos
    {
        public string usuario { get; set; }
        public string rol { get; set; }
    }
}