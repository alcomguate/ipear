using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using REGISTROCEL_IPEAR.Models;

namespace REGISTROCEL_IPEAR.Controllers
{
    public class REG_DISPOSITIVOController : Controller
    {
        private IPEAREntities db = new IPEAREntities();
        private ApiRegistroDispositivoController api = new ApiRegistroDispositivoController();

        // GET: REG_DISPOSITIVO
        public async Task<ActionResult> Index()
        {
            var rEG_DISPOSITIVO = db.REG_DISPOSITIVO.Include(r => r.CAT_COLOR).Include(r => r.CAT_FABRICA).Include(r => r.CAT_GAMA);
            return View(await rEG_DISPOSITIVO.ToListAsync());
        }

        // GET: REG_DISPOSITIVO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REG_DISPOSITIVO rEG_DISPOSITIVO = await db.REG_DISPOSITIVO.FindAsync(id);
            if (rEG_DISPOSITIVO == null)
            {
                return HttpNotFound();
            }
            return View(rEG_DISPOSITIVO);
        }

        // GET: REG_DISPOSITIVO/Create
        public ActionResult Create()
        {
            ViewBag.color = new SelectList(db.CAT_COLOR, "id", "nombre");
            ViewBag.fabrica_ensamblaje = new SelectList(db.CAT_FABRICA, "id", "nombre");
            ViewBag.gama = new SelectList(db.CAT_GAMA, "id", "descripcion");
            return View();
        }

        

        // POST: REG_DISPOSITIVO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,no_serie,gama,color,fabrica_ensamblaje,costo_fabricacion_final,fecha_in,usuario_in,fech_mod,usuario_mod")] REG_DISPOSITIVO rEG_DISPOSITIVO)
        {
            if (ModelState.IsValid)
            {
                rEG_DISPOSITIVO.fecha_in = DateTime.Now;
                rEG_DISPOSITIVO.usuario_in = User.Identity.Name;
                api.PostREG_DISPOSITIVO(rEG_DISPOSITIVO);
                return RedirectToAction("Index");
            }

            ViewBag.color = new SelectList(db.CAT_COLOR, "id", "nombre", rEG_DISPOSITIVO.color);
            ViewBag.fabrica_ensamblaje = new SelectList(db.CAT_FABRICA, "id", "nombre", rEG_DISPOSITIVO.fabrica_ensamblaje);
            ViewBag.gama = new SelectList(db.CAT_GAMA, "id", "descripcion", rEG_DISPOSITIVO.gama);
            return View(rEG_DISPOSITIVO);
        }

        // GET: REG_DISPOSITIVO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REG_DISPOSITIVO rEG_DISPOSITIVO = await db.REG_DISPOSITIVO.FindAsync(id);
            if (rEG_DISPOSITIVO == null)
            {
                return HttpNotFound();
            }
            ViewBag.color = new SelectList(db.CAT_COLOR, "id", "nombre", rEG_DISPOSITIVO.color);
            ViewBag.fabrica_ensamblaje = new SelectList(db.CAT_FABRICA, "id", "nombre", rEG_DISPOSITIVO.fabrica_ensamblaje);
            ViewBag.gama = new SelectList(db.CAT_GAMA, "id", "descripcion", rEG_DISPOSITIVO.gama);
            return View(rEG_DISPOSITIVO);
        }

        // POST: REG_DISPOSITIVO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,no_serie,gama,color,fabrica_ensamblaje,costo_fabricacion_final,fecha_in,usuario_in,fech_mod,usuario_mod")] REG_DISPOSITIVO rEG_DISPOSITIVO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEG_DISPOSITIVO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.color = new SelectList(db.CAT_COLOR, "id", "nombre", rEG_DISPOSITIVO.color);
            ViewBag.fabrica_ensamblaje = new SelectList(db.CAT_FABRICA, "id", "nombre", rEG_DISPOSITIVO.fabrica_ensamblaje);
            ViewBag.gama = new SelectList(db.CAT_GAMA, "id", "descripcion", rEG_DISPOSITIVO.gama);
            return View(rEG_DISPOSITIVO);
        }

        // GET: REG_DISPOSITIVO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REG_DISPOSITIVO rEG_DISPOSITIVO = await db.REG_DISPOSITIVO.FindAsync(id);
            if (rEG_DISPOSITIVO == null)
            {
                return HttpNotFound();
            }
            return View(rEG_DISPOSITIVO);
        }

        // POST: REG_DISPOSITIVO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            REG_DISPOSITIVO rEG_DISPOSITIVO = await db.REG_DISPOSITIVO.FindAsync(id);
            db.REG_DISPOSITIVO.Remove(rEG_DISPOSITIVO);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
