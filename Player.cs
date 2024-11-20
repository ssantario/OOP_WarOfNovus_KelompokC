using System;

namespace WarOfNovus
{
    public enum Race
    {
        Bellato,
        Cora,
        Accretia
    }

    public enum Job
    {
        Warrior,
        Ranger,
        Spiritualist
    }

    public class Player : Character
    {
        public Race Nation { get; private set; }
        public Job Job { get; private set; }

        public Player(string name, Race nation, Job job)
            : base(name, 100, 10, 5, 1)
        {
            Nation = nation;
            Job = job;
            SetupCharacter();
        }

        private void SetupCharacter()
        {
            // Modify player stats based on their Nation and Job
            switch (Nation)
            {
                case Race.Bellato:
                    Health += 10;
                    AttackPower += 5;
                    break;
                case Race.Cora:
                    Health += 5;
                    AttackPower += 10;
                    break;
                case Race.Accretia:
                    Defense += 10;
                    AttackPower += 5;
                    break;
            }

            // Additional job-based modifications (optional)
            if (Job == Job.Spiritualist)
            {
                Health += 20;  // Example of special handling for Spiritualist job
            }
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} menyerang {target.Name}!");
            // Simple damage calculation based on attack and defense
            int damage = Math.Max(0, AttackPower - target.Defense);
            target.Health -= damage;
            Console.WriteLine($"{target.Name} menerima {damage} damage.");
        }
    }
}
