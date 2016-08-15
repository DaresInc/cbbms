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
using System.IO;
using Microsoft.AspNet.Identity;

namespace cbbmsR3.Controllers
{
    public class AppFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppFiles
        public async Task<ActionResult> Index()
        {
            return View(await db.AppFiles.ToListAsync());
        }

        // GET: AppFiles/Details/5
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

        // GET: AppFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AppFileId,FilePath,ContentType,FileName,Caption,UserId")] AppFile appFile, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                    try
                    {
                        string FlName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(upload.FileName);
                        //string path = Path.Combine(Server.MapPath("~/Imgs/AppFiles"),Path.GetFileName(upload.FileName));

                        string path = Path.Combine(Server.MapPath("~/App_Files/UserFiles"), FlName);

                        appFile.FilePath = path;
                        appFile.FileName = FlName;
                        appFile.UserId = User.Identity.GetUserId();
                        appFile.ContentType = upload.ContentType.ToString();

                        db.AppFiles.Add(appFile);
                        await db.SaveChangesAsync();
                        upload.SaveAs(path);
                        ViewBag.Message = "Your File uploaded successfully";
                        return RedirectToAction("Index");

                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }


            }

            return View(appFile);
        }

        // GET: AppFiles/Edit/5
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

        // POST: AppFiles/Edit/5
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

        // GET: AppFiles/Delete/5
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

        // POST: AppFiles/Delete/5
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
