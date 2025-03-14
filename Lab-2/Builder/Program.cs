using Builder.Builders;
using Builder;

Director director = new Director();
Character hero = director.CreateHero();
Character enemy = director.CreateEnemy();

Console.WriteLine("Hero Information");
hero.DisplayInfo();

Console.WriteLine("Enemy Information");
enemy.DisplayInfo();

Console.WriteLine("Custom Hero Information");
Character customHero = new HeroBuilder()
    .SetName("Main Hero")
    .SetHeight(175)
    .SetBuild("Agile")
    .SetHairColor("Auburn")
    .SetEyeColor("Green")
    .AddInventoryItem("Bow of Truth")
    .AddInventoryItem("Magic Arrows")
    .SetSpecialPower("Eagle Eye")
    .PerformDeed("Protected forest from loggers")
    .Build();

customHero.DisplayInfo();