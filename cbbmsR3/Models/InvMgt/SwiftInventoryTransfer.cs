using cbbmsRnD.Models.SysMgt;
using cbbmsRnD.Models.UsrMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class SwiftInventoryTransfer
    {
        public int SwiftInventoryTransferId { get; set; }
        public string Code { get; set; }
        public int PIN { get; set; }
        public int StockTransferVoucherId { get; set; }
        public int StatusId { get; set; }
        public int RecievingUserId { get; set; }
        public int SendingUserId { get; set; }
        public DateTime ExpiredOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual StockTransferVoucher StockTransferVoucher { get; set; }
        public virtual Status Status { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}