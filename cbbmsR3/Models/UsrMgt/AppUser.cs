using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;
using cbbmsRnD.Models.UsrMgt;
using Microsoft.AspNet.Identity.EntityFramework;
using cbbmsRnD.Models.SysMgt;
using cbbmsRnD.Models.InvMgt;

namespace cbbmsRnD.Models.UsrMgt
{
    public class AppUser //: IdentityUser
    {
        public int AppUserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual string SecurityStamp { get; set; }
        public string SecurityQuestion { get; set; }
        public String SecurityQuestionAnswer { get; set; }
        public string PrimaryEmail { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateOn { get; set; }



        public virtual Status Status { get; set; }
        public virtual ICollection<LogIn> LogIns { get; set; }
        public virtual ICollection<Inventory> Inventories{ get; set; }

        public int Notifications { get; set; }

        public string Id
        {
            get { return AppUserID.ToString(); }
        }
    }
}
