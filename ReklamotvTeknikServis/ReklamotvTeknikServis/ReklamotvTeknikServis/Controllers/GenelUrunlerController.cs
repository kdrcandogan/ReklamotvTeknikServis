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
    public class GenelUrunlerController : Controller
    {
        private ReklamoStokTakipEntities db = new ReklamoStokTakipEntities();

        // GET: /GenelUrunler/
        public async Task<ActionResult> Index()
        {
            return View(await db.GenelUrunler.ToListAsync());
        }

        // GET: /GenelUrunler/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenelUrunler genelurunler = await db.GenelUrunler.FindAsync(id);
            if (genelurunler == null)
            {
                return HttpNotFound();
            }
            return View(genelurunler);
        }

        // GET: /GenelUrunler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GenelUrunler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Urun_id,Urun_adi,Urun_kodu")] GenelUrunler genelurunler)
        {
            if (ModelState.IsValid)
            {
                genelurunler.Urun_Ol_Tarih = DateTime.Now;
                db.GenelUrunler.Add(genelurunler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(genelurunler);
        }

        // GET: /GenelUrunler/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenelUrunler genelurunler = await db.GenelUrunler.FindAsync(id);
            if (genelurunler == null)
            {
                return HttpNotFound();
            }
            return View(genelurunler);
        }

        // POST: /GenelUrunler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Urun_id,Urun_adi,Urun_kodu")] GenelUrunler genelurunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genelurunler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(genelurunler);
        }

        // GET: /GenelUrunler/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenelUrunler genelurunler = await db.GenelUrunler.FindAsync(id);
            if (genelurunler == null)
            {
                return HttpNotFound();
            }
            return View(genelurunler);
        }

        // POST: /GenelUrunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GenelUrunler genelurunler = await db.GenelUrunler.FindAsync(id);
            db.GenelUrunler.Remove(genelurunler);
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
