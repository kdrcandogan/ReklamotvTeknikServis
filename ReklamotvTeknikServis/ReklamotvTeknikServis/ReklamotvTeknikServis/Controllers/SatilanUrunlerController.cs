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
    public class SatilanUrunlerController : Controller
    {
        private ReklamoStokTakipEntities db = new ReklamoStokTakipEntities();

        // GET: /SatilanUrunler/
        public async Task<ActionResult> Index()
        {
            var satilanurunler = db.SatilanUrunler.Include(s => s.GenelUrunler).Include(s => s.StoktakiUrunler).Include(s => s.PersonelTable);
            return View(await satilanurunler.ToListAsync());
        }

        // GET: /SatilanUrunler/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatilanUrunler satilanurunler = await db.SatilanUrunler.FindAsync(id);
            if (satilanurunler == null)
            {
                return HttpNotFound();
            }
            return View(satilanurunler);
        }

        // GET: /SatilanUrunler/Create
        public ActionResult Create()
        {
            ViewBag.UrunTur_id = new SelectList(db.GenelUrunler, "Urun_id", "Urun_adi");
            ViewBag.UrunStok_id = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi");
            ViewBag.SatanPersonel = new SelectList(db.PersonelTable, "Personel_id", "Personel_adi");
            return View();
        }

        // POST: /SatilanUrunler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="SatilanUrun_id,SatilanUrun_adi,SatanPersonel,UrununGirisTarihi,UrununSatilisTarihi,UrunSatisFiyati,UrunTur_id,UrunStok_id,UrunToplamKar,SatilanUrunAdet")] SatilanUrunler satilanurunler)
        {
            if (ModelState.IsValid)
            {
                if(satilanurunler.SatilanUrunAdet!=null)
                {
                    double satilanadet = satilanurunler.SatilanUrunAdet.Value;
                    var stok = db.StoktakiUrunler.Find(satilanurunler.UrunStok_id);
                    stok.UrunAdet = stok.UrunAdet - satilanadet;
                    await db.SaveChangesAsync();
                }
                
                satilanurunler.UrununSatilisTarihi = DateTime.Now;
                db.SatilanUrunler.Add(satilanurunler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UrunTur_id = new SelectList(db.GenelUrunler, "Urun_id", "Urun_adi", satilanurunler.UrunTur_id);
            ViewBag.UrunStok_id = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi", satilanurunler.UrunStok_id);
            ViewBag.SatanPersonel = new SelectList(db.PersonelTable, "Personel_id", "Personel_adi", satilanurunler.SatanPersonel);
            return View(satilanurunler);
        }

        // GET: /SatilanUrunler/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatilanUrunler satilanurunler = await db.SatilanUrunler.FindAsync(id);
            if (satilanurunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrunTur_id = new SelectList(db.GenelUrunler, "Urun_id", "Urun_adi", satilanurunler.UrunTur_id);
            ViewBag.UrunStok_id = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi", satilanurunler.UrunStok_id);
            ViewBag.SatanPersonel = new SelectList(db.PersonelTable, "Personel_id", "Personel_adi", satilanurunler.SatanPersonel);
            return View(satilanurunler);
        }

        // POST: /SatilanUrunler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SatilanUrun_id,SatilanUrun_adi,SatanPersonel,UrununGirisTarihi,UrununSatilisTarihi,UrunSatisFiyati,UrunTur_id,UrunStok_id,UrunToplamKar")] SatilanUrunler satilanurunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satilanurunler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UrunTur_id = new SelectList(db.GenelUrunler, "Urun_id", "Urun_adi", satilanurunler.UrunTur_id);
            ViewBag.UrunStok_id = new SelectList(db.StoktakiUrunler, "UrunStok_id", "UrunAdi", satilanurunler.UrunStok_id);
            ViewBag.SatanPersonel = new SelectList(db.PersonelTable, "Personel_id", "Personel_adi", satilanurunler.SatanPersonel);
            return View(satilanurunler);
        }

        // GET: /SatilanUrunler/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatilanUrunler satilanurunler = await db.SatilanUrunler.FindAsync(id);
            if (satilanurunler == null)
            {
                return HttpNotFound();
            }
            return View(satilanurunler);
        }

        // POST: /SatilanUrunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SatilanUrunler satilanurunler = await db.SatilanUrunler.FindAsync(id);
            db.SatilanUrunler.Remove(satilanurunler);
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
