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
    public class StockRecievedItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockRecievedItems
        public async Task<ActionResult> Index()
        {
            var stockRecievedItems = db.StockRecievedItems.Include(s => s.Item).Include(s => s.Status);
            return View(await stockRecievedItems.ToListAsync());
        }

        // GET: StockRecievedItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockRecievedItem stockRecievedItem = await db.StockRecievedItems.FindAsync(id);
            if (stockRecievedItem == null)
            {
                return HttpNotFound();
            }
            return View(stockRecievedItem);
        }

        // GET: StockRecievedItems/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: StockRecievedItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StockRecievedItemId,ItemId,Qty,StrockRecieveVoucherId,CreatedOn,StatusId,Remarks")] StockRecievedItem stockRecievedItem)
        {
            if (ModelState.IsValid)
            {
                db.StockRecievedItems.Add(stockRecievedItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockRecievedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockRecievedItem.StatusId);
            return View(stockRecievedItem);
        }

        // GET: StockRecievedItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockRecievedItem stockRecievedItem = await db.StockRecievedItems.FindAsync(id);
            if (stockRecievedItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockRecievedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockRecievedItem.StatusId);
            return View(stockRecievedItem);
        }

        // POST: StockRecievedItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StockRecievedItemId,ItemId,Qty,StrockRecieveVoucherId,CreatedOn,StatusId,Remarks")] StockRecievedItem stockRecievedItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockRecievedItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Description", stockRecievedItem.ItemId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockRecievedItem.StatusId);
            return View(stockRecievedItem);
        }

        // GET: StockRecievedItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockRecievedItem stockRecievedItem = await db.StockRecievedItems.FindAsync(id);
            if (stockRecievedItem == null)
            {
                return HttpNotFound();
            }
            return View(stockRecievedItem);
        }

        // POST: StockRecievedItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StockRecievedItem stockRecievedItem = await db.StockRecievedItems.FindAsync(id);
            db.StockRecievedItems.Remove(stockRecievedItem);
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
