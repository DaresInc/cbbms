using cbbmsRnD.Models.CnfMgt;
using cbbmsRnD.Models.SysMgt;
using cbbmsRnD.Models.UsrMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.ProjMgt
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Motive { get; set; }

        public DateTime Satrt { get; set; }
        public DateTime End { get; set; }
        public int StatusId { get; set; }
        public String Owner { get; set; }
        public string Sponsor { get; set; }
        public int ProgramManager { get; set; }


        public ICollection<Product> Systems { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Status Status { get; set; }


    }

}