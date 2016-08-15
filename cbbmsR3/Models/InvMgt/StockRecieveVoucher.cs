using cbbmsRnD.Models.SysMgt;
using cbbmsRnD.Models.UsrMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class StockRecieveVoucher
    {
        public int StockRecieveVoucherId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int StockRecieveingInventoryId { get; set; }
        public int StockRecievedFromUserId{ get; set; }
        public int StockRecievedByUserId { get; set; }
        public string Remarks { get; set; }
        public int StatusId { get; set; }

        public virtual ICollection<StockRecievedItem> StockRecievedItems { get; set; }
        public virtual Status Status { get; set; }

        public virtual AppUser AppUser { get; set; }


    }
}