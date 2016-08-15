using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsR3.Models.LabMgt
{
    public class BloodTest
    {
        public int BloodTestId { get; set; }
        public int BloodTestTypeId { get; set; }
        public int BloodSampleId { get; set; }
        public int StatusId { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }


        public virtual ICollection<BloodTestDetail> BloodTestDetails { get; set; }
        public virtual BloodSample BloodSmaple { get; set; }
        public virtual BloodTestType BloodTestType { get; set; }
        public virtual Status Status { get; set; }
    }
}