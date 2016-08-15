using cbbmsRnD.Models.SysMgt;
using System;

namespace cbbmsRnD.Models.InvMgt
{
    public class StockRecievedItem
    {
        public int StockRecievedItemId { get; set; }
        public int ItemId { get; set; }
        public decimal? Qty { get; set; }
        public int StrockRecieveVoucherId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int StatusId { get; set; }
        public string Remarks { get; set; }


        public virtual Status Status { get; set; }
        public virtual StockRecieveVoucher StockRecieveVoucher { get; set; }
        public virtual Item Item { get; set; }
    }
}