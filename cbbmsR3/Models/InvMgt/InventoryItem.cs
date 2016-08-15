using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public int ItemId { get; set; }
        public decimal? QtyRecieved { get; set; }
        public decimal? QtyIssued { get; set; }
        public string ReferenceDocument { get; set; }
        public string ReferenceDocumentType { get; set; }
        public int InventoryId { get; set; }
        public int StatusId { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }


        public virtual Status Status { get; set; }
        public virtual Inventory Inventory { get; set; }

        public virtual Item Item { get; set; }

    }
}