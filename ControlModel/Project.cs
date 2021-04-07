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
        private List<FileData> _files;

        public FileData this[int index] => _files[index];

        public Project()
        {
            _files = new List<FileData>();
        }

        public void AddFile(FileData file)
        {
            _files.Add(file);
        }

        public void RemoveFile(FileData file)
        {
            _files.Remove(file);
        }
    }
}
