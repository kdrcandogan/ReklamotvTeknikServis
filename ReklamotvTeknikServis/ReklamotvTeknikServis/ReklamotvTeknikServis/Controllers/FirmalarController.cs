using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReklamotvTeknikServis;

namespace ReklamotvTeknikServis.Controllers
{
    public class FirmalarController : Controller
    {
        private ReklamoStokTakipEntities db = new ReklamoStokTakipEntities();

        // GET: /Firmalar/
        public async Task<ActionResult> Index()
        {
            return View(await db.Firmalar.ToListAsync());
        }

        // GET: /Firmalar/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firmalar firmalar = await db.Firmalar.FindAsync(id);
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            return View(firmalar);
        }

        // GET: /Firmalar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Firmalar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="FirmaId,FirmaAdi,FirmaAdresi,FirmaTelNo,FirmaAlınanSatilan")] Firmalar firmalar)
        {
            if (ModelState.IsValid)
            {
                db.Firmalar.Add(firmalar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(firmalar);
        }

        // GET: /Firmalar/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firmalar firmalar = await db.Firmalar.FindAsync(id);
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            return View(firmalar);
        }

        // POST: /Firmalar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="FirmaId,FirmaAdi,FirmaAdresi,FirmaTelNo,FirmaAlınanSatilan")] Firmalar firmalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firmalar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(firmalar);
        }

        // GET: /Firmalar/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firmalar firmalar = await db.Firmalar.FindAsync(id);
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            return View(firmalar);
        }

        // POST: /Firmalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Firmalar firmalar = await db.Firmalar.FindAsync(id);
            db.Firmalar.Remove(firmalar);
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
