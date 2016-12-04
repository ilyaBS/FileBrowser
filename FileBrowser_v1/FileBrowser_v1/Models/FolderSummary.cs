using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;


namespace FileBrowser_v1.Models
{
    public class FolderSummary
    {
        public FolderSummary(string name)
        {
            Name = name;
            CalculateValues(Name);

            populateContent();

        }

        private void populateContent()
        {
            Content = new List<FileSystemItem>();
            try
            {
                Content.Add(new FileSystemItem() { Name = "..", FullPath = (new DirectoryInfo(Name)).Parent.FullName, IsFolder = true });
            }
            catch { }

            var folders = Directory.GetDirectories(Name).ToList<string>();
            folders.ForEach(f =>
            {
                Content.Add(new FileSystemItem() { Name = new DirectoryInfo(f).Name, FullPath = f, IsFolder = true });
            }
            );

            var files = Directory.GetFiles(Name).ToList<string>();
            files.ForEach(f =>
            {
                Content.Add(new FileSystemItem() { Name = Path.GetFileName(f), FullPath = f, IsFolder = false });
            }
            );
        }

       

        private void CalculateValues(string folderName)
        {
            List<string> files;
            try
            {
                files = Directory.GetFiles(folderName).ToList<string>();
            }
            catch
            {
                return;
            }

            files.ForEach(path => 
            {
                var length = new System.IO.FileInfo(path).Length;
                if (length <= 10000000) { FileCount10++; }
                else if (length <= 50000000) { FileCount50++; };
                if (length >= 100000000) { FileCount100++; };
            });
            
            var subfolders = Directory.GetDirectories(folderName).ToList<string>();
            if (subfolders.Count > 0)
            {
                Parallel.ForEach<string>(subfolders, currentSubfolder => CalculateValues(currentSubfolder));                    
            }


        }

        //private string _name;
        private string _name;
        public string Name { get { return _name; } set 
        {
            var isFolder = Directory.Exists(value);
            var isFile = File.Exists(value);

            if (isFolder) 
            {
                _name = Path.GetFullPath(value);
            }
            else if (isFile) { _name = Directory.GetParent(value).FullName; }
            else { _name = Directory.GetCurrentDirectory(); }

        } }
        

        public string FullPath { get; set; }
        
        public int FileCount10 { get; set; }

        public int FileCount50 { get; set; }

        public int FileCount100 { get; set; }

        public List<FileSystemItem> Content { get; set; }
    }
}