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
    public class StockRecieveVouchersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockRecieveVouchers
        public async Task<ActionResult> Index()
        {
            var stockRecieveVouchers = db.StockRecieveVouchers.Include(s => s.Status);
            return View(await stockRecieveVouchers.ToListAsync());
        }

        // GET: StockRecieveVouchers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockRecieveVoucher stockRecieveVoucher = await db.StockRecieveVouchers.FindAsync(id);
            if (stockRecieveVoucher == null)
            {
                return HttpNotFound();
            }
            return View(stockRecieveVoucher);
        }

        // GET: StockRecieveVouchers/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description");
            return View();
        }

        // POST: StockRecieveVouchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StockRecieveVoucherId,CreatedOn,StockRecieveingInventoryId,StockRecievedFromUserId,StockRecievedByUserId,Remarks,StatusId")] StockRecieveVoucher stockRecieveVoucher)
        {
            if (ModelState.IsValid)
            {
                db.StockRecieveVouchers.Add(stockRecieveVoucher);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockRecieveVoucher.StatusId);
            return View(stockRecieveVoucher);
        }

        // GET: StockRecieveVouchers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockRecieveVoucher stockRecieveVoucher = await db.StockRecieveVouchers.FindAsync(id);
            if (stockRecieveVoucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockRecieveVoucher.StatusId);
            return View(stockRecieveVoucher);
        }

        // POST: StockRecieveVouchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StockRecieveVoucherId,CreatedOn,StockRecieveingInventoryId,StockRecievedFromUserId,StockRecievedByUserId,Remarks,StatusId")] StockRecieveVoucher stockRecieveVoucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockRecieveVoucher).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusID", "Description", stockRecieveVoucher.StatusId);
            return View(stockRecieveVoucher);
        }

        // GET: StockRecieveVouchers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockRecieveVoucher stockRecieveVoucher = await db.StockRecieveVouchers.FindAsync(id);
            if (stockRecieveVoucher == null)
            {
                return HttpNotFound();
            }
            return View(stockRecieveVoucher);
        }

        // POST: StockRecieveVouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StockRecieveVoucher stockRecieveVoucher = await db.StockRecieveVouchers.FindAsync(id);
            db.StockRecieveVouchers.Remove(stockRecieveVoucher);
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
