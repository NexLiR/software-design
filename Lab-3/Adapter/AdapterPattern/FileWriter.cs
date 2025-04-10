using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.AdapterPattern
{
    public class FileWriter
    {
        private readonly string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(string content)
        {
            File.AppendAllText(_filePath, content);
        }

        public void WriteLine(string content)
        {
            File.AppendAllText(_filePath, content + Environment.NewLine);
        }
    }
}
