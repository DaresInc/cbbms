using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsR3.Models.LabMgt
{
    public class BloodTestDefaultValue
    {
        public int BloodTestDefaultValueId { get; set; }
        public int BloodTestTypeId { get; set; }
        public string Attribute { get; set; }
        public string DefaultValue { get; set; }
        public DateTime CreatedOn { get; set; }


        public virtual BloodTestType BloodTestType { get; set; }
    }
}