using System;

namespace WarOfNovus
{
    public class MagicAttack : IAttackStrategy
    {
        public void ExecuteAttack(Player player, Character enemy)
        {
            Console.WriteLine($"{player.Name} melakukan serangan sihir pada {enemy.Name}!");
            enemy.Health -= (player.AttackPower * 2 - enemy.Defense);
        }
    }
}
