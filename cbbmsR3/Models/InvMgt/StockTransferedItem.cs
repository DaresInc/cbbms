using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class StockTransferedItem
    {
        public int StockTransferedItemId { get; set; }
        public int ItemId { get; set; }
        public decimal? Qty { get; set; }
        public int StrockTransferVoucherId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int StatusId { get; set; }
        public string Remarks { get; set; }


        public virtual Status Status { get; set; }
        public virtual StockTransferVoucher StockTransferVoucher { get; set; }
        public virtual Item Item { get; set; }
    }
}