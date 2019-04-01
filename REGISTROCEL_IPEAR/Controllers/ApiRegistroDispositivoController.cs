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
    public class ApiRegistroDispositivoController : ApiController
    {
        private IPEAREntities db = new IPEAREntities();

        // GET: api/ApiRegistroDispositivo
        public IQueryable<REG_DISPOSITIVO> GetREG_DISPOSITIVO()
        {
            return db.REG_DISPOSITIVO;
        }

        // GET: api/ApiRegistroDispositivo/5
        [ResponseType(typeof(REG_DISPOSITIVO))]
        public IHttpActionResult GetREG_DISPOSITIVO(int id)
        {
            REG_DISPOSITIVO rEG_DISPOSITIVO = db.REG_DISPOSITIVO.Find(id);
            if (rEG_DISPOSITIVO == null)
            {
                return NotFound();
            }

            return Ok(rEG_DISPOSITIVO);
        }

        // PUT: api/ApiRegistroDispositivo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutREG_DISPOSITIVO(int id, REG_DISPOSITIVO rEG_DISPOSITIVO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rEG_DISPOSITIVO.id)
            {
                return BadRequest();
            }

            db.Entry(rEG_DISPOSITIVO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!REG_DISPOSITIVOExists(id))
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

        private decimal calcularCostoFabricacion(short fabrica, int gama)
        {
            CAT_FABRICA catFabrica = db.CAT_FABRICA.FirstOrDefault(x => x.id == fabrica);
            CAT_GAMA catGama = db.CAT_GAMA.FirstOrDefault(x => x.id == gama);
            decimal porcentajeIncremento = (catFabrica == null? decimal.Parse("0") : catFabrica.orden * decimal.Parse("0.03")) + 1;
            decimal costo = catGama == null? decimal.Parse("0") : catGama.costo_ensamblaje;
            return costo * porcentajeIncremento;
        }

        // POST: api/ApiRegistroDispositivo
        [ResponseType(typeof(REG_DISPOSITIVO))]
        public IHttpActionResult PostREG_DISPOSITIVO(REG_DISPOSITIVO rEG_DISPOSITIVO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            rEG_DISPOSITIVO.costo_fabricacion_final = this.calcularCostoFabricacion(rEG_DISPOSITIVO.fabrica_ensamblaje, rEG_DISPOSITIVO.gama);
            db.REG_DISPOSITIVO.Add(rEG_DISPOSITIVO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rEG_DISPOSITIVO.id }, rEG_DISPOSITIVO);
        }

        // DELETE: api/ApiRegistroDispositivo/5
        [ResponseType(typeof(REG_DISPOSITIVO))]
        public IHttpActionResult DeleteREG_DISPOSITIVO(int id)
        {
            REG_DISPOSITIVO rEG_DISPOSITIVO = db.REG_DISPOSITIVO.Find(id);
            if (rEG_DISPOSITIVO == null)
            {
                return NotFound();
            }

            db.REG_DISPOSITIVO.Remove(rEG_DISPOSITIVO);
            db.SaveChanges();

            return Ok(rEG_DISPOSITIVO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool REG_DISPOSITIVOExists(int id)
        {
            return db.REG_DISPOSITIVO.Count(e => e.id == id) > 0;
        }
    }
}