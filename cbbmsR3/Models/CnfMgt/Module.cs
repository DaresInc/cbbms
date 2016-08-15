using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.CnfMgt
{
    public class Module
    {
        public int ModuleId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }
        public int StatusId { get; set; }


        public virtual string Version { get; set; }
        public virtual string Build { get; set; }


        public ICollection<Component> Components { get; set; }

        public virtual Product Product { get; set; }
        public virtual Status Status { get; set; }
    }
}