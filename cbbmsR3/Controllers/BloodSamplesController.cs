using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cbbmsR3.Models;
using cbbmsR3.Models.LabMgt;

namespace cbbmsR3.Controllers
{
    public class BloodSamplesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BloodSamples
        public async Task<ActionResult> Index()
        {
            var bloodSamples = db.BloodSamples.Include(b => b.InventoryItem).Include(b => b.Status);
            return View(await bloodSamples.ToListAsync());
        }

        // GET: BloodSamples/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSample bloodSample = await db.BloodSamples.FindAsync(id);
            if (bloodSample == null)
            {
                return HttpNotFound();
            }
            return View(bloodSample);
        }

        // GET: BloodSamples/Create
        public ActionResult Create()
        {
            ViewBag.InventoryItemId = new SelectList(db.InventoryItems, "InventoryItemId", "ReferenceDocument");
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: BloodSamples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BloodSampleId,PersonId,InventoryItemId,CreatedOn,StatusId")] BloodSample bloodSample)
        {
            if (ModelState.IsValid)
            {
                db.BloodSamples.Add(bloodSample);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryItemId = new SelectList(db.InventoryItems, "InventoryItemId", "ReferenceDocument", bloodSample.InventoryItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", bloodSample.StatusId);
            return View(bloodSample);
        }

        // GET: BloodSamples/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSample bloodSample = await db.BloodSamples.FindAsync(id);
            bloodSample.BloodSampleTests = await db.BloodSampleTests.Where(bt=> bt.BloodSampleId==id).ToListAsync();
            if (bloodSample == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryItemId = new SelectList(db.InventoryItems, "InventoryItemId", "ReferenceDocument", bloodSample.InventoryItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", bloodSample.StatusId);
            ViewBag.PersonId = new SelectList(db.AppUsers, "AppUserId", "UserName", bloodSample.PersonId).ToList() ;
            return View(bloodSample);
        }

        // POST: BloodSamples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BloodSampleId,PersonId,InventoryItemId,CreatedOn,StatusId")] BloodSample bloodSample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodSample).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InventoryItemId = new SelectList(db.InventoryItems, "InventoryItemId", "ReferenceDocument", bloodSample.InventoryItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", bloodSample.StatusId);
            return View(bloodSample);
        }

        // GET: BloodSamples/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSample bloodSample = await db.BloodSamples.FindAsync(id);
            if (bloodSample == null)
            {
                return HttpNotFound();
            }
            return View(bloodSample);
        }

        // POST: BloodSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BloodSample bloodSample = await db.BloodSamples.FindAsync(id);
            db.BloodSamples.Remove(bloodSample);
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
