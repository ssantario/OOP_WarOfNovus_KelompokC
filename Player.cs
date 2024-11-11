using System;

namespace WarOfNovus
{
    public class Player : Character
    {
        public string Nation { get; private set; }
        public string Job { get; private set; }

        public Player(string name, string nation, string job) : base(name, 100, 10, 5, 1)
        {
            Nation = nation;
            Job = job;
            SetupCharacter();
        }

        private void SetupCharacter()
        {
            // Setup spesifik berdasarkan Nation dan Job
            if (Nation == "Bellato")
            {
                // Setup karakteristik Bellato
                Health += 10;
                Attack += 5;
            }
            else if (Nation == "Cora")
            {
                // Setup karakteristik Cora
                Health += 5;
                Attack += 10;
            }
            else if (Nation == "Accretia")
            {
                // Setup karakteristik Accretia
                Defense += 10;
                Attack += 5;
            }
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} menyerang {target.Name}!");
            // Logika serangan ditambahkan di sini
        }
    }
}
