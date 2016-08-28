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
    public class SwiftInventoryTransfersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SwiftInventoryTransfers
        public async Task<ActionResult> Index()
        {
            var swiftInventoryTransfers = db.SwiftInventoryTransfers.Include(s => s.Status).Include(s => s.StockTransferVoucher);
            return View(await swiftInventoryTransfers.ToListAsync());
        }

        // GET: SwiftInventoryTransfers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SwiftInventoryTransfer swiftInventoryTransfer = await db.SwiftInventoryTransfers.FindAsync(id);
            if (swiftInventoryTransfer == null)
            {
                return HttpNotFound();
            }
            return View(swiftInventoryTransfer);
        }

        // GET: SwiftInventoryTransfers/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            ViewBag.StockTransferVoucherId = new SelectList(db.StockTransferVouchers, "StockTransferVoucherId", "Remarks");
            return View();
        }

        // POST: SwiftInventoryTransfers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SwiftInventoryTransferId,Code,PIN,StockTransferVoucherId,StatusId,RecievingUserId,SendingUserId,ExpiredOn,CreatedOn")] SwiftInventoryTransfer swiftInventoryTransfer)
        {
            if (ModelState.IsValid)
            {
                db.SwiftInventoryTransfers.Add(swiftInventoryTransfer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", swiftInventoryTransfer.StatusId);
            ViewBag.StockTransferVoucherId = new SelectList(db.StockTransferVouchers, "StockTransferVoucherId", "Remarks", swiftInventoryTransfer.StockTransferVoucherId);
            return View(swiftInventoryTransfer);
        }

        // GET: SwiftInventoryTransfers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SwiftInventoryTransfer swiftInventoryTransfer = await db.SwiftInventoryTransfers.FindAsync(id);
            if (swiftInventoryTransfer == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", swiftInventoryTransfer.StatusId);
            ViewBag.StockTransferVoucherId = new SelectList(db.StockTransferVouchers, "StockTransferVoucherId", "Remarks", swiftInventoryTransfer.StockTransferVoucherId);
            return View(swiftInventoryTransfer);
        }

        // POST: SwiftInventoryTransfers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SwiftInventoryTransferId,Code,PIN,StockTransferVoucherId,StatusId,RecievingUserId,SendingUserId,ExpiredOn,CreatedOn")] SwiftInventoryTransfer swiftInventoryTransfer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(swiftInventoryTransfer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", swiftInventoryTransfer.StatusId);
            ViewBag.StockTransferVoucherId = new SelectList(db.StockTransferVouchers, "StockTransferVoucherId", "Remarks", swiftInventoryTransfer.StockTransferVoucherId);
            return View(swiftInventoryTransfer);
        }

        // GET: SwiftInventoryTransfers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SwiftInventoryTransfer swiftInventoryTransfer = await db.SwiftInventoryTransfers.FindAsync(id);
            if (swiftInventoryTransfer == null)
            {
                return HttpNotFound();
            }
            return View(swiftInventoryTransfer);
        }

        // POST: SwiftInventoryTransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SwiftInventoryTransfer swiftInventoryTransfer = await db.SwiftInventoryTransfers.FindAsync(id);
            db.SwiftInventoryTransfers.Remove(swiftInventoryTransfer);
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
