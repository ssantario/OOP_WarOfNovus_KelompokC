namespace WarOfNovus
{
    public class Buff : StatusEffect
    {
        private readonly int _attackIncrease;
        private readonly int _defenseIncrease;

        public Buff(int duration, int attackIncrease, int defenseIncrease)
            : base(duration)
        {
            _attackIncrease = attackIncrease;
            _defenseIncrease = defenseIncrease;
        }

        public override void ApplyEffect(Character character)
        {
            character.AttackPower += _attackIncrease;
            character.Defense += _defenseIncrease;
        }
    }
}