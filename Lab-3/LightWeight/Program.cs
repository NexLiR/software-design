using FlyWeight;
using FlyWeight.CompositePattern;
class Program
{
    static void Main(string[] args)
    {
        string[] bookLines = File.ReadAllLines("book.txt");
        Console.WriteLine($"Loaded book with {bookLines.Length} lines\n");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        long startMemory = GC.GetTotalMemory(true);

        LightElementNode rootElement = LightElementNode.Create("html", DisplayType.Block, ClosingType.WithClosingTag);
        LightElementNode bodyElement = LightElementNode.Create("body", DisplayType.Block, ClosingType.WithClosingTag);
        rootElement.AddChild(bodyElement);

        foreach (string line in bookLines)
        {
            if (string.IsNullOrEmpty(line))
                continue;

            if (line == bookLines[0])
            {
                LightElementNode h1 = LightElementNode.Create("h1", DisplayType.Block, ClosingType.WithClosingTag);
                h1.AddChild(new LightTextNode(line));
                bodyElement.AddChild(h1);
            }
            else if (line.Length < 20)
            {
                LightElementNode h2 = LightElementNode.Create("h2", DisplayType.Block, ClosingType.WithClosingTag);
                h2.AddChild(new LightTextNode(line));
                bodyElement.AddChild(h2);
            }
            else if (line.StartsWith(" ") || line.StartsWith("\t"))
            {
                LightElementNode blockquote = LightElementNode.Create("blockquote", DisplayType.Block, ClosingType.WithClosingTag);
                blockquote.AddChild(new LightTextNode(line.TrimStart()));
                bodyElement.AddChild(blockquote);
            }
            else
            {
                LightElementNode p = LightElementNode.Create("p", DisplayType.Block, ClosingType.WithClosingTag);
                p.AddChild(new LightTextNode(line));
                bodyElement.AddChild(p);
            }
        }

        long endMemory = GC.GetTotalMemory(true);
        long memoryUsed = endMemory - startMemory;

        Console.WriteLine($"Memory used: {memoryUsed:N0} bytes");
        Console.WriteLine($"Total elements created: {bookLines.Length}");
    }
}