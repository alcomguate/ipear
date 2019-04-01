using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using REGISTROCEL_IPEAR.Models;

namespace REGISTROCEL_IPEAR.Controllers
{
    public class CAT_COLORController : ApiController
    {
        private IPEAREntities db = new IPEAREntities();

        // GET: api/CAT_COLOR
        public IQueryable<CAT_COLOR> GetCAT_COLOR()
        {
            return db.CAT_COLOR;
        }

        // GET: api/CAT_COLOR/5
        [ResponseType(typeof(CAT_COLOR))]
        public async Task<IHttpActionResult> GetCAT_COLOR(short id)
        {
            CAT_COLOR cAT_COLOR = await db.CAT_COLOR.FindAsync(id);
            if (cAT_COLOR == null)
            {
                return NotFound();
            }

            return Ok(cAT_COLOR);
        }

        // PUT: api/CAT_COLOR/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCAT_COLOR(short id, CAT_COLOR cAT_COLOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAT_COLOR.id)
            {
                return BadRequest();
            }

            db.Entry(cAT_COLOR).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAT_COLORExists(id))
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

        // POST: api/CAT_COLOR
        [ResponseType(typeof(CAT_COLOR))]
        public async Task<IHttpActionResult> PostCAT_COLOR(CAT_COLOR cAT_COLOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAT_COLOR.Add(cAT_COLOR);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cAT_COLOR.id }, cAT_COLOR);
        }

        // DELETE: api/CAT_COLOR/5
        [ResponseType(typeof(CAT_COLOR))]
        public async Task<IHttpActionResult> DeleteCAT_COLOR(short id)
        {
            CAT_COLOR cAT_COLOR = await db.CAT_COLOR.FindAsync(id);
            if (cAT_COLOR == null)
            {
                return NotFound();
            }

            db.CAT_COLOR.Remove(cAT_COLOR);
            await db.SaveChangesAsync();

            return Ok(cAT_COLOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAT_COLORExists(short id)
        {
            return db.CAT_COLOR.Count(e => e.id == id) > 0;
        }
    }
}