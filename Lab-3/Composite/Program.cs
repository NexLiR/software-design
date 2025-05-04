using Composite.CompositePattern;
using Composite;
using Composite.CompositePattern.Visitor;
using Composite.CompositePattern.Command.Commands;
using Composite.CompositePattern.Command;
using Composite.CompositePattern.State;

class Program
{
    static void Main(string[] args)
    {
        var table = new LightElementNode("table", DisplayType.Block, ClosingType.WithClosingTag);
        table.AddCssClass("data-table");

        var thead = new LightElementNode("thead", DisplayType.Block, ClosingType.WithClosingTag);
        var headerRow = new LightElementNode("tr", DisplayType.Block, ClosingType.WithClosingTag);

        string[] headers = { "ID", "Name", "Position", "Salary", "Photo" };
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
            new string[] { "1", "Yan Rijenko", "Developer", "25,000", "C:\\invalidPath" },
            new string[] { "2", "Denis Linevych", "Designer", "15,000", "https://img.icons8.com/?size=100&id=17904&format=png&color=000000" },
            new string[] { "3", "Oleksiy Semenchyk", "Manager", "20,000", System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "images", "oleksiy.jpg") }
        };

        List<LightElementWithState> stateButtons = new List<LightElementWithState>();

        foreach (var cellData in data)
        {
            var tr = new LightElementNode("tr", DisplayType.Block, ClosingType.WithClosingTag);
            tr.AddCssClass("data-row");

            for (int i = 0; i < cellData.Length - 1; i++)
            {
                var td = new LightElementNode("td", DisplayType.Block, ClosingType.WithClosingTag);
                td.AddCssClass("data-cell");
                td.AddChild(new LightTextNode(cellData[i]));
                tr.AddChild(td);
            }

            var photoCell = new LightElementNode("td", DisplayType.Block, ClosingType.WithClosingTag);
            photoCell.AddCssClass("photo-cell");

            string imagePath = cellData[4];
            var imageNode = new LightImageNode(imagePath, $"Photo of {cellData[1]}", 50, 50);
            imageNode.AddCssClass("profile-photo");

            photoCell.AddChild(imageNode);
            tr.AddChild(photoCell);

            var button = new LightElementWithState("button", DisplayType.Inline, ClosingType.WithClosingTag);
            button.AddCssClass("link-button");
            button.AddCssClass("state-button");
            button.AddChild(new LightTextNode("View Details"));


            button.AddChild(new LightTextNode($"Button with state: {cellData[1]}"));

            button.AddEventListener(EventType.Click, (sender, e) => {
                var targetButton = (LightElementWithState)sender;
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

            stateButtons.Add(button);
            tr.AddChild(button);

            tbody.AddChild(tr);
        }
        table.AddChild(tbody);

        Console.WriteLine("Structure:");
        table.PrintStructure();

        Console.WriteLine("\nHTML Output:");
        Console.WriteLine(table.GetOuterHTML());

        for (int i = 0; i < stateButtons.Count; i++)
        {
            stateButtons[i].TriggerEvent(EventType.Click);

            string buttonText = "";
            foreach (var child in stateButtons[i]._children)
            {
                if (child is LightTextNode textNode)
                {
                    buttonText = textNode.Text;
                    break;
                }
            }

            Console.WriteLine($"\nWorking with button: {buttonText}");

            Console.WriteLine("\n[USER ACTION] Moving mouse over the button");
            stateButtons[i].HandleMouseOver();

            Console.WriteLine("\n[USER ACTION] Clicking the button while in hover state");
            stateButtons[i].HandleClick();

            Console.WriteLine("\n[USER ACTION] Clicking the button again while in active state");
            stateButtons[i].HandleClick();

            Console.WriteLine("\n[USER ACTION] Disabling the button");
            stateButtons[i].SetState(stateButtons[i].GetDisabledState());

            Console.WriteLine("\n[USER ACTION] Trying to click disabled button");
            stateButtons[i].HandleClick();
        }
    }
}