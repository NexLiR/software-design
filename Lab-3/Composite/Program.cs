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

        List<LightElementNode> buttons = new List<LightElementNode>();

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
            }

            var button = new LightElementNode("button", DisplayType.Inline, ClosingType.WithClosingTag);
            button.AddCssClass("link-button");
            button.AddChild(new LightTextNode("View Details"));

            button.AddEventListener(EventType.Click, (sender, e) => {
                var targetButton = (LightElementNode)sender;
                var parentRow = tr;

                string employeeName = "Unknown";
                int cellIndex = 0;
                foreach (var child in parentRow._children)
                {
                    if (child is LightElementNode cellNode && cellNode.TagName == "td")
                    {
                        cellIndex++;
                        if (cellIndex == 2)
                        {
                            foreach (var cellChild in cellNode._children)
                            {
                                if (cellChild is LightTextNode textNode)
                                {
                                    employeeName = textNode.Text;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

                Console.WriteLine($"\n[NAVIGATION EVENT] Redirecting to details page for: {employeeName}");
                Console.WriteLine($"Full info about {employeeName}");
            });

            buttons.Add(button);
            tr.AddChild(button);
            tbody.AddChild(tr);
        }

        table.AddChild(tbody);

        Console.WriteLine("Structure:");
        table.PrintStructure();

        Console.WriteLine("\nHTML Output:");
        Console.WriteLine(table.GetOuterHTML());

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].TriggerEvent(EventType.Click);
        }
    }
}