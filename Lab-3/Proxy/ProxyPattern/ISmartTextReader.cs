using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.ProxyPattern
{
    public interface ISmartTextReader
    {
        char[][] ReadTextFile(string filePath);
    }
}
