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
    public class BloodTestDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BloodTestDetails
        public async Task<ActionResult> Index()
        {
            var bloodTestDetails = db.BloodTestDetails.Include(b => b.BloodTest);
            return View(await bloodTestDetails.ToListAsync());
        }

        // GET: BloodTestDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTestDetail bloodTestDetail = await db.BloodTestDetails.FindAsync(id);
            if (bloodTestDetail == null)
            {
                return HttpNotFound();
            }
            return View(bloodTestDetail);
        }

        // GET: BloodTestDetails/Create
        public ActionResult Create()
        {
            ViewBag.BloodTestId = new SelectList(db.BloodTests, "BloodTestId", "Remarks");
            return View();
        }

        // POST: BloodTestDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BloodTestDetailId,BloodTestId,Value,CreatedOn,Remarks")] BloodTestDetail bloodTestDetail)
        {
            if (ModelState.IsValid)
            {
                db.BloodTestDetails.Add(bloodTestDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BloodTestId = new SelectList(db.BloodTests, "BloodTestId", "Remarks", bloodTestDetail.BloodTestId);
            return View(bloodTestDetail);
        }

        // GET: BloodTestDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTestDetail bloodTestDetail = await db.BloodTestDetails.FindAsync(id);
            if (bloodTestDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodTestId = new SelectList(db.BloodTests, "BloodTestId", "Remarks", bloodTestDetail.BloodTestId);
            return View(bloodTestDetail);
        }

        // POST: BloodTestDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BloodTestDetailId,BloodTestId,Value,CreatedOn,Remarks")] BloodTestDetail bloodTestDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodTestDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BloodTestId = new SelectList(db.BloodTests, "BloodTestId", "Remarks", bloodTestDetail.BloodTestId);
            return View(bloodTestDetail);
        }

        // GET: BloodTestDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTestDetail bloodTestDetail = await db.BloodTestDetails.FindAsync(id);
            if (bloodTestDetail == null)
            {
                return HttpNotFound();
            }
            return View(bloodTestDetail);
        }

        // POST: BloodTestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BloodTestDetail bloodTestDetail = await db.BloodTestDetails.FindAsync(id);
            db.BloodTestDetails.Remove(bloodTestDetail);
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
