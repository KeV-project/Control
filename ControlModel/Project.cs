using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlModel
{
    public class Project
    {
        private List<FileInfo> _files;

        public FileInfo this[int index] => _files[index];

        public Project()
        {
            _files = new List<FileInfo>();
        }

        public void AddFile(FileInfo file)
        {
            _files.Add(file);
        }

        public void RemoveFile(FileInfo file)
        {
            _files.Remove(file);
        }
    }
}
