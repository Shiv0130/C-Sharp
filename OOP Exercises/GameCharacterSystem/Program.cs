//Need to correct this program
using GameCharacterSystem;

Character warrior = new Warrior();
warrior.SetHealth();
warrior.TakeDamage(10);
Console.WriteLine(warrior.Attack());

Character mage = new Mage();
mage.SetHealth();
mage.TakeDamage(20);
Console.WriteLine(mage.Attack());