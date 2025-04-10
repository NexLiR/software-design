using Proxy;
using Proxy.ProxyPattern;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        FileHelper.CreateTestFiles();

        Console.WriteLine("Using original SmartTextReader:");
        ISmartTextReader originalReader = new SmartTextReader();
        char[][] content = originalReader.ReadTextFile("test.txt");
        FileHelper.PrintContent(content);

        Console.WriteLine("\n\n\nUsing SmartTextChecker:");
        ISmartTextReader checkerProxy = new SmartTextChecker();
        Console.WriteLine("normal file:");
        content = checkerProxy.ReadTextFile("test.txt");
        FileHelper.PrintContent(content);
        Console.WriteLine("\nrestricted file:");
        content = checkerProxy.ReadTextFile("restricted_test.txt");
        FileHelper.PrintContent(content);

        Console.WriteLine("\n\n\nUsing SmartTextReaderLocker:");
        ISmartTextReader lockerProxy = new SmartTextReaderLocker(@".*restricted.*\.txt");

        Console.WriteLine("normal file:");
        content = lockerProxy.ReadTextFile("test.txt");
        FileHelper.PrintContent(content);

        Console.WriteLine("\nrestricted file:");
        content = lockerProxy.ReadTextFile("restricted_test.txt");
        FileHelper.PrintContent(content);
    }
}