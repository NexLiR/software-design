using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public static class FileHelper
    {
        public static void PrintContent(char[][] content)
        {
            if (content.Length == 0)
            {
                return;
            }

            Console.WriteLine("File content:");
            foreach (char[] line in content)
            {
                Console.WriteLine(new string(line));
            }
        }

        public static void CreateTestFiles()
        {
            File.WriteAllText("test.txt", "This is a test file.\nLorem\nLorem");

            File.WriteAllText("restricted_test.txt", "This is a restricted file.\nLorem\nLorem");
        }
    }
}
