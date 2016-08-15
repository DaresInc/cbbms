using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        public int UoMId { get; set; }
        public int ItemCategoryId { get; set; }
        public byte[] Picture { get; set; }
        public Decimal? UnitPrice { get; set; }
        public int StatusID { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn{ get; set; }

        public virtual ItemCategory ItemCategory { get; set; }
        public virtual Status Status { get; set; }
        public virtual UoM UoM { get; set; }

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }


    }
}