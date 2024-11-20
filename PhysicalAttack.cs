using System;

namespace WarOfNovus
{
    public class PhysicalAttack : IAttackStrategy
    {
        public void ExecuteAttack(Player attacker, Character target)
        {
            int damage = CalculateDamage(attacker, target, false); // Assume no critical hit here
            target.Health -= damage;
            Console.WriteLine($"{attacker.Name} menyerang {target.Name} dengan serangan fisik! Damage: {damage}");
        }

        public int CalculateDamage(Character attacker, Character target, bool isCritical)
        {
            int baseDamage = Math.Max(0, attacker.AttackPower - target.Defense);
            return isCritical ? baseDamage * 2 : baseDamage; // Double damage for critical hit
        }
    }
}
