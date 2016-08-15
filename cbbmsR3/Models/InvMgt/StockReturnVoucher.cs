using cbbmsRnD.Models.SysMgt;
using cbbmsRnD.Models.UsrMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class StockReturnVoucher
    {
        public int StockReturnVoucherId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int StockIssueVoucherId { get; set; } // Strock Issued Voucher Nnumber To Map The Item For Returning
        public int StockReturnedByUserId { get; set; }     //Issueing user Detail
        public string Remarks { get; set; }
        public int StatusId { get; set; }

        public virtual ICollection<StockReturnedItem> StockReturnedItems { get; set; }
        public virtual StockIssueVoucher StockIssueVoucher { get; set; }
        public virtual Status Status { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}