using System;

namespace WarOfNovus
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; } // Ubah nama dari Attack
        public int Defense { get; set; }
        public int Level { get; set; }

        public Character(string name, int health, int attackPower, int defense, int level)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
            Level = level;
        }

        public abstract void Attack(Character target); // Metode abstrak tetap digunakan untuk serangan

        public bool IsAlive() => Health > 0;
    }
}
