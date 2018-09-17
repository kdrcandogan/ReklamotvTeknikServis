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
    public class SikayetTanimController : Controller
    {
        private ReklamoStokTakipEntities db = new ReklamoStokTakipEntities();

        // GET: /SikayetTanim/
        public async Task<ActionResult> Index()
        {
            return View(await db.SikayetTur.ToListAsync());
        }

        // GET: /SikayetTanim/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SikayetTur sikayettur = await db.SikayetTur.FindAsync(id);
            if (sikayettur == null)
            {
                return HttpNotFound();
            }
            return View(sikayettur);
        }

        // GET: /SikayetTanim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SikayetTanim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="SikayetTurId,SikayetAciklama")] SikayetTur sikayettur)
        {
            if (ModelState.IsValid)
            {
                db.SikayetTur.Add(sikayettur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sikayettur);
        }

        // GET: /SikayetTanim/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SikayetTur sikayettur = await db.SikayetTur.FindAsync(id);
            if (sikayettur == null)
            {
                return HttpNotFound();
            }
            return View(sikayettur);
        }

        // POST: /SikayetTanim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SikayetTurId,SikayetAciklama")] SikayetTur sikayettur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sikayettur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sikayettur);
        }

        // GET: /SikayetTanim/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SikayetTur sikayettur = await db.SikayetTur.FindAsync(id);
            if (sikayettur == null)
            {
                return HttpNotFound();
            }
            return View(sikayettur);
        }

        // POST: /SikayetTanim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SikayetTur sikayettur = await db.SikayetTur.FindAsync(id);
            db.SikayetTur.Remove(sikayettur);
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
