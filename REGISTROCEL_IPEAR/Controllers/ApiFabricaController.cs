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
    public class ApiFabricaController : ApiController
    {
        private IPEAREntities db = new IPEAREntities();

        // GET: api/ApiFabrica
        public IQueryable<CAT_FABRICA> GetCAT_FABRICA()
        {
            return db.CAT_FABRICA;
        }

        // GET: api/ApiFabrica/5
        [ResponseType(typeof(CAT_FABRICA))]
        public IHttpActionResult GetCAT_FABRICA(short id)
        {
            CAT_FABRICA cAT_FABRICA = db.CAT_FABRICA.Find(id);
            if (cAT_FABRICA == null)
            {
                return NotFound();
            }

            return Ok(cAT_FABRICA);
        }

        // PUT: api/ApiFabrica/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCAT_FABRICA(short id, CAT_FABRICA cAT_FABRICA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAT_FABRICA.id)
            {
                return BadRequest();
            }

            db.Entry(cAT_FABRICA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAT_FABRICAExists(id))
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

        // POST: api/ApiFabrica
        [ResponseType(typeof(CAT_FABRICA))]
        public IHttpActionResult PostCAT_FABRICA(CAT_FABRICA cAT_FABRICA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAT_FABRICA.Add(cAT_FABRICA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cAT_FABRICA.id }, cAT_FABRICA);
        }

        // DELETE: api/ApiFabrica/5
        [ResponseType(typeof(CAT_FABRICA))]
        public IHttpActionResult DeleteCAT_FABRICA(short id)
        {
            CAT_FABRICA cAT_FABRICA = db.CAT_FABRICA.Find(id);
            if (cAT_FABRICA == null)
            {
                return NotFound();
            }

            db.CAT_FABRICA.Remove(cAT_FABRICA);
            db.SaveChanges();

            return Ok(cAT_FABRICA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAT_FABRICAExists(short id)
        {
            return db.CAT_FABRICA.Count(e => e.id == id) > 0;
        }
    }
}