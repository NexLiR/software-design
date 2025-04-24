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
            new string[] { "3", "Oleksiy Semenchyk", "Manager", "20,000", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "oleksiy.jpg") }
        };
        
        foreach (var rowData in data)
        {
            var tr = new LightElementNode("tr", DisplayType.Block, ClosingType.WithClosingTag);
            tr.AddCssClass("data-row");
            
            for (int i = 0; i < rowData.Length - 1; i++)
            {
                var td = new LightElementNode("td", DisplayType.Block, ClosingType.WithClosingTag);
                td.AddCssClass("data-cell");
                td.AddChild(new LightTextNode(rowData[i]));
                tr.AddChild(td);
            }
            
            var photoCell = new LightElementNode("td", DisplayType.Block, ClosingType.WithClosingTag);
            photoCell.AddCssClass("photo-cell");
            
            string imagePath = rowData[4];
            var imageNode = new LightImageNode(imagePath, $"Photo of {rowData[1]}", 50, 50);
            imageNode.AddCssClass("profile-photo");
            
            photoCell.AddChild(imageNode);
            tr.AddChild(photoCell);
            
            tbody.AddChild(tr);
        }
        table.AddChild(tbody);

        Console.WriteLine("Structure:");
        table.PrintStructure();
        Console.WriteLine("\nHTML Output:");
        Console.WriteLine(table.GetOuterHTML());
    }
}