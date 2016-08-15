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
    public class StockReturnedItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockReturnedItems
        public async Task<ActionResult> Index()
        {
            var stockReturnedItems = db.StockReturnedItems.Include(s => s.Item).Include(s => s.Status).Include(s => s.StockReturnVoucher);
            return View(await stockReturnedItems.ToListAsync());
        }

        // GET: StockReturnedItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockReturnedItem stockReturnedItem = await db.StockReturnedItems.FindAsync(id);
            if (stockReturnedItem == null)
            {
                return HttpNotFound();
            }
            return View(stockReturnedItem);
        }

        // GET: StockReturnedItems/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            ViewBag.StockReturnVoucherId = new SelectList(db.StockReturnVouchers, "StockReturnVoucherId", "Remarks");
            return View();
        }

        // POST: StockReturnedItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StockReturnedItemId,ItemId,Qty,StockReturnVoucherId,CreatedOn,StatusId,Remarks")] StockReturnedItem stockReturnedItem)
        {
            if (ModelState.IsValid)
            {
                db.StockReturnedItems.Add(stockReturnedItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockReturnedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockReturnedItem.StatusId);
            ViewBag.StockReturnVoucherId = new SelectList(db.StockReturnVouchers, "StockReturnVoucherId", "Remarks", stockReturnedItem.StockReturnVoucherId);
            return View(stockReturnedItem);
        }

        // GET: StockReturnedItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockReturnedItem stockReturnedItem = await db.StockReturnedItems.FindAsync(id);
            if (stockReturnedItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockReturnedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockReturnedItem.StatusId);
            ViewBag.StockReturnVoucherId = new SelectList(db.StockReturnVouchers, "StockReturnVoucherId", "Remarks", stockReturnedItem.StockReturnVoucherId);
            return View(stockReturnedItem);
        }

        // POST: StockReturnedItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StockReturnedItemId,ItemId,Qty,StockReturnVoucherId,CreatedOn,StatusId,Remarks")] StockReturnedItem stockReturnedItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockReturnedItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockReturnedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockReturnedItem.StatusId);
            ViewBag.StockReturnVoucherId = new SelectList(db.StockReturnVouchers, "StockReturnVoucherId", "Remarks", stockReturnedItem.StockReturnVoucherId);
            return View(stockReturnedItem);
        }

        // GET: StockReturnedItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockReturnedItem stockReturnedItem = await db.StockReturnedItems.FindAsync(id);
            if (stockReturnedItem == null)
            {
                return HttpNotFound();
            }
            return View(stockReturnedItem);
        }

        // POST: StockReturnedItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StockReturnedItem stockReturnedItem = await db.StockReturnedItems.FindAsync(id);
            db.StockReturnedItems.Remove(stockReturnedItem);
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
