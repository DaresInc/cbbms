using cbbmsRnD.Models.SysMgt;
using cbbmsRnD.Models.UsrMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class StockIssueVoucher
    { 

        public int StockIssueVoucherId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int StockIssuedFromInventoryId { get; set; } // Strock Issueing Inventory Detail
        public int StockIssuedToUserId { get; set; }   // Stock Tranfed To Inventory Detail
        public int StockIssuedByUserId { get; set; }     //Issueing user Detail
        public string Remarks { get; set; }
        public int StatusId { get; set; }

        public virtual ICollection<StockIssuedItem> StockIssuedItems { get; set; }
        public virtual Status Status { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Inventory Inventory { get; set; }
}
}