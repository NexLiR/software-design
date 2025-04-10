using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBridge.TheBridgePattern
{
    public class Circle : Shape
    {
        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderShape($"Circle with radius {radius}");
        }

        public override void Resize(float scale)
        {
            radius *= scale;
            Console.WriteLine($"Circle radius changed to {radius}");
        }
    }
}
