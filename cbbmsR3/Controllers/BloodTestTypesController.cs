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
    public class BloodTestTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BloodTestTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.BloodTestTypes.ToListAsync());
        }

        // GET: BloodTestTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTestType bloodTestType = await db.BloodTestTypes.FindAsync(id);
            if (bloodTestType == null)
            {
                return HttpNotFound();
            }
            return View(bloodTestType);
        }

        // GET: BloodTestTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodTestTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BloodTestTypeId,Description,Abbreviation")] BloodTestType bloodTestType)
        {
            if (ModelState.IsValid)
            {
                db.BloodTestTypes.Add(bloodTestType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bloodTestType);
        }

        // GET: BloodTestTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTestType bloodTestType = await db.BloodTestTypes.FindAsync(id);
            if (bloodTestType == null)
            {
                return HttpNotFound();
            }
            return View(bloodTestType);
        }

        // POST: BloodTestTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BloodTestTypeId,Description,Abbreviation")] BloodTestType bloodTestType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodTestType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bloodTestType);
        }

        // GET: BloodTestTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTestType bloodTestType = await db.BloodTestTypes.FindAsync(id);
            if (bloodTestType == null)
            {
                return HttpNotFound();
            }
            return View(bloodTestType);
        }

        // POST: BloodTestTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BloodTestType bloodTestType = await db.BloodTestTypes.FindAsync(id);
            db.BloodTestTypes.Remove(bloodTestType);
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
