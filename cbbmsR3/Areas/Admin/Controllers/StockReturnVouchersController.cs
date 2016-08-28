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
    public class StockReturnVouchersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockReturnVouchers
        public async Task<ActionResult> Index()
        {
            var stockReturnVouchers = db.StockReturnVouchers.Include(s => s.Status).Include(s => s.StockIssueVoucher);
            return View(await stockReturnVouchers.ToListAsync());
        }

        // GET: StockReturnVouchers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockReturnVoucher stockReturnVoucher = await db.StockReturnVouchers.FindAsync(id);
            if (stockReturnVoucher == null)
            {
                return HttpNotFound();
            }
            return View(stockReturnVoucher);
        }

        // GET: StockReturnVouchers/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            ViewBag.StockIssueVoucherId = new SelectList(db.StockIssueVouchers, "StockIssueVoucherId", "Remarks");
            return View();
        }

        // POST: StockReturnVouchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StockReturnVoucherId,CreatedOn,StockIssueVoucherId,StockReturnedByUserId,Remarks,StatusId")] StockReturnVoucher stockReturnVoucher)
        {
            if (ModelState.IsValid)
            {
                db.StockReturnVouchers.Add(stockReturnVoucher);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockReturnVoucher.StatusId);
            ViewBag.StockIssueVoucherId = new SelectList(db.StockIssueVouchers, "StockIssueVoucherId", "Remarks", stockReturnVoucher.StockIssueVoucherId);
            return View(stockReturnVoucher);
        }

        // GET: StockReturnVouchers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockReturnVoucher stockReturnVoucher = await db.StockReturnVouchers.FindAsync(id);
            if (stockReturnVoucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockReturnVoucher.StatusId);
            ViewBag.StockIssueVoucherId = new SelectList(db.StockIssueVouchers, "StockIssueVoucherId", "Remarks", stockReturnVoucher.StockIssueVoucherId);
            return View(stockReturnVoucher);
        }

        // POST: StockReturnVouchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StockReturnVoucherId,CreatedOn,StockIssueVoucherId,StockReturnedByUserId,Remarks,StatusId")] StockReturnVoucher stockReturnVoucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockReturnVoucher).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockReturnVoucher.StatusId);
            ViewBag.StockIssueVoucherId = new SelectList(db.StockIssueVouchers, "StockIssueVoucherId", "Remarks", stockReturnVoucher.StockIssueVoucherId);
            return View(stockReturnVoucher);
        }

        // GET: StockReturnVouchers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockReturnVoucher stockReturnVoucher = await db.StockReturnVouchers.FindAsync(id);
            if (stockReturnVoucher == null)
            {
                return HttpNotFound();
            }
            return View(stockReturnVoucher);
        }

        // POST: StockReturnVouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StockReturnVoucher stockReturnVoucher = await db.StockReturnVouchers.FindAsync(id);
            db.StockReturnVouchers.Remove(stockReturnVoucher);
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
