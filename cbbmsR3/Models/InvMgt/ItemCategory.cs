using cbbmsRnD.Models.SysMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.InvMgt
{
    public class ItemCategory
    {
        public int ItemCategoryId { get; set; }
        public string Description { get; set; }
        public int? AppFileId { get; set; }
        public string ContentType { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public AppFile AppFile { get; set; }

        public ItemCategory()
        {
            AppFile = new AppFile();
        }
    }
}