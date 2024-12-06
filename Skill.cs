namespace WarOfNovus
{
    public abstract class Skill
    {
        public string Name { get; }
        public int Cooldown { get; protected set; } // Make setter protected

        protected Skill(string name, int cooldown)
        {
            Name = name;
            Cooldown = 0; // Initialize cooldown to 0
        }

        public abstract void Use(Character user, Character target);

        public void ReduceCooldown()
        {
            if (Cooldown > 0)
                Cooldown--;
        }
    }

    public class BuffSkill : Skill
    {
        private readonly Buff _buff;

        public BuffSkill(string name, int cooldown, Buff buff)
            : base(name, cooldown)
        {
            _buff = buff;
        }

        public override void Use(Character user, Character target)
        {
            if (Cooldown == 0)
            {
                Cooldown = 3;
                user.ApplyStatusEffect(_buff);
                Console.WriteLine($"{user.Name} uses {Name}, gaining a buff!");
            }
            else
            {
                Console.WriteLine($"{Name} is on cooldown for {Cooldown} more turns.");
            }
        }
    }

    public class DebuffSkill : Skill
    {
        private readonly Debuff _debuff;

        public DebuffSkill(string name, int cooldown, Debuff debuff)
            : base(name, cooldown)
        {
            _debuff = debuff;
        }

        public override void Use(Character user, Character target)
        {
            if (Cooldown == 0)
            {
                Cooldown = 3;
                target.ApplyStatusEffect(_debuff);
                Console.WriteLine($"{user.Name} uses {Name}, applying a debuff to {target.Name}!");
            }
            else
            {
                Console.WriteLine($"{Name} is on cooldown for {Cooldown} more turns.");
            }
        }
    }
}
