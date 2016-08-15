using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.UsrMgt
{
    public class UserProfile
    {
        public int UserProfileID { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public int MobileNumber { get; set; }
        public int StatusID { get; set; }        
        public DateTime CreatedOn { get; set; }
        public int AddressID { get; set; }
        public int AppUserID { get; set; }


        public virtual UserAddress UserAddress { get; set; }
        public virtual Status Status { get; set; }

        [NotMapped]
        public string FullName { get{ return FirstName + " " + LastName;}}
    }
}