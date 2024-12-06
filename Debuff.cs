namespace WarOfNovus
{
    public class Debuff : StatusEffect
    {
        private readonly int _healthDecrease;

        public Debuff(int duration, int healthDecrease)
            : base(duration)
        {
            _healthDecrease = healthDecrease;
        }

        public override void ApplyEffect(Character character)
        {
            character.Health -= _healthDecrease;
        }
    }
}