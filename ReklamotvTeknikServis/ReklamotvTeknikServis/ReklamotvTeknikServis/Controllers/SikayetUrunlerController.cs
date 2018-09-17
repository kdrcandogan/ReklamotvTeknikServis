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
    public class SikayetUrunlerController : Controller
    {
        private ReklamoStokTakipEntities db = new ReklamoStokTakipEntities();

        // GET: /SikayetUrunler/
        public async Task<ActionResult> Index()
        {
            var sikayeturunler = db.SikayetUrunler.Include(s => s.Firmalar).Include(s => s.SatilanUrunler).Include(s => s.SikayetTur).Include(s => s.StoktakiUrunler);
            return View(await sikayeturunler.ToListAsync());
        }

        // GET: /SikayetUrunler/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SikayetUrunler sikayeturunler = await db.SikayetUrunler.FindAsync(id);
            if (sikayeturunler == null)
            {
                return HttpNotFound();
            }
            return View(sikayeturunler);
        }

        // GET: /SikayetUrunler/Create
        public ActionResult Create()
        {
            ViewBag.FirmaId = new SelectList(db.Firmalar, "FirmaId", "FirmaAdi");
            ViewBag.SatilanUrunId = new SelectList(db.SatilanUrunler, "SatilanUrun_id", "SatilanUrun_adi");
            ViewBag.SikayetTuruId = new SelectList(db.SikayetTur, "SikayetTurId", "SikayetAciklama");
            ViewBag.UrunStokId = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi");
            return View();
        }

        // POST: /SikayetUrunler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="SikayetId,SatilanUrunId,UrunStokId,SikayetTuruId,FirmaId,UrunAdet,SikayetTarihi")] SikayetUrunler sikayeturunler)
        {
            if (ModelState.IsValid)
            {
                sikayeturunler.SikayetTarihi = DateTime.Now;
                db.SikayetUrunler.Add(sikayeturunler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FirmaId = new SelectList(db.Firmalar, "FirmaId", "FirmaAdi", sikayeturunler.FirmaId);
            ViewBag.SatilanUrunId = new SelectList(db.SatilanUrunler, "SatilanUrun_id", "SatilanUrun_adi", sikayeturunler.SatilanUrunId);
            ViewBag.SikayetTuruId = new SelectList(db.SikayetTur, "SikayetTurId", "SikayetAciklama", sikayeturunler.SikayetTuruId);
            ViewBag.UrunStokId = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi", sikayeturunler.UrunStokId);
            return View(sikayeturunler);
        }

        // GET: /SikayetUrunler/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SikayetUrunler sikayeturunler = await db.SikayetUrunler.FindAsync(id);
            if (sikayeturunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirmaId = new SelectList(db.Firmalar, "FirmaId", "FirmaAdi", sikayeturunler.FirmaId);
            ViewBag.SatilanUrunId = new SelectList(db.SatilanUrunler, "SatilanUrun_id", "SatilanUrun_adi", sikayeturunler.SatilanUrunId);
            ViewBag.SikayetTuruId = new SelectList(db.SikayetTur, "SikayetTurId", "SikayetAciklama", sikayeturunler.SikayetTuruId);
            ViewBag.UrunStokId = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi", sikayeturunler.UrunStokId);
            return View(sikayeturunler);
        }

        // POST: /SikayetUrunler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SikayetId,SatilanUrunId,UrunStokId,SikayetTuruId,FirmaId,UrunAdet,SikayetTarihi")] SikayetUrunler sikayeturunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sikayeturunler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FirmaId = new SelectList(db.Firmalar, "FirmaId", "FirmaAdi", sikayeturunler.FirmaId);
            ViewBag.SatilanUrunId = new SelectList(db.SatilanUrunler, "SatilanUrun_id", "SatilanUrun_adi", sikayeturunler.SatilanUrunId);
            ViewBag.SikayetTuruId = new SelectList(db.SikayetTur, "SikayetTurId", "SikayetAciklama", sikayeturunler.SikayetTuruId);
            ViewBag.UrunStokId = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi", sikayeturunler.UrunStokId);
            return View(sikayeturunler);
        }

        // GET: /SikayetUrunler/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SikayetUrunler sikayeturunler = await db.SikayetUrunler.FindAsync(id);
            if (sikayeturunler == null)
            {
                return HttpNotFound();
            }
            return View(sikayeturunler);
        }

        // POST: /SikayetUrunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SikayetUrunler sikayeturunler = await db.SikayetUrunler.FindAsync(id);
            db.SikayetUrunler.Remove(sikayeturunler);
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
