using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBridge.TheBridgePattern
{
    public class RasterRenderer : IRenderer
    {
        public void RenderShape(string shape)
        {
            Console.WriteLine($"Drawing {shape} as pixels");
        }
    }
}
