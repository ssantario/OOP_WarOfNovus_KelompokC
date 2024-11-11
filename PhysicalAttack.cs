using System;

namespace WarOfNovus
{
    public class PhysicalAttack : IAttackStrategy
    {
        public void ExecuteAttack(Player player, Character enemy)
        {
            Console.WriteLine($"{player.Name} melakukan serangan fisik pada {enemy.Name}!");
            enemy.Health -= (player.Attack - enemy.Defense);
        }
    }
}
