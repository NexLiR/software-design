using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proxy.ProxyPattern
{
    public class SmartTextReaderLocker : ISmartTextReader
    {
        private readonly SmartTextReader _reader;
        private readonly Regex _restrictedPattern;

        public SmartTextReaderLocker(string restrictionPattern)
        {
            _reader = new SmartTextReader();
            _restrictedPattern = new Regex(restrictionPattern);
        }

        public char[][] ReadTextFile(string filePath)
        {
            if (_restrictedPattern.IsMatch(filePath))
            {
                Console.WriteLine("Access denied!");
                return new char[0][];
            }

            return _reader.ReadTextFile(filePath);
        }
    }
}
