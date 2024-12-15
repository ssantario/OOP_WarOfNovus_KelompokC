using System;
using System.Collections.Generic;

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
        public List<Skill> Skills { get; private set; } = new List<Skill>();
        public bool IsDefending { get; set; }
        public int OriginalAttackPower { get; set; }
        public int OriginalDefense { get; set; }
        public Quest CurrentQuest { get; private set; }

        public Player(string name, Race nation, Job job)
            : base(name, 100, 10, 5, 1)
        {
            Nation = nation;
            Job = job;
            SetupCharacter();
            InitializeSkills();
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

        private void InitializeSkills()
        {
            // Add some example skills
            Skills.Add(new BuffSkill("Power Up", 3, new Buff(3, 5, 0)));
            Skills.Add(new DebuffSkill("Weaken", 3, new Debuff(3, 5, 5, 5))); // Provide all required arguments
        }

        public void AssignQuest(Quest quest)
        {
            CurrentQuest = quest;
            Console.WriteLine($"Quest '{quest.Title}' assigned: {quest.Description}");
        }

        public void CompleteQuestObjective(string objective)
        {
            if (CurrentQuest != null)
            {
                CurrentQuest.CompletionChecker(objective);
            }
        }
//
        //public void DisplayCurrentQuest()
        //{
        //    if (CurrentQuest != null)
        //    {
        //        Console.WriteLine($"Current Quest: {CurrentQuest.Title}");
        //        Console.WriteLine($"Description: {CurrentQuest.Description}");
        //        Console.WriteLine("Objectives:");
        //        foreach (var objective in CurrentQuest.Objectives)
        //        {
        //            Console.WriteLine($"- {objective}");
        //        }
        //        Console.WriteLine($"Reward: {CurrentQuest.Reward}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("No current quest.");
        //    }
        //}

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} menyerang {target.Name}!");
            // Simple damage calculation based on attack and defense
            int damage = Math.Max(0, AttackPower - target.Defense);
            if (target is Player player && player.IsDefending)
            {
                damage /= 2; // Halve the damage if the target is defending
                player.IsDefending = false; // Reset defending flag after attack
            }
            target.Health -= damage;
            Console.WriteLine($"{target.Name} menerima {damage} damage.");

            // Track damage dealt for quest objectives
            if (CurrentQuest != null)
            {
                CurrentQuest.TrackDamageDealt(damage);
            }
        }
    }
}
