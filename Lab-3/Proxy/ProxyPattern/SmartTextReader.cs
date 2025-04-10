using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.ProxyPattern
{
    public class SmartTextReader : ISmartTextReader
    {
        public char[][] ReadTextFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                char[][] result = new char[lines.Length][];

                for (int i = 0; i < lines.Length; i++)
                {
                    result[i] = lines[i].ToCharArray();
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return new char[0][];
            }
        }
    }
}
