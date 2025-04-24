using ChainOfResponsibility.CustomerSupportSystem;
class Program
{
    static void Main(string[] args)
    {
        CustomerSupportSystem supportSystem = new CustomerSupportSystem();
        supportSystem.StartSupportMenu();
    }
}