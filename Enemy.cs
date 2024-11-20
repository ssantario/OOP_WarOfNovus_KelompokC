using System;

namespace WarOfNovus
{
    public class Enemy : Character
    {
        public string Element { get; private set; }

        public Enemy(string name, int health, int attackPower, int defense, string element)
            : base(name, health, attackPower, defense, 1)
        {
            Element = element;
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} menyerang {target.Name} dengan elemen {Element}!");
            target.Health -= (AttackPower - target.Defense);
        }
    }
}
