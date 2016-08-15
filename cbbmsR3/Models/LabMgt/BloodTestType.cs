using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsR3.Models.LabMgt
{
    public class BloodTestType
    {
        public int BloodTestTypeId { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<BloodTestDefaultValue> BloodTestDefaultValues { get; set; }
    }
}