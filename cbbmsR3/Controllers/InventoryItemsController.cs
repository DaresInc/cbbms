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
    public class InventoryItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InventoryItems
        public async Task<ActionResult> Index()
        {
            var inventoryItems = db.InventoryItems.Include(i => i.Inventory).Include(i => i.Status);
            return View(await inventoryItems.ToListAsync());
        }

        // GET: InventoryItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryItem inventoryItem = await db.InventoryItems.FindAsync(id);
            if (inventoryItem == null)
            {
                return HttpNotFound();
            }
            return View(inventoryItem);
        }

        // GET: InventoryItems/Create
        public ActionResult Create()
        {
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "Title");
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: InventoryItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InventoryItemId,ItemId,QtyRecieved,QtyIssued,ReferenceDocument,ReferenceDocumentType,InventoryId,StatusId,Remarks,CreatedOn")] InventoryItem inventoryItem)
        {
            if (ModelState.IsValid)
            {
                db.InventoryItems.Add(inventoryItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "Title", inventoryItem.InventoryId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", inventoryItem.StatusId);
            return View(inventoryItem);
        }

        // GET: InventoryItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryItem inventoryItem = await db.InventoryItems.FindAsync(id);
            if (inventoryItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "Title", inventoryItem.InventoryId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", inventoryItem.StatusId);
            return View(inventoryItem);
        }

        // POST: InventoryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InventoryItemId,ItemId,QtyRecieved,QtyIssued,ReferenceDocument,ReferenceDocumentType,InventoryId,StatusId,Remarks,CreatedOn")] InventoryItem inventoryItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "Title", inventoryItem.InventoryId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", inventoryItem.StatusId);
            return View(inventoryItem);
        }

        // GET: InventoryItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryItem inventoryItem = await db.InventoryItems.FindAsync(id);
            if (inventoryItem == null)
            {
                return HttpNotFound();
            }
            return View(inventoryItem);
        }

        // POST: InventoryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InventoryItem inventoryItem = await db.InventoryItems.FindAsync(id);
            db.InventoryItems.Remove(inventoryItem);
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
