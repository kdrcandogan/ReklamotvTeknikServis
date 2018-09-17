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
    public class StoktakiUrunlerController : Controller
    {
        private ReklamoStokTakipEntities db = new ReklamoStokTakipEntities();

        public async Task<ActionResult> StokBirlestir()
        {
            return View(await db.StoktakiUrunler.ToListAsync());
        }

        [HttpPost]
        public string StokKaydet(int stokId,int[] seciliUrunler)
        {
            for (int i = 0; i < seciliUrunler.Length; i++)
            {
                BirlestirilenParcalar bp = new BirlestirilenParcalar() {StokId=stokId,BirlestirilenUrunId=seciliUrunler[i] };
                db.BirlestirilenParcalar.Add(bp);
                db.SaveChanges();
            }
            var items =db.BirlestirilenParcalar.Where(a => a.StokId==stokId).ToList();
            string result = @"<p style='color:lightgreen'>Stok Kaydı Başarılı</p>";
            foreach (var item in items)
            {
                result+=item.StoktakiUrunler.UrunAdi+"</br>";
            }

            return result;
        }


        
        // GET: /StoktakiUrunler/
        public async Task<ActionResult> Index()
        {
            var stoktakiurunler = db.StoktakiUrunler.Include(s => s.GenelUrunler);
            return View(await stoktakiurunler.ToListAsync());
        }

        // GET: /StoktakiUrunler/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoktakiUrunler stoktakiurunler = await db.StoktakiUrunler.FindAsync(id);
            if (stoktakiurunler == null)
            {
                return HttpNotFound();
            }
            return View(stoktakiurunler);
        }

        // GET: /StoktakiUrunler/Create
        public ActionResult Create()
        {
            ViewBag.UrunTur_id = new SelectList(db.GenelUrunler, "Urun_id", "Urun_adi");
            return View();
        }

        // POST: /StoktakiUrunler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UrunStok_id,UrunAlisFiyati,UrunTur_id,UrunAdi,UrunAdet")] StoktakiUrunler stoktakiurunler)
        {
            if (ModelState.IsValid)
            {
                stoktakiurunler.UrunGirisTarihi = DateTime.Now;
                db.StoktakiUrunler.Add(stoktakiurunler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UrunTur_id = new SelectList(db.GenelUrunler, "Urun_id", "Urun_adi", stoktakiurunler.UrunTur_id);
            return View(stoktakiurunler);
        }

        // GET: /StoktakiUrunler/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoktakiUrunler stoktakiurunler = await db.StoktakiUrunler.FindAsync(id);
            if (stoktakiurunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrunTur_id = new SelectList(db.GenelUrunler, "Urun_id", "Urun_adi", stoktakiurunler.UrunTur_id);
            return View(stoktakiurunler);
        }

        // POST: /StoktakiUrunler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UrunStok_id,UrunAlisFiyati,UrunTur_id,UrunAdi,UrunAdet")] StoktakiUrunler stoktakiurunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stoktakiurunler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UrunTur_id = new SelectList(db.GenelUrunler, "Urun_id", "Urun_adi", stoktakiurunler.UrunTur_id);
            return View(stoktakiurunler);
        }

        // GET: /StoktakiUrunler/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoktakiUrunler stoktakiurunler = await db.StoktakiUrunler.FindAsync(id);
            if (stoktakiurunler == null)
            {
                return HttpNotFound();
            }
            return View(stoktakiurunler);
        }

        // POST: /StoktakiUrunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StoktakiUrunler stoktakiurunler = await db.StoktakiUrunler.FindAsync(id);
            db.StoktakiUrunler.Remove(stoktakiurunler);
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
