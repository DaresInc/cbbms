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
    public class BloodTestDefaultValuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BloodTestDefaultValues
        public async Task<ActionResult> Index()
        {
            var bloodTestDefaultValues = db.BloodTestDefaultValues.Include(b => b.BloodTestType);
            return View(await bloodTestDefaultValues.ToListAsync());
        }

        // GET: BloodTestDefaultValues/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTestDefaultValue bloodTestDefaultValue = await db.BloodTestDefaultValues.FindAsync(id);
            if (bloodTestDefaultValue == null)
            {
                return HttpNotFound();
            }
            return View(bloodTestDefaultValue);
        }

        // GET: BloodTestDefaultValues/Create
        public ActionResult Create()
        {
            ViewBag.BloodTestTypeId = new SelectList(db.BloodTestTypes, "BloodTestTypeId", "Description");
            return View();
        }

        // POST: BloodTestDefaultValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BloodTestDefaultValueId,BloodTestTypeId,Attribute,DefaultValue,CreatedOn")] BloodTestDefaultValue bloodTestDefaultValue)
        {
            if (ModelState.IsValid)
            {
                db.BloodTestDefaultValues.Add(bloodTestDefaultValue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BloodTestTypeId = new SelectList(db.BloodTestTypes, "BloodTestTypeId", "Description", bloodTestDefaultValue.BloodTestTypeId);
            return View(bloodTestDefaultValue);
        }

        // GET: BloodTestDefaultValues/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTestDefaultValue bloodTestDefaultValue = await db.BloodTestDefaultValues.FindAsync(id);
            if (bloodTestDefaultValue == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodTestTypeId = new SelectList(db.BloodTestTypes, "BloodTestTypeId", "Description", bloodTestDefaultValue.BloodTestTypeId);
            return View(bloodTestDefaultValue);
        }

        // POST: BloodTestDefaultValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BloodTestDefaultValueId,BloodTestTypeId,Attribute,DefaultValue,CreatedOn")] BloodTestDefaultValue bloodTestDefaultValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodTestDefaultValue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BloodTestTypeId = new SelectList(db.BloodTestTypes, "BloodTestTypeId", "Description", bloodTestDefaultValue.BloodTestTypeId);
            return View(bloodTestDefaultValue);
        }

        // GET: BloodTestDefaultValues/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTestDefaultValue bloodTestDefaultValue = await db.BloodTestDefaultValues.FindAsync(id);
            if (bloodTestDefaultValue == null)
            {
                return HttpNotFound();
            }
            return View(bloodTestDefaultValue);
        }

        // POST: BloodTestDefaultValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BloodTestDefaultValue bloodTestDefaultValue = await db.BloodTestDefaultValues.FindAsync(id);
            db.BloodTestDefaultValues.Remove(bloodTestDefaultValue);
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
