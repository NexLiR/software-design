using Mediator.AirTrafficControl;

class Program
{
    static void Main(string[] args)
    {
        var runway1 = new Runway();
        var runway2 = new Runway();

        var aircraft1 = new Aircraft("Flight-001", 0);
        var aircraft2 = new Aircraft("Flight-002", 0);
        var aircraft3 = new Aircraft("Flight-003", 0);

        var commandCentre = new CommandCentre(
            new Runway[] { runway1, runway2 },
            new Aircraft[] { aircraft1, aircraft2, aircraft3 }
        );

        aircraft1.Land();
        commandCentre.DisplaySystemStatus();

        aircraft2.Land();
        commandCentre.DisplaySystemStatus();

        aircraft3.Land();

        aircraft1.TakeOff();
        commandCentre.DisplaySystemStatus();

        aircraft3.Land();
        commandCentre.DisplaySystemStatus();
    }
}