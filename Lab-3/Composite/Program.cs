using Composite.CompositePattern;
using Composite;
using Composite.CompositePattern.Template;
using Composite.CompositePattern.Iterator;

class Program
{
    static void Main(string[] args)
    {
        var table = new LightElementNodeWithIterator("table", DisplayType.Block, ClosingType.WithClosingTag);
        table.AddCssClass("data-table");

        var thead = new LightElementNodeWithIterator("thead", DisplayType.Block, ClosingType.WithClosingTag);
        var headerRow = new LightElementNodeWithIterator("tr", DisplayType.Block, ClosingType.WithClosingTag);

        string[] headers = { "ID", "Name", "Position", "Salary", "Photo", "Actions" };
        foreach (var headerText in headers)
        {
            var th = new LightElementNodeWithIterator("th", DisplayType.Block, ClosingType.WithClosingTag);
            th.AddChild(new LightTextNode(headerText));
            headerRow.AddChild(th);
        }

        thead.AddChild(headerRow);
        table.AddChild(thead);

        var tbody = new LightElementNodeWithIterator("tbody", DisplayType.Block, ClosingType.WithClosingTag);

        string[][] data = new string[][]
        {
            new string[] { "1", "Yan Rijenko", "Developer", "25,000", "C:\\invalidPath" },
            new string[] { "2", "Denis Linevych", "Designer", "15,000", "https://img.icons8.com/?size=100&id=17904&format=png&color=000000" },
            new string[] { "3", "Oleksiy Semenchyk", "Manager", "20,000", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "oleksiy.jpg") }
        };

        List<LightElementNode> buttons = new List<LightElementNode>();

        foreach (var cellData in data)
        {
            var tr = new LightElementNodeWithIterator("tr", DisplayType.Block, ClosingType.WithClosingTag);
            tr.AddCssClass("data-row");

            for (int i = 0; i < cellData.Length - 1; i++)
            {
                var td = new LightElementNodeWithIterator("td", DisplayType.Block, ClosingType.WithClosingTag);
                td.AddCssClass("data-cell");
                td.AddChild(new LightTextNode(cellData[i]));
                tr.AddChild(td);
            }

            var photoCell = new LightElementNodeWithIterator("td", DisplayType.Block, ClosingType.WithClosingTag);
            photoCell.AddCssClass("photo-cell");

            string imagePath = cellData[4];
            var imageNode = new LightImageNode(imagePath, $"Photo of {cellData[1]}", 50, 50);
            photoCell.AddChild(imageNode);
            tr.AddChild(photoCell);

            var actionsCell = new LightElementNodeWithIterator("td", DisplayType.Block, ClosingType.WithClosingTag);
            actionsCell.AddCssClass("actions-cell");

            var button = new LightElementNode("button", DisplayType.Inline, ClosingType.WithClosingTag);
            button.AddCssClass("view-button");
            button.AddChild(new LightTextNode("View Details"));

            button.AddEventListener(EventType.Click, (sender, e) => {
                var targetButton = (LightElementNode)sender;
                var parentRow = tr;

                string employeeName = cellData[1];
                Console.WriteLine($"\n[NAVIGATION EVENT] Redirecting to details page for: {employeeName}");
                Console.WriteLine($"Full info about {employeeName}");
            });

            buttons.Add(button);
            actionsCell.AddChild(button);
            tr.AddChild(actionsCell);

            tbody.AddChild(tr);
        }
        table.AddChild(tbody);

        Console.WriteLine("Structure:");
        table.PrintStructure();

        Console.WriteLine("\nHTML Output:");
        Console.WriteLine(table.GetOuterHTML());

        Console.WriteLine("\nSimulating button clicks:");
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].TriggerEvent(EventType.Click);
        }

        Console.WriteLine("\nIterating through the table structure with depth iterator:");
        var depthIterator = table.CreateDepthFirstIterator();
        int depthCount = 0;

        while (depthIterator.HasNext())
        {
            var node = depthIterator.Next();
            depthCount++;

            if (node is LightElementNode elementNode)
            {
                string classes = elementNode.HasCssClasses() ? elementNode.GetCssClassesString() : "no-class";
                Console.WriteLine($"{depthCount}. Element: <{elementNode.TagName}> (Classes: {classes})");
            }
            else if (node is LightTextNode textNode)
            {
                string text = textNode.Text.Length > 30 ? textNode.Text.Substring(0, 27) + "..." : textNode.Text;
                Console.WriteLine($"{depthCount}. Text: \"{text}\"");
            }
            else if (node is LightImageNode imageNode)
            {
                Console.WriteLine($"{depthCount}. Image: {imageNode.AltText}");
            }
        }

        Console.WriteLine("\nIterating through the table structure with breadth iterator:");
        var breadthIterator = table.CreateBreadthFirstIterator();
        int breadthCount = 0;

        while (breadthIterator.HasNext())
        {
            var node = breadthIterator.Next();
            breadthCount++;

            if (node is LightElementNode elementNode)
            {
                string classes = elementNode.HasCssClasses() ? elementNode.GetCssClassesString() : "no-class";
                Console.WriteLine($"{breadthCount}. Element: <{elementNode.TagName}> (Classes: {classes})");
            }
            else if (node is LightTextNode textNode)
            {
                string text = textNode.Text.Length > 30 ? textNode.Text.Substring(0, 27) + "..." : textNode.Text;
                Console.WriteLine($"{breadthCount}. Text: \"{text}\"");
            }
            else if (node is LightImageNode imageNode)
            {
                Console.WriteLine($"{breadthCount}. Image: {imageNode.AltText}");
            }
        }


        Console.WriteLine("\nSearch using iterator");
        int buttonCount = 0;
        depthIterator.Reset();
        
        while (depthIterator.HasNext())
        {
            var node = depthIterator.Next();
            
            if (node is LightElementNode elementNode && elementNode.TagName == "button")
            {
                buttonCount++;
                string buttonText = "Unknown";
                
                foreach (var child in elementNode._children)
                {
                    if (child is LightTextNode textNode)
                    {
                        buttonText = textNode.Text;
                        break;
                    }
                }
                
                Console.WriteLine($"Button {buttonCount}: {buttonText}");
            }
        }
    }
}