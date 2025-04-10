using Adapter.AdapterPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Using Logger:");
        Logger consoleLogger = new Logger();
        consoleLogger.Log("log message");
        consoleLogger.Error("error");
        consoleLogger.Warn("warning");

        Console.WriteLine("\nUsing FileLoggerAdapter:");
        string logFilePath = "log.txt";
        FileWriter fileWriter = new FileWriter(logFilePath);

        FileLoggerAdapter fileLogger = new FileLoggerAdapter(fileWriter);
        fileLogger.Log("message logged file");
        fileLogger.Error("error logged to file");
        fileLogger.Warn("warning logged to file");
    }
}