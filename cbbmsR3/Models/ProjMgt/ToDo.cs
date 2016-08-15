using cbbmsRnD.Models.UsrMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.ProjMgt
{
    public class ToDo
    {
        public int ToDoId{ get; set; }
        public String Description { get; set; }
        public int AssignToId { get; set; }
        public int AssignedById { get; set; }
        public int CompletedById { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }
        public int? Parent_ToDoId { get; set; }


        public virtual ICollection<ToDo> Tasks { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ToDo ToDos { get; set; }





    }
}