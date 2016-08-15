using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace cbbmsRnD.Models.UsrMgt
{
    public class UserAddress
    {
       
            public int UserAddressId { get; set; }

            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public int Zipcode { get; set; }
            public string State { get; set; }
            public string Country { get; set; }

            public virtual AppUser AppUser { get; set; }
       
    }
}
