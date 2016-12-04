using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBrowser_v1.Models
{
    public class FileSystemItem
    {
        public string Name { get; set; }

        public string FullPath { get; set; }

        public bool IsFolder { get; set; }
    }
}