using cbbmsRnD.Models.SysMgt;
using cbbmsRnD.Models.UsrMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int AppUserID { get; set; }
        public int StandbyCustodian { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        

        public virtual AppUser AppUser { get; set; }

        public virtual Location Location { get; set; }


    }
}