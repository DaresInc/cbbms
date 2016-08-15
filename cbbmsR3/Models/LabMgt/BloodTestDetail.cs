using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsR3.Models.LabMgt
{
    public class BloodTestDetail
    {
        public int BloodTestDetailId { get; set; }
        public int BloodTestId { get; set; }
        public string Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }


        public virtual BloodTest BloodTest { get; set; }

    }
}