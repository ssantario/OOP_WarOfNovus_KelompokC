using System;

namespace WarOfNovus
{
    class WarOfNovus
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to War of Novus!");

            // Player Setup
            var player = new Player("Hero", "Bellato", "Warrior");

            // Enemy Setup
            var enemy = EnemyFactory.CreateEnemy("Fire");

            // Battle Example
            IAttackStrategy strategy = new PhysicalAttack();
            strategy.ExecuteAttack(player, enemy);
            Console.WriteLine($"{enemy.Name} Health: {enemy.Health}");

            // Inventory Example
            InventoryItem sword = new Sword();
            InventoryItem poisonedSword = new PoisonedDecorator(sword);
            Console.WriteLine($"Weapon: {poisonedSword.Description} - Power: {poisonedSword.GetPower()}");
        }
    }
}