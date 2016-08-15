using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.CnfMgt
{
    public class EngineeringChangeRequest
    {
        public int EngineeringChangeRequestId { get; set; }
        public int ComponentId { get; set; }
        public string Description { get; set; }
        public String ChangeType { get; set; }
        public int RequesteeId { get; set; }
        public int StatusId { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }


        public virtual Component Component { get; set; }
        public virtual Status Status { get; set; }
    }
}