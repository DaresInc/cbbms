using cbbmsRnD.Models.InvMgt;
using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsR3.Models.LabMgt
{
    public class BloodSample
    {
        public int BloodSampleId { get; set; }
        public int? PersonId { get; set; }
        public int? InventoryItemId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int StatusId { get; set; }

        public ICollection<BloodSampleTest> BloodSampleTests { get; set; }
        public virtual Status Status { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }


        BloodSample()
        {
            BloodSampleTests = new List<BloodSampleTest>();
        }
    }
}