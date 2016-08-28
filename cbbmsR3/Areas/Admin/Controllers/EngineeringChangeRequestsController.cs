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
    public class EngineeringChangeRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EngineeringChangeRequests
        public async Task<ActionResult> Index()
        {
            var engineeringChangeRequests = db.EngineeringChangeRequests.Include(e => e.Component).Include(e => e.Status);
            return View(await engineeringChangeRequests.ToListAsync());
        }

        // GET: EngineeringChangeRequests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineeringChangeRequest engineeringChangeRequest = await db.EngineeringChangeRequests.FindAsync(id);
            if (engineeringChangeRequest == null)
            {
                return HttpNotFound();
            }
            return View(engineeringChangeRequest);
        }

        // GET: EngineeringChangeRequests/Create
        public ActionResult Create()
        {
            ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: EngineeringChangeRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EngineeringChangeRequestId,ComponentId,Description,ChangeType,RequesteeId,StatusId,Remarks,CreatedOn")] EngineeringChangeRequest engineeringChangeRequest)
        {
            if (ModelState.IsValid)
            {
                db.EngineeringChangeRequests.Add(engineeringChangeRequest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "Description", engineeringChangeRequest.ComponentId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", engineeringChangeRequest.StatusId);
            return View(engineeringChangeRequest);
        }

        // GET: EngineeringChangeRequests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineeringChangeRequest engineeringChangeRequest = await db.EngineeringChangeRequests.FindAsync(id);
            if (engineeringChangeRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "Description", engineeringChangeRequest.ComponentId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", engineeringChangeRequest.StatusId);
            return View(engineeringChangeRequest);
        }

        // POST: EngineeringChangeRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EngineeringChangeRequestId,ComponentId,Description,ChangeType,RequesteeId,StatusId,Remarks,CreatedOn")] EngineeringChangeRequest engineeringChangeRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engineeringChangeRequest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "Description", engineeringChangeRequest.ComponentId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", engineeringChangeRequest.StatusId);
            return View(engineeringChangeRequest);
        }

        // GET: EngineeringChangeRequests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineeringChangeRequest engineeringChangeRequest = await db.EngineeringChangeRequests.FindAsync(id);
            if (engineeringChangeRequest == null)
            {
                return HttpNotFound();
            }
            return View(engineeringChangeRequest);
        }

        // POST: EngineeringChangeRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EngineeringChangeRequest engineeringChangeRequest = await db.EngineeringChangeRequests.FindAsync(id);
            db.EngineeringChangeRequests.Remove(engineeringChangeRequest);
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
