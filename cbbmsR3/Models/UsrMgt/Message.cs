using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.UsrMgt
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public byte[] Content { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime SendingDate { get; set; }
        public DateTime RecievingDate { get; set; }
        public String ConversationId { get; set; }
        public string Remarks { get; set; }


        public Status Status { get; set; }
        public AppUser AppUser { get; set; }

    }
}