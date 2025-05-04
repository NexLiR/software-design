using Composite.CompositePattern;
using Composite;
using Composite.CompositePattern.Visitor;

class Program
{
    static void Main(string[] args)
    {
        var table = new LightElementNodeVisitable("table", DisplayType.Block, ClosingType.WithClosingTag);
        table.AddCssClass("data-table");

        var thead = new LightElementNodeVisitable("thead", DisplayType.Block, ClosingType.WithClosingTag);
        var headerRow = new LightElementNodeVisitable("tr", DisplayType.Block, ClosingType.WithClosingTag);
        headerRow.AddCssClass("header-row");

        string[] headers = { "ID", "Name", "Position", "Salary", "Photo", "Actions" };
        foreach (var headerText in headers)
        {
            var th = new LightElementNodeVisitable("th", DisplayType.Block, ClosingType.WithClosingTag);
            th.AddCssClass("header-cell");
            th.AddChild(new LightTextNodeVisitable(headerText));
            headerRow.AddChild(th);
        }

        thead.AddChild(headerRow);
        table.AddChild(thead);

        var tbody = new LightElementNodeVisitable("tbody", DisplayType.Block, ClosingType.WithClosingTag);

        string[][] data = new string[][]
        {
            new string[] { "1", "Yan Rijenko", "Developer", "25,000", "C:\\invalidPath" },
            new string[] { "2", "Denis Linevych", "Designer", "15,000", "https://img.icons8.com/?size=100&id=17904&format=png&color=000000" },
            new string[] { "3", "Oleksiy Semenchyk", "Manager", "20,000", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "oleksiy.jpg") }
        };

        List<LightElementNode> buttons = new List<LightElementNode>();

        foreach (var cellData in data)
        {
            var tr = new LightElementNodeVisitable("tr", DisplayType.Block, ClosingType.WithClosingTag);
            tr.AddCssClass("data-row");

            if (cellData[0] == "1")
            {
                tr.AddCssClass("developer-row");
            }
            else if (cellData[0] == "2")
            {
                tr.AddCssClass("designer-row");
            }
            else if (cellData[0] == "3")
            {
                tr.AddCssClass("manager-row");
            }

            for (int i = 0; i < cellData.Length - 1; i++)
            {
                var td = new LightElementNodeVisitable("td", DisplayType.Block, ClosingType.WithClosingTag);
                td.AddCssClass("data-cell");

                if (i == 2)
                {
                    td.AddCssClass("position-cell");
                    if (cellData[i] == "Developer")
                    {
                        td.AddCssClass("developer-position");
                    }
                    else if (cellData[i] == "Designer")
                    {
                        td.AddCssClass("designer-position");
                    }
                    else if (cellData[i] == "Manager")
                    {
                        td.AddCssClass("manager-position");
                    }
                }

                td.AddChild(new LightTextNodeVisitable(cellData[i]));
                tr.AddChild(td);
            }

            var photoCell = new LightElementNodeVisitable("td", DisplayType.Block, ClosingType.WithClosingTag);
            photoCell.AddCssClass("photo-cell");

            string imagePath = cellData[4];
            var imageNode = new LightImageNode(imagePath, $"Photo of {cellData[1]}", 50, 50);
            imageNode.AddCssClass("profile-photo");
            photoCell.AddChild(imageNode);
            tr.AddChild(photoCell);

            var actionsCell = new LightElementNodeVisitable("td", DisplayType.Block, ClosingType.WithClosingTag);
            actionsCell.AddCssClass("actions-cell");

            var button = new LightElementNodeVisitable("button", DisplayType.Inline, ClosingType.WithClosingTag);
            button.AddCssClass("view-button");

            if (cellData[0] == "1")
            {
                button.AddCssClass("developer-button");
            }
            else if (cellData[0] == "2")
            {
                button.AddCssClass("designer-button");
            }
            else if (cellData[0] == "3")
            {
                button.AddCssClass("manager-button");
            }

            button.AddChild(new LightTextNodeVisitable("View Details"));

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

        Console.WriteLine("\n1. Applaying styles for developers:");
        var developerStyleVisitor = new StyleApplyVisitor("developer-position", "color: blue; font-weight: bold;");
        table.Accept(developerStyleVisitor);

        Console.WriteLine("\n2. Applaying styles for designers:");
        var designerStyleVisitor = new StyleApplyVisitor("designer-position", "color: purple; font-style: italic;");
        table.Accept(designerStyleVisitor);

        Console.WriteLine("\n3. Applaying styles for managers:");
        var managerStyleVisitor = new StyleApplyVisitor("manager-position", "color: green; text-decoration: underline;");
        table.Accept(managerStyleVisitor);

        Console.WriteLine("\n4. Applaying styles for buttons:");
        var buttonStyleVisitor = new StyleApplyVisitor("view-button", "background-color: #007bff; color: white;");
        table.Accept(buttonStyleVisitor);

        Console.WriteLine("\n5. Applaying styles for data in rows:");
        var rowStyleVisitor = new StyleApplyVisitor("data-row", "border-bottom: 1px solid #ddd;");
        table.Accept(rowStyleVisitor);
    }
}