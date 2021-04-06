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
        private List<File> _files;

        public File this[int index] => _files[index];

        public Project()
        {
            _files = new List<File>();
        }

        public void AddFile(File file)
        {
            _files.Add(file);
        }

        public void RemoveFile(File file)
        {
            _files.Remove(file);
        }
    }
}
