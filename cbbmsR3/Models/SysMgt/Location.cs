using cbbmsRnD.Models.InvMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.SysMgt
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}