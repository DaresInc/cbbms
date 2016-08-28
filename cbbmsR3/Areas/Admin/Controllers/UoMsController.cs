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
using cbbmsRnD.Models.SysMgt;

namespace cbbmsR3.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UoMsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UoMs
        public async Task<ActionResult> Index()
        {
            return View(await db.UoMs.ToListAsync());
        }

        // GET: UoMs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UoM uoM = await db.UoMs.FindAsync(id);
            if (uoM == null)
            {
                return HttpNotFound();
            }
            return View(uoM);
        }

        // GET: UoMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UoMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UoMId,Description,Abbriviation,CreatedOn,Remarks")] UoM uoM)
        {
            if (ModelState.IsValid)
            {
                db.UoMs.Add(uoM);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(uoM);
        }

        // GET: UoMs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UoM uoM = await db.UoMs.FindAsync(id);
            if (uoM == null)
            {
                return HttpNotFound();
            }
            return View(uoM);
        }

        // POST: UoMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UoMId,Description,Abbriviation,CreatedOn,Remarks")] UoM uoM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uoM).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(uoM);
        }

        // GET: UoMs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UoM uoM = await db.UoMs.FindAsync(id);
            if (uoM == null)
            {
                return HttpNotFound();
            }
            return View(uoM);
        }

        // POST: UoMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UoM uoM = await db.UoMs.FindAsync(id);
            db.UoMs.Remove(uoM);
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
