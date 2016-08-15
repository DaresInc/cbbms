using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.UsrMgt
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int StatusId { get; set; }
        public string Remarks { get; set; }


        public ICollection<UserRole> RoleUsers { get; set; }
    }
}