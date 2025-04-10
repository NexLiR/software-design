using Decorator.DecoratorPattern.Equipments;
using Decorator.DecoratorPattern.Heroes;

class Program
{
    static void Main(string[] args)
    {
        Hero warrior = new Warrior("Lae`zel");
        Hero paladin = new Paladin("Minthara");

        Console.WriteLine("Base Heroes Stats:");
        warrior.DisplayStats();
        paladin.DisplayStats();

        Console.WriteLine("Heroes with Equipment:");
        Hero equippedWarrior = new PlateArmor(new Sword(new Sword(warrior)));
        equippedWarrior.DisplayStats();
        Hero equippedPaladin = new StealArmor(new Sword(new Shield(paladin)));
        equippedPaladin.DisplayStats();
    }
}