using Composite.CompositePattern;
using Composite;
using Composite.CompositePattern.Visitor;
using Composite.CompositePattern.Command.Commands;
using Composite.CompositePattern.Command;

class Program
{
    static void Main(string[] args)
    {
        var commandManager = new CommandManager();

        var table = new LightElementNode("table", DisplayType.Block, ClosingType.WithClosingTag);

        ICommand addCssClassCommand = new AddCssClassCommand(table, "data-table");
        commandManager.ExecuteCommand(addCssClassCommand);

        var thead = new LightElementNode("thead", DisplayType.Block, ClosingType.WithClosingTag);
        var headerRow = new LightElementNode("tr", DisplayType.Block, ClosingType.WithClosingTag);

        ICommand addTheadCommand = new AddChildCommand(table, thead);
        commandManager.ExecuteCommand(addTheadCommand);

        ICommand addHeaderRowCommand = new AddChildCommand(thead, headerRow);
        commandManager.ExecuteCommand(addHeaderRowCommand);

        string[] headers = { "ID", "Name", "Position", "Salary", "Photo" };
        foreach (var headerText in headers)
        {
            var th = new LightElementNode("th", DisplayType.Block, ClosingType.WithClosingTag);

            ICommand addTextCommand = new AddChildCommand(th, new LightTextNode(headerText));
            commandManager.ExecuteCommand(addTextCommand);

            ICommand addThCommand = new AddChildCommand(headerRow, th);
            commandManager.ExecuteCommand(addThCommand);
        }

        var tbody = new LightElementNode("tbody", DisplayType.Block, ClosingType.WithClosingTag);

        ICommand addTbodyCommand = new AddChildCommand(table, tbody);
        commandManager.ExecuteCommand(addTbodyCommand);

        string[][] data = new string[][]
        {
            new string[] { "1", "Yan Rijenko", "Developer", "25,000", "C:\\invalidPath" },
            new string[] { "2", "Denis Linevych", "Designer", "15,000", "https://img.icons8.com/?size=100&id=17904&format=png&color=000000" },
            new string[] { "3", "Oleksiy Semenchyk", "Manager", "20,000", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "oleksiy.jpg") }
        };

        List<LightElementNode> buttons = new List<LightElementNode>();

        foreach (var cellData in data)
        {
            var tr = new LightElementNode("tr", DisplayType.Block, ClosingType.WithClosingTag);

            ICommand addRowClassCommand = new AddCssClassCommand(tr, "data-row");
            commandManager.ExecuteCommand(addRowClassCommand);

            for (int i = 0; i < cellData.Length - 1; i++)
            {
                var td = new LightElementNode("td", DisplayType.Block, ClosingType.WithClosingTag);

                ICommand addCellClassCommand = new AddCssClassCommand(td, "data-cell");
                commandManager.ExecuteCommand(addCellClassCommand);

                ICommand addCellTextCommand = new AddChildCommand(td, new LightTextNode(cellData[i]));
                commandManager.ExecuteCommand(addCellTextCommand);

                ICommand addTdCommand = new AddChildCommand(tr, td);
                commandManager.ExecuteCommand(addTdCommand);
            }

            var photoCell = new LightElementNode("td", DisplayType.Block, ClosingType.WithClosingTag);

            ICommand addPhotoCellClassCommand = new AddCssClassCommand(photoCell, "photo-cell");
            commandManager.ExecuteCommand(addPhotoCellClassCommand);

            string imagePath = cellData[4];
            var imageNode = new LightImageNode(imagePath, $"Photo of {cellData[1]}", 50, 50);

            ICommand addImageClassCommand = new AddCssClassCommand(imageNode, "profile-photo");
            commandManager.ExecuteCommand(addImageClassCommand);

            ICommand addImageCommand = new AddChildCommand(photoCell, imageNode);
            commandManager.ExecuteCommand(addImageCommand);

            ICommand addPhotoCellCommand = new AddChildCommand(tr, photoCell);
            commandManager.ExecuteCommand(addPhotoCellCommand);

            var button = new LightElementNode("button", DisplayType.Inline, ClosingType.WithClosingTag);

            ICommand addButtonClassCommand = new AddCssClassCommand(button, "link-button");
            commandManager.ExecuteCommand(addButtonClassCommand);

            ICommand addButtonTextCommand = new AddChildCommand(button, new LightTextNode("View Details"));
            commandManager.ExecuteCommand(addButtonTextCommand);

            LightEventHandler clickHandler = (sender, e) => {
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
            };

            ICommand addEventCommand = new AddEventListenerCommand(button, EventType.Click, clickHandler);
            commandManager.ExecuteCommand(addEventCommand);

            buttons.Add(button);

            ICommand addButtonCommand = new AddChildCommand(tr, button);
            commandManager.ExecuteCommand(addButtonCommand);

            ICommand addTrCommand = new AddChildCommand(tbody, tr);
            commandManager.ExecuteCommand(addTrCommand);
        }

        Console.WriteLine("Command history:");
        foreach (var commandDescription in commandManager.GetCommandHistory())
        {
            Console.WriteLine($"- {commandDescription}");
        }

        Console.WriteLine("\nStructure:");
        table.PrintStructure();

        Console.WriteLine("\nHTML Output:");
        Console.WriteLine(table.GetOuterHTML());

        Console.WriteLine("\nUndo 10 commands:");
        for (int i = 0; i < 10; i++)
        {
            if (commandManager.CanUndo())
            {
                commandManager.Undo();
                Console.WriteLine($"Undo #{i + 1}");
            }
        }

        Console.WriteLine("\nHTML after Undo:");
        Console.WriteLine(table.GetOuterHTML());
    }
}