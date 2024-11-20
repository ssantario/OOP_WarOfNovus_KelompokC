using System;

namespace WarOfNovus
{
    public class Player : Character
    {
        public string Nation { get; private set; }
        public string Job { get; private set; }

        public Player(string name, string nation, string job)
            : base(name, 100, 10, 5, 1)
        {
            Nation = nation;
            Job = job;
            SetupCharacter();
        }

        private void SetupCharacter()
        {
            if (Nation == "Bellato")
            {
                Health += 10;
                AttackPower += 5;
            }
            else if (Nation == "Cora")
            {
                Health += 5;
                AttackPower += 10;
            }
            else if (Nation == "Accretia")
            {
                Defense += 10;
                AttackPower += 5;
            }
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} menyerang {target.Name}!");
            target.Health -= (AttackPower - target.Defense);
        }
    }
}
