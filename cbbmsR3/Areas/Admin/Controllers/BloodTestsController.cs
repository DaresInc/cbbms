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

namespace cbbmsR3.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class BloodTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BloodTests
        public async Task<ActionResult> Index()
        {
            var bloodTests = db.BloodTests.Include(b => b.BloodSmaple).Include(b => b.BloodTestType).Include(b => b.Status);
            return View(await bloodTests.ToListAsync());
        }

        // GET: BloodTests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTest bloodTest = await db.BloodTests.FindAsync(id);
            if (bloodTest == null)
            {
                return HttpNotFound();
            }
            return View(bloodTest);
        }

        // GET: BloodTests/Create
        public ActionResult Create()
        {
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId");
            ViewBag.BloodTestTypeId = new SelectList(db.BloodTestTypes, "BloodTestTypeId", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: BloodTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BloodTestId,BloodTestTypeId,BloodSampleId,StatusId,Remarks,CreatedOn")] BloodTest bloodTest)
        {
            if (ModelState.IsValid)
            {
                db.BloodTests.Add(bloodTest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bloodTest.BloodSampleId);
            ViewBag.BloodTestTypeId = new SelectList(db.BloodTestTypes, "BloodTestTypeId", "Description", bloodTest.BloodTestTypeId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", bloodTest.StatusId);
            return View(bloodTest);
        }

        // GET: BloodTests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTest bloodTest = await db.BloodTests.FindAsync(id);
            if (bloodTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bloodTest.BloodSampleId);
            ViewBag.BloodTestTypeId = new SelectList(db.BloodTestTypes, "BloodTestTypeId", "Description", bloodTest.BloodTestTypeId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", bloodTest.StatusId);
            return View(bloodTest);
        }

        // POST: BloodTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BloodTestId,BloodTestTypeId,BloodSampleId,StatusId,Remarks,CreatedOn")] BloodTest bloodTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodTest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bloodTest.BloodSampleId);
            ViewBag.BloodTestTypeId = new SelectList(db.BloodTestTypes, "BloodTestTypeId", "Description", bloodTest.BloodTestTypeId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", bloodTest.StatusId);
            return View(bloodTest);
        }

        // GET: BloodTests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTest bloodTest = await db.BloodTests.FindAsync(id);
            if (bloodTest == null)
            {
                return HttpNotFound();
            }
            return View(bloodTest);
        }

        // POST: BloodTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BloodTest bloodTest = await db.BloodTests.FindAsync(id);
            db.BloodTests.Remove(bloodTest);
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
