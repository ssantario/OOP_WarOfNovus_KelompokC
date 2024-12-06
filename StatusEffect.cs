namespace WarOfNovus
{
    public abstract class StatusEffect
    {
        public int Duration { get; set; }

        protected StatusEffect(int duration)
        {
            Duration = duration;
        }

        public abstract void ApplyEffect(Character character);
    }
}