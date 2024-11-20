namespace WarOfNovus
{
    public interface IAttackStrategy
    {
        void ExecuteAttack(Player player, Character enemy);
        
        int CalculateDamage(Character attacker, Character defender, bool isCriticalHit);
    }
}
