using System;

namespace WarOfNovus
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; }

        public Character(string name, int health, int attack, int defense, int level)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            Level = level;
        }

        public abstract void Attack(Character target);

        public bool IsAlive() => Health > 0;
    }
}
