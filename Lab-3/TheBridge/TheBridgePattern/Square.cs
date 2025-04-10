using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBridge.TheBridgePattern
{
    public class Square : Shape
    {
        private float side;

        public Square(IRenderer renderer, float side) : base(renderer)
        {
            this.side = side;
        }

        public override void Draw()
        {
            renderer.RenderShape($"Square with side {side}");
        }

        public override void Resize(float scale)
        {
            side *= scale;
            Console.WriteLine($"Square side changed to {side}");
        }
    }
}
