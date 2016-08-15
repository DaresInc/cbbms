using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.UsrMgt
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public bool Blocked { get; set; }
        public DateTime CreatedOn { get; set; }


        public virtual Role Role { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}