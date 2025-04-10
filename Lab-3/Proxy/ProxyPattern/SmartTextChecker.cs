using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.ProxyPattern
{
    public class SmartTextChecker : ISmartTextReader
    {
        private readonly SmartTextReader _reader;

        public SmartTextChecker()
        {
            _reader = new SmartTextReader();
        }

        public char[][] ReadTextFile(string filePath)
        {
            Console.WriteLine($"Opening file: {filePath}");

            char[][] content = _reader.ReadTextFile(filePath);


            int totalLines = content.Length;
            int totalChars = 0;

            foreach (char[] line in content)
            {
                totalChars += line.Length;
            }

            Console.WriteLine($"Total lines: {totalLines}");
            Console.WriteLine($"Total characters: {totalChars}");
            return content;
        }
    }
}
