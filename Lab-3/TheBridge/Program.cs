using TheBridge.TheBridgePattern;

class Program
{
    static void Main(string[] args)
    {
        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape[] shapes = new Shape[]
        {
                new Circle(vectorRenderer, 5),
                new Circle(rasterRenderer, 7),
                new Square(vectorRenderer, 10),
                new Square(rasterRenderer, 15)
        };

        foreach (var shape in shapes)
        {
            shape.Draw();
        }

        Console.WriteLine("\nResizing and redrawing shapes:");
        foreach (var shape in shapes)
        {
            shape.Resize(1.5f);
            shape.Draw();
            Console.WriteLine();
        }
    }
}