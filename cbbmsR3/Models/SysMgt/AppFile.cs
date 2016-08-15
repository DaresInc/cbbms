using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cbbmsRnD.Models.SysMgt
{
    public class AppFile
    {
        public int AppFileId { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string Caption { get; set; }
        public string UserId { get; set; }


        public virtual string GetFilePath
        {

            get
            {
                string deficon = @"/App_Files/AppContent/FileIcon.png";
                switch (ContentType)
                {
                    case "image/png":
                        return @"/App_Files/UserFiles/" + this.FileName;
                    default:
                        return deficon;
                }
            }

        }
    }

    public class AppFile_EditViewModel
    {
        public int AppFileId { get; set; }
        public string Caption { get; set; }
    }
}