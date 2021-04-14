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
        private List<FileData> _filesData;

        public FileData this[int index] => _filesData[index];

        public Project()
        {
            _filesData = new List<FileData>();
        }

        public void AddFileData(FileData fileData)
        {
            _filesData.Add(fileData);
        }

        public void RemoveFileData(FileData fileData)
        {
            _filesData.Remove(fileData);
        }
    }
}
