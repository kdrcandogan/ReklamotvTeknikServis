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
    public class RezerveUrunlerController : Controller
    {
        private ReklamoStokTakipEntities db = new ReklamoStokTakipEntities();

        // GET: /RezerveUrunler/
        public async Task<ActionResult> Index()
        {
            var reserveurunler = db.ReserveUrunler.Include(r => r.Firmalar).Include(r => r.StoktakiUrunler);
            return View(await reserveurunler.ToListAsync());
        }

        // GET: /RezerveUrunler/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveUrunler reserveurunler = await db.ReserveUrunler.FindAsync(id);
            if (reserveurunler == null)
            {
                return HttpNotFound();
            }
            return View(reserveurunler);
        }

        // GET: /RezerveUrunler/Create
        public ActionResult Create()
        {
            ViewBag.ReserveYapilanFirma = new SelectList(db.Firmalar, "FirmaId", "FirmaAdi");
            ViewBag.UrunStokId = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi");
            return View();
        }

        // POST: /RezerveUrunler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ReseverId,UrunStokId,ReserveUrunAdet,ReserveTarihi,ReserveYapilanFirma")] ReserveUrunler reserveurunler)
        {
            if (ModelState.IsValid)
            {
                reserveurunler.ReserveTarihi = DateTime.Now;
                db.ReserveUrunler.Add(reserveurunler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ReserveYapilanFirma = new SelectList(db.Firmalar, "FirmaId", "FirmaAdi", reserveurunler.ReserveYapilanFirma);
            ViewBag.UrunStokId = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi", reserveurunler.UrunStokId);
            return View(reserveurunler);
        }

        // GET: /RezerveUrunler/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveUrunler reserveurunler = await db.ReserveUrunler.FindAsync(id);
            if (reserveurunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReserveYapilanFirma = new SelectList(db.Firmalar, "FirmaId", "FirmaAdi", reserveurunler.ReserveYapilanFirma);
            ViewBag.UrunStokId = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi", reserveurunler.UrunStokId);
            return View(reserveurunler);
        }

        // POST: /RezerveUrunler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ReseverId,UrunStokId,ReserveUrunAdet,ReserveTarihi,ReserveYapilanFirma")] ReserveUrunler reserveurunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserveurunler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ReserveYapilanFirma = new SelectList(db.Firmalar, "FirmaId", "FirmaAdi", reserveurunler.ReserveYapilanFirma);
            ViewBag.UrunStokId = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi", reserveurunler.UrunStokId);
            return View(reserveurunler);
        }

        // GET: /RezerveUrunler/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveUrunler reserveurunler = await db.ReserveUrunler.FindAsync(id);
            if (reserveurunler == null)
            {
                return HttpNotFound();
            }
            return View(reserveurunler);
        }

        // POST: /RezerveUrunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReserveUrunler reserveurunler = await db.ReserveUrunler.FindAsync(id);
            db.ReserveUrunler.Remove(reserveurunler);
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
