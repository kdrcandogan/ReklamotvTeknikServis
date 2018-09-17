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
    public class PersonelController : Controller
    {
        private ReklamoStokTakipEntities db = new ReklamoStokTakipEntities();

        // GET: /Personel/
        public async Task<ActionResult> Index()
        {
            return View(await db.PersonelTable.ToListAsync());
        }

        // GET: /Personel/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelTable personeltable = await db.PersonelTable.FindAsync(id);
            if (personeltable == null)
            {
                return HttpNotFound();
            }
            return View(personeltable);
        }

        // GET: /Personel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Personel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Personel_id,Personel_adi,Personel_soyadi,Personel_departman")] PersonelTable personeltable)
        {
            if (ModelState.IsValid)
            {
                db.PersonelTable.Add(personeltable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(personeltable);
        }

        // GET: /Personel/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelTable personeltable = await db.PersonelTable.FindAsync(id);
            if (personeltable == null)
            {
                return HttpNotFound();
            }
            return View(personeltable);
        }

        // POST: /Personel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Personel_id,Personel_adi,Personel_soyadi,Personel_departman")] PersonelTable personeltable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personeltable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(personeltable);
        }

        // GET: /Personel/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelTable personeltable = await db.PersonelTable.FindAsync(id);
            if (personeltable == null)
            {
                return HttpNotFound();
            }
            return View(personeltable);
        }

        // POST: /Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PersonelTable personeltable = await db.PersonelTable.FindAsync(id);
            db.PersonelTable.Remove(personeltable);
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
