namespace WarOfNovus
{
    public class Debuff : StatusEffect
    {
        private readonly int _healthDecrease;
        private readonly int _attackDecrease;
        private readonly int _defenseDecrease;

        public Debuff(int duration, int healthDecrease, int attackDecrease, int defenseDecrease)
            : base(duration)
        {
            _healthDecrease = healthDecrease;
            _attackDecrease = attackDecrease;
            _defenseDecrease = defenseDecrease;
        }

        public override void ApplyEffect(Character character)
        {
            character.Health -= _healthDecrease;
            character.AttackPower -= _attackDecrease;
            character.Defense -= _defenseDecrease;
        }
    }
}