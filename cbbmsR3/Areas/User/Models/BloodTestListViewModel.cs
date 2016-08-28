using cbbmsR3.Models.LabMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cbbmsR3.Areas.User.Models
{
    public class BloodSampelTestListViewModel
    {
        [Display(Name="Test ID:")]
        [Editable(false)]
        public int BloodSampleTestId { get; set; }

        [Editable(false)]
        [Display(Name ="Test Name:")]
        public string BloodTestName { get; set; }


        [Display(Name ="Blood Sample Detail:")]
        public string   PersonDetail { get; set; }

        [Display(Name ="Inventory Item")]
        public Boolean IsInventoryItem { get; set; }

        [Display(Name ="Recieve Date")]
        [DataType(DataType.DateTime)]
        public DateTime RecieveDate { get; set; }

        [Display(Name ="Test Status:")]
        public string Status { get; set; }

        [Display(Name ="Remarks:")]
        public string Remarks { get; set; }


        [Display(Name ="D/Creation:")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<BloodTestDetailViewModel> BloodTestDetails { get; set; }
    }
}