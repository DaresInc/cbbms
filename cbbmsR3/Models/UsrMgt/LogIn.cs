using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.UsrMgt
{
    public class LogIn
    {
        public int LogInId { get; set; }
        public int UserId { get; set; }
        public DateTime Login { get; set; }
        public DateTime Logout { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public int StatusId { get; set; }
        public string Remarks { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Status Status { get; set; }
        


    }
}