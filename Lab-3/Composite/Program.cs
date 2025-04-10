using Composite.CompositePattern;
using Composite;

class Program
{
    static void Main(string[] args)
    {
        var table = new LightElementNode("table", DisplayType.Block, ClosingType.WithClosingTag);
        table.AddCssClass("data-table");

        var thead = new LightElementNode("thead", DisplayType.Block, ClosingType.WithClosingTag);
        var headerRow = new LightElementNode("tr", DisplayType.Block, ClosingType.WithClosingTag);

        string[] headers = { "ID", "Name", "Position", "Salary" };
        foreach (var headerText in headers)
        {
            var th = new LightElementNode("th", DisplayType.Block, ClosingType.WithClosingTag);
            th.AddChild(new LightTextNode(headerText));
            headerRow.AddChild(th);
        }

        thead.AddChild(headerRow);
        table.AddChild(thead);

        var tbody = new LightElementNode("tbody", DisplayType.Block, ClosingType.WithClosingTag);

        string[][] data = new string[][]
        {
                new string[] { "1", "Yan Rijenko", "Developer", "25,000" },
                new string[] { "2", "Denis Linevych", "Designer", "15,000" },
                new string[] { "3", "Oleksiy Semenchyk", "Manager", "20,000" }
        };

        foreach (var rowData in data)
        {
            var tr = new LightElementNode("tr", DisplayType.Block, ClosingType.WithClosingTag);
            tr.AddCssClass("data-row");
            foreach (var cellData in rowData)
            {
                var td = new LightElementNode("td", DisplayType.Block, ClosingType.WithClosingTag);
                td.AddCssClass("data-cell");
                td.AddChild(new LightTextNode(cellData));
               
                tr.AddChild(td);
                var button = new LightElementNode("button", DisplayType.Inline, ClosingType.SelfClosing);
                button.AddCssClass("link-button");
                tr.AddChild(button);
            }

            tbody.AddChild(tr);
        }

        table.AddChild(tbody);

        Console.WriteLine("Structure:");
        table.PrintStructure();
        Console.WriteLine("\nHTML Output:");
        Console.WriteLine(table.GetOuterHTML());



        Console.WriteLine("\n\n\n\nTesting non optimazed version of book reader");

        string[] bookLines = File.ReadAllLines("book.txt");
        Console.WriteLine($"Loaded book with {bookLines.Length} lines\n");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        long startMemory = GC.GetTotalMemory(true);

        LightElementNode rootElement = new LightElementNode("html", DisplayType.Block, ClosingType.WithClosingTag);
        LightElementNode bodyElement = new LightElementNode("body", DisplayType.Block, ClosingType.WithClosingTag);
        rootElement.AddChild(bodyElement);

        foreach (string line in bookLines)
        {
            if (string.IsNullOrEmpty(line))
                continue;

            if (line == bookLines[0])
            {
                LightElementNode h1 = new LightElementNode("h1", DisplayType.Block, ClosingType.WithClosingTag);
                h1.AddChild(new LightTextNode(line));
                bodyElement.AddChild(h1);
            }
            else if (line.Length < 20)
            {
                LightElementNode h2 = new LightElementNode("h2", DisplayType.Block, ClosingType.WithClosingTag);
                h2.AddChild(new LightTextNode(line));
                bodyElement.AddChild(h2);
            }
            else if (line.StartsWith(" ") || line.StartsWith("\t"))
            {
                LightElementNode blockquote = new LightElementNode("blockquote", DisplayType.Block, ClosingType.WithClosingTag);
                blockquote.AddChild(new LightTextNode(line.TrimStart()));
                bodyElement.AddChild(blockquote);
            }
            else
            {
                LightElementNode p = new LightElementNode("p", DisplayType.Block, ClosingType.WithClosingTag);
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