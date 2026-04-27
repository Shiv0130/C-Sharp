<<<<<<< HEAD
﻿//My attempt code
//using GameCharacterSystem;

//Character warrior = new Warrior();
//warrior.SetHealth();
//warrior.TakeDamage(10);
//Console.WriteLine(warrior.Attack());

//Character mage = new Mage();
//mage.SetHealth();
//mage.TakeDamage(20);
//Console.WriteLine(mage.Attack());

//correction
using GameCharacterSystem;

Character warrior = new Warrior(1000); // Set initial health for the warrior
Character mage = new Mage(1000);

Console.WriteLine($"{mage.Attack()}");
Console.WriteLine($"{warrior.Attack()}");

warrior.TakeDamage(68);
mage.TakeDamage(70);
=======
//My attempt code
//using GameCharacterSystem;

//Character warrior = new Warrior();
//warrior.SetHealth();
//warrior.TakeDamage(10);
//Console.WriteLine(warrior.Attack());

//Character mage = new Mage();
//mage.SetHealth();
//mage.TakeDamage(20);
//Console.WriteLine(mage.Attack());

//correction
using GameCharacterSystem;

Character warrior = new Warrior(1000); // Set initial health for the warrior
Character mage = new Mage(1000);

Console.WriteLine($"{mage.Attack()}");
Console.WriteLine($"{warrior.Attack()}");

warrior.TakeDamage(68);
mage.TakeDamage(70);
>>>>>>> dc12548130aeb50905ddce44b8ba16c469423f90
