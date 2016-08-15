using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.UsrMgt
{
    public class Contact
    {

        public int ContactId { get; set; }
        public int AppUserId { get; set; }
        public string ContactType { get; set; }
        public String ContactDetail { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }

    }
}