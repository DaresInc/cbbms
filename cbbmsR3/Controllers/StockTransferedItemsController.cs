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
    public class StockTransferedItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockTransferedItems
        public async Task<ActionResult> Index()
        {
            var stockTransferedItems = db.StockTransferedItems.Include(s => s.Item).Include(s => s.Status);
            return View(await stockTransferedItems.ToListAsync());
        }

        // GET: StockTransferedItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransferedItem stockTransferedItem = await db.StockTransferedItems.FindAsync(id);
            if (stockTransferedItem == null)
            {
                return HttpNotFound();
            }
            return View(stockTransferedItem);
        }

        // GET: StockTransferedItems/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: StockTransferedItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StockTransferedItemId,ItemId,Qty,StrockTransferVoucherId,CreatedOn,StatusId,Remarks")] StockTransferedItem stockTransferedItem)
        {
            if (ModelState.IsValid)
            {
                db.StockTransferedItems.Add(stockTransferedItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockTransferedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockTransferedItem.StatusId);
            return View(stockTransferedItem);
        }

        // GET: StockTransferedItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransferedItem stockTransferedItem = await db.StockTransferedItems.FindAsync(id);
            if (stockTransferedItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockTransferedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockTransferedItem.StatusId);
            return View(stockTransferedItem);
        }

        // POST: StockTransferedItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StockTransferedItemId,ItemId,Qty,StrockTransferVoucherId,CreatedOn,StatusId,Remarks")] StockTransferedItem stockTransferedItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockTransferedItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockTransferedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockTransferedItem.StatusId);
            return View(stockTransferedItem);
        }

        // GET: StockTransferedItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransferedItem stockTransferedItem = await db.StockTransferedItems.FindAsync(id);
            if (stockTransferedItem == null)
            {
                return HttpNotFound();
            }
            return View(stockTransferedItem);
        }

        // POST: StockTransferedItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StockTransferedItem stockTransferedItem = await db.StockTransferedItems.FindAsync(id);
            db.StockTransferedItems.Remove(stockTransferedItem);
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
