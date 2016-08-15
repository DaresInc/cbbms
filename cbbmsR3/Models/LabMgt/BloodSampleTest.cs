using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsR3.Models.LabMgt
{
    public class BloodSampleTest
    {
        public int BloodSampleTestId { get; set; }
        public int BloodTestId { get; set; }
        public int BloodSampleId { get; set; }

        public virtual BloodTest BloodTest { get; set; }
        public virtual BloodSample BloodSample { get; set; }
    }
}