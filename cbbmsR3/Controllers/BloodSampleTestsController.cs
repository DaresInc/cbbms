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
    public class BloodSampleTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BloodSampleTests
        public async Task<ActionResult> Index()
        {
            var bloodSampleTests = db.BloodSampleTests.Include(b => b.BloodSample).Include(b => b.BloodTest);
            return View(await bloodSampleTests.ToListAsync());
        }

        // GET: BloodSampleTests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSampleTest bloodSampleTest = await db.BloodSampleTests.FindAsync(id);
            if (bloodSampleTest == null)
            {
                return HttpNotFound();
            }
            return View(bloodSampleTest);
        }

        // GET: BloodSampleTests/Create
        public ActionResult Create()
        {
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId");
            ViewBag.BloodTestId = new SelectList(db.BloodTests, "BloodTestId", "Remarks");
            return View();
        }

        // POST: BloodSampleTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BloodSampleTestId,BloodTestId,BloodSampleId")] BloodSampleTest bloodSampleTest)
        {
            if (ModelState.IsValid)
            {
                db.BloodSampleTests.Add(bloodSampleTest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bloodSampleTest.BloodSampleId);
            ViewBag.BloodTestId = new SelectList(db.BloodTests, "BloodTestId", "Remarks", bloodSampleTest.BloodTestId);
            return View(bloodSampleTest);
        }

        // GET: BloodSampleTests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSampleTest bloodSampleTest = await db.BloodSampleTests.FindAsync(id);
            if (bloodSampleTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bloodSampleTest.BloodSampleId);
            ViewBag.BloodTestId = new SelectList(db.BloodTests, "BloodTestId", "Remarks", bloodSampleTest.BloodTestId);
            return View(bloodSampleTest);
        }

        // POST: BloodSampleTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BloodSampleTestId,BloodTestId,BloodSampleId")] BloodSampleTest bloodSampleTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodSampleTest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bloodSampleTest.BloodSampleId);
            ViewBag.BloodTestId = new SelectList(db.BloodTests, "BloodTestId", "Remarks", bloodSampleTest.BloodTestId);
            return View(bloodSampleTest);
        }

        // GET: BloodSampleTests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSampleTest bloodSampleTest = await db.BloodSampleTests.FindAsync(id);
            if (bloodSampleTest == null)
            {
                return HttpNotFound();
            }
            return View(bloodSampleTest);
        }

        // POST: BloodSampleTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BloodSampleTest bloodSampleTest = await db.BloodSampleTests.FindAsync(id);
            db.BloodSampleTests.Remove(bloodSampleTest);
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
