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

namespace cbbmsR3.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class StockTransferVouchersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockTransferVouchers
        public async Task<ActionResult> Index()
        {
            var stockTransferVouchers = db.StockTransferVouchers.Include(s => s.Status);
            return View(await stockTransferVouchers.ToListAsync());
        }

        // GET: StockTransferVouchers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransferVoucher stockTransferVoucher = await db.StockTransferVouchers.FindAsync(id);
            if (stockTransferVoucher == null)
            {
                return HttpNotFound();
            }
            return View(stockTransferVoucher);
        }

        // GET: StockTransferVouchers/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: StockTransferVouchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StockTransferVoucherId,CreatedOn,StockTransferedFromInventoryId,StockTransferedToInventoryId,StockRecievedByUserId,StockTransferdByUserId,Remarks,StatusId")] StockTransferVoucher stockTransferVoucher)
        {
            if (ModelState.IsValid)
            {
                db.StockTransferVouchers.Add(stockTransferVoucher);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockTransferVoucher.StatusId);
            return View(stockTransferVoucher);
        }

        // GET: StockTransferVouchers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransferVoucher stockTransferVoucher = await db.StockTransferVouchers.FindAsync(id);
            if (stockTransferVoucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockTransferVoucher.StatusId);
            return View(stockTransferVoucher);
        }

        // POST: StockTransferVouchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StockTransferVoucherId,CreatedOn,StockTransferedFromInventoryId,StockTransferedToInventoryId,StockRecievedByUserId,StockTransferdByUserId,Remarks,StatusId")] StockTransferVoucher stockTransferVoucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockTransferVoucher).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockTransferVoucher.StatusId);
            return View(stockTransferVoucher);
        }

        // GET: StockTransferVouchers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTransferVoucher stockTransferVoucher = await db.StockTransferVouchers.FindAsync(id);
            if (stockTransferVoucher == null)
            {
                return HttpNotFound();
            }
            return View(stockTransferVoucher);
        }

        // POST: StockTransferVouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StockTransferVoucher stockTransferVoucher = await db.StockTransferVouchers.FindAsync(id);
            db.StockTransferVouchers.Remove(stockTransferVoucher);
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
