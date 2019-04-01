using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using REGISTROCEL_IPEAR.Models;

namespace REGISTROCEL_IPEAR.Controllers
{
    public class ApiGamaController : ApiController
    {
        private IPEAREntities db = new IPEAREntities();

        // GET: api/ApiGama
        public IQueryable<CAT_GAMA> GetCAT_GAMA()
        {
            return db.CAT_GAMA;
        }

        // GET: api/ApiGama/5
        [ResponseType(typeof(CAT_GAMA))]
        public IHttpActionResult GetCAT_GAMA(int id)
        {
            CAT_GAMA cAT_GAMA = db.CAT_GAMA.Find(id);
            if (cAT_GAMA == null)
            {
                return NotFound();
            }

            return Ok(cAT_GAMA);
        }

        // PUT: api/ApiGama/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCAT_GAMA(int id, CAT_GAMA cAT_GAMA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAT_GAMA.id)
            {
                return BadRequest();
            }

            db.Entry(cAT_GAMA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAT_GAMAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiGama
        [ResponseType(typeof(CAT_GAMA))]
        public IHttpActionResult PostCAT_GAMA(CAT_GAMA cAT_GAMA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAT_GAMA.Add(cAT_GAMA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cAT_GAMA.id }, cAT_GAMA);
        }

        // DELETE: api/ApiGama/5
        [ResponseType(typeof(CAT_GAMA))]
        public IHttpActionResult DeleteCAT_GAMA(int id)
        {
            CAT_GAMA cAT_GAMA = db.CAT_GAMA.Find(id);
            if (cAT_GAMA == null)
            {
                return NotFound();
            }

            db.CAT_GAMA.Remove(cAT_GAMA);
            db.SaveChanges();

            return Ok(cAT_GAMA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAT_GAMAExists(int id)
        {
            return db.CAT_GAMA.Count(e => e.id == id) > 0;
        }
    }
}