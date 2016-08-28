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
using cbbmsRnD.Models.CnfMgt;

namespace cbbmsR3.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class BuildHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BuildHistories
        public async Task<ActionResult> Index()
        {
            var buildHistories = db.BuildHistories.Include(b => b.Component).Include(b => b.Status);
            return View(await buildHistories.ToListAsync());
        }

        // GET: BuildHistories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildHistory buildHistory = await db.BuildHistories.FindAsync(id);
            if (buildHistory == null)
            {
                return HttpNotFound();
            }
            return View(buildHistory);
        }

        // GET: BuildHistories/Create
        public ActionResult Create()
        {
            ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: BuildHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BuildHistoryId,ComponentId,Description,CreatedOn,Remarks,StatusId")] BuildHistory buildHistory)
        {
            if (ModelState.IsValid)
            {
                db.BuildHistories.Add(buildHistory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "Description", buildHistory.ComponentId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", buildHistory.StatusId);
            return View(buildHistory);
        }

        // GET: BuildHistories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildHistory buildHistory = await db.BuildHistories.FindAsync(id);
            if (buildHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "Description", buildHistory.ComponentId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", buildHistory.StatusId);
            return View(buildHistory);
        }

        // POST: BuildHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BuildHistoryId,ComponentId,Description,CreatedOn,Remarks,StatusId")] BuildHistory buildHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildHistory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "Description", buildHistory.ComponentId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", buildHistory.StatusId);
            return View(buildHistory);
        }

        // GET: BuildHistories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildHistory buildHistory = await db.BuildHistories.FindAsync(id);
            if (buildHistory == null)
            {
                return HttpNotFound();
            }
            return View(buildHistory);
        }

        // POST: BuildHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BuildHistory buildHistory = await db.BuildHistories.FindAsync(id);
            db.BuildHistories.Remove(buildHistory);
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
