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
    public class StockIssuedItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockIssuedItems
        public async Task<ActionResult> Index()
        {
            var stockIssuedItems = db.StockIssuedItems.Include(s => s.Item).Include(s => s.Status);
            return View(await stockIssuedItems.ToListAsync());
        }

        // GET: StockIssuedItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssuedItem stockIssuedItem = await db.StockIssuedItems.FindAsync(id);
            if (stockIssuedItem == null)
            {
                return HttpNotFound();
            }
            return View(stockIssuedItem);
        }

        // GET: StockIssuedItems/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: StockIssuedItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StockIssuedItemId,ItemId,Qty,StrockIssueVoucherId,CreatedOn,StatusId,Remarks")] StockIssuedItem stockIssuedItem)
        {
            if (ModelState.IsValid)
            {
                db.StockIssuedItems.Add(stockIssuedItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockIssuedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockIssuedItem.StatusId);
            return View(stockIssuedItem);
        }

        // GET: StockIssuedItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssuedItem stockIssuedItem = await db.StockIssuedItems.FindAsync(id);
            if (stockIssuedItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockIssuedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockIssuedItem.StatusId);
            return View(stockIssuedItem);
        }

        // POST: StockIssuedItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StockIssuedItemId,ItemId,Qty,StrockIssueVoucherId,CreatedOn,StatusId,Remarks")] StockIssuedItem stockIssuedItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockIssuedItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockIssuedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockIssuedItem.StatusId);
            return View(stockIssuedItem);
        }

        // GET: StockIssuedItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssuedItem stockIssuedItem = await db.StockIssuedItems.FindAsync(id);
            if (stockIssuedItem == null)
            {
                return HttpNotFound();
            }
            return View(stockIssuedItem);
        }

        // POST: StockIssuedItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StockIssuedItem stockIssuedItem = await db.StockIssuedItems.FindAsync(id);
            db.StockIssuedItems.Remove(stockIssuedItem);
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
