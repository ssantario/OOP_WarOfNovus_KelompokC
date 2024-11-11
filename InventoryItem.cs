namespace WarOfNovus
{
    public abstract class InventoryItem
    {
        public abstract string Description { get; }
        public abstract int GetPower();
    }
}
