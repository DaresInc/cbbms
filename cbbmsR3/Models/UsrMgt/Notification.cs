using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.UsrMgt
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationType { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string ActionLink { get; set; }
        public int StatusId{ get; set; }
        public DateTime CreatedOn { get; set; }
        public string Origion { get; set; }
        public string Remarks { get; set; }


        public virtual Status Status { get; set; }

        public virtual AppUser AppUser { get; set; }


    }
}