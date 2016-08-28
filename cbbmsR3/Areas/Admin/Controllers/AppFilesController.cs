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
    public class AppFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AppFiles
        public async Task<ActionResult> Index()
        {
            return View(await db.AppFiles.ToListAsync());
        }

        // GET: Admin/AppFiles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppFile appFile = await db.AppFiles.FindAsync(id);
            if (appFile == null)
            {
                return HttpNotFound();
            }
            return View(appFile);
        }

        // GET: Admin/AppFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AppFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AppFileId,FilePath,ContentType,FileName,Caption,UserId")] AppFile appFile)
        {
            if (ModelState.IsValid)
            {
                db.AppFiles.Add(appFile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(appFile);
        }

        // GET: Admin/AppFiles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppFile appFile = await db.AppFiles.FindAsync(id);
            if (appFile == null)
            {
                return HttpNotFound();
            }
            return View(appFile);
        }

        // POST: Admin/AppFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AppFileId,FilePath,ContentType,FileName,Caption,UserId")] AppFile appFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appFile).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(appFile);
        }

        // GET: Admin/AppFiles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppFile appFile = await db.AppFiles.FindAsync(id);
            if (appFile == null)
            {
                return HttpNotFound();
            }
            return View(appFile);
        }

        // POST: Admin/AppFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AppFile appFile = await db.AppFiles.FindAsync(id);
            db.AppFiles.Remove(appFile);
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
