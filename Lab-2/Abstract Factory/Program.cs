using Abstract_Factory.TechFactories;

Console.WriteLine("Choosen manufactorer: Samsung");
var creator1 = new SamsungFactory();
var laptop1 = creator1.CreateLaptop();
laptop1.Display();
var smartphone1 = creator1.CreateSmartphone();
smartphone1.Display();
Console.WriteLine("Choosen manufactorer: Xiaomi");
var creator2 = new XiaomiFactory();
var laptop2 = creator2.CreateLaptop();
laptop2.Display();
var smartphone2 = creator2.CreateSmartphone();
smartphone2.Display();