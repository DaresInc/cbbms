using cbbmsRnD.Models.SysMgt;
using cbbmsRnD.Models.UsrMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class StockTransferVoucher
    {
        public int StockTransferVoucherId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int StockTransferedFromInventoryId { get; set; } // Strock Transfering Inventory Detail
        public int StockTransferedToInventoryId { get; set; }   // Stock Tranfed To Inventory Detail
        public int StockRecievedByUserId { get; set; }      //Recieveing User Details
        public int StockTransferdByUserId { get; set; }     //Transfering user Detail
        public string Remarks { get; set; }
        public int StatusId { get; set; }

        public virtual ICollection<StockTransferedItem> StockTransferedItems { get; set; }
        public virtual Status Status { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}