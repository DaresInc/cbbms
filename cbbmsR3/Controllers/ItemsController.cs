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
using cbbmsRnD.Models.InvMgt;

namespace cbbmsR3.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Items
        public async Task<ActionResult> Index()
        {
            var items = db.Items.Include(i => i.ItemCategory).Include(i => i.Status).Include(i => i.UoM);
            return View(await items.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "Description");
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Description");
            ViewBag.UoMId = new SelectList(db.UoMs, "UoMId", "Description");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ItemId,Description,UoMId,ItemCategoryId,Picture,UnitPrice,StatusID,IsActive,Remarks,CreatedOn")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "Description", item.ItemCategoryId);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Description", item.StatusID);
            ViewBag.UoMId = new SelectList(db.UoMs, "UoMId", "Description", item.UoMId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "Description", item.ItemCategoryId);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Description", item.StatusID);
            ViewBag.UoMId = new SelectList(db.UoMs, "UoMId", "Description", item.UoMId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ItemId,Description,UoMId,ItemCategoryId,Picture,UnitPrice,StatusID,IsActive,Remarks,CreatedOn")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "Description", item.ItemCategoryId);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Description", item.StatusID);
            ViewBag.UoMId = new SelectList(db.UoMs, "UoMId", "Description", item.UoMId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
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
