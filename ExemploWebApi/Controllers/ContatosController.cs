using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ExemploWebApi.Models;

namespace ExemploWebApi.Controllers
{
    public class ContatosController : ApiController
    {
        private ExemploWebAPIContext db = new ExemploWebAPIContext();

        // GET api/Default1
        public IEnumerable<Contato> GetContatoes()
        {
            return db.Contatos.AsEnumerable();
        }

        // GET api/Default1/5
        public Contato GetContato(int id)
        {
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return contato;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutContato(int id, Contato contato)
        {
            if (ModelState.IsValid && id == contato.Id)
            {
                db.Entry(contato).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, contato);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Default1
        public HttpResponseMessage PostContato([FromBody]Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Contatos.Add(contato);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contato);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = contato.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteContato(int id)
        {
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Contatos.Remove(contato);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, contato);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}