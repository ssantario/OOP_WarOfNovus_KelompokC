using System;

namespace WarOfNovus
{
    public class Enemy : Character
    {
        public string Element { get; private set; }

        public Enemy(string name, int health, int attack, int defense, string element)
            : base(name, health, attack, defense, 1)
        {
            Element = element;
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} menyerang {target.Name} dengan elemen {Element}!");
            // Logika serangan musuh
        }
    }
}
