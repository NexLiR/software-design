using Prototype;

Virus ancestor = new Virus("Virus1", "1000", 0.85, 100);

Virus child1 = new Virus("Virus1-1", "1001", 0.82, 70);
Virus child2 = new Virus("Virus1-2", "1002", 0.79, 65);

ancestor.AddChild(child1);
ancestor.AddChild(child2);

Virus grandchild1 = new Virus("Virus1-1-1", "10011", 0.75, 40);
Virus grandchild2 = new Virus("Virus1-1-2", "10012", 0.70, 30);

child1.AddChild(grandchild1);
child1.AddChild(grandchild2);

Console.WriteLine("Original Virus");
ancestor.DisplayInfo();

Virus clonedAncestor = (Virus)ancestor.Clone();

clonedAncestor.Name += " (Clone)";
clonedAncestor.Children[0].Name = "Virus1-1 Cloned";

Console.WriteLine("\nCloned Virus");
clonedAncestor.DisplayInfo();

Console.WriteLine($"\nNumber of children in original: {ancestor.Children.Count}");
Console.WriteLine($"Number of children in clone: {clonedAncestor.Children.Count}");
