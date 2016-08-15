using cbbmsRnD.Models.InvMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.SysMgt
{
    public class UoM
    {
        public int UoMId { get; set; }
        public string Description { get; set; }
        public string Abbriviation { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }


        public ICollection<Item> Items { get; set; }

    }
}