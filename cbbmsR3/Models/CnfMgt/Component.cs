using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.CnfMgt
{
    public class Component
    {
        public int ComponentId { get; set; }
        public int ModuleId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }
        public int StatusId { get; set; }


        public virtual string Version { get; set; }
        public virtual string Build { get; set; }

        public ICollection<BuildHistory> BuildHistory { get; set; }


        public virtual Status Status { get; set; }
        public virtual Module Module { get; set; }
    }
}