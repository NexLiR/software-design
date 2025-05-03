using Composite.CompositePattern;
using Composite;
using Composite.CompositePattern.Template;

class Program
{
    static void Main(string[] args)
    {
        var table = new LightElementNodeWithHooks("table", DisplayType.Block, ClosingType.WithClosingTag);
        table.SetAttribute("id", "employee-table");
        table.AddCssClass("data-table");

        var thead = new LightElementNodeWithHooks("thead", DisplayType.Block, ClosingType.WithClosingTag);
        var headerRow = new LightElementNodeWithHooks("tr", DisplayType.Block, ClosingType.WithClosingTag);

        string[] headers = { "ID", "Name", "Position", "Salary", "Photo", "Actions" };
        foreach (var headerText in headers)
        {
            var th = new LightElementNodeWithHooks("th", DisplayType.Block, ClosingType.WithClosingTag);
            th.AddChild(new LightTextNodeWithHooks(headerText));
            headerRow.AddChild(th);
        }

        thead.AddChild(headerRow);
        table.AddChild(thead);

        var tbody = new LightElementNodeWithHooks("tbody", DisplayType.Block, ClosingType.WithClosingTag);
        tbody.SetAttribute("id", "employee-table-body");

        string[][] data = new string[][]
        {
            new string[] { "1", "Yan Rijenko", "Developer", "25,000", "C:\\invalidPath" },
            new string[] { "2", "Denis Linevych", "Designer", "15,000", "https://img.icons8.com/?size=100&id=17904&format=png&color=000000" },
            new string[] { "3", "Oleksiy Semenchyk", "Manager", "20,000", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "oleksiy.jpg") }
        };

        List<LightElementNodeWithHooks> buttons = new List<LightElementNodeWithHooks>();

        foreach (var cellData in data)
        {
            var tr = new LightElementNodeWithHooks("tr", DisplayType.Block, ClosingType.WithClosingTag);
            tr.AddCssClass("data-row");
            tr.SetAttribute("data-employee-id", cellData[0]);

            for (int i = 0; i < cellData.Length - 1; i++)
            {
                var td = new LightElementNodeWithHooks("td", DisplayType.Block, ClosingType.WithClosingTag);
                td.AddCssClass("data-cell");
                td.AddChild(new LightTextNodeWithHooks(cellData[i]));
                tr.AddChild(td);
            }

            var photoCell = new LightElementNodeWithHooks("td", DisplayType.Block, ClosingType.WithClosingTag);
            photoCell.AddCssClass("photo-cell");

            string imagePath = cellData[4];
            var imageNode = new LightImageNode(imagePath, $"Photo of {cellData[1]}", 50, 50);
            photoCell.AddChild(imageNode);
            tr.AddChild(photoCell);

            var actionsCell = new LightElementNodeWithHooks("td", DisplayType.Block, ClosingType.WithClosingTag);
            actionsCell.AddCssClass("actions-cell");

            var button = new LightElementNodeWithHooks("button", DisplayType.Inline, ClosingType.WithClosingTag);
            button.AddCssClass("view-button");
            button.SetAttribute("data-id", cellData[0]);
            button.AddChild(new LightTextNodeWithHooks("View Details"));

            button.AddEventListener(EventType.Click, (sender, e) => {
                var targetButton = (LightElementNodeWithHooks)sender;
                var parentRow = tr;

                string employeeName = "Unknown";
                int cellIndex = 0;
                foreach (var child in parentRow._children)
                {
                    if (child is LightElementNodeWithHooks cellNode && cellNode.TagName == "td")
                    {
                        cellIndex++;
                        if (cellIndex == 2)
                        {
                            foreach (var cellChild in cellNode._children)
                            {
                                if (cellChild is LightTextNodeWithHooks textNode)
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
    }
}