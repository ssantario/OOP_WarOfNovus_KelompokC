namespace WarOfNovus
{
    public class PoisonedDecorator : InventoryItem
    {
        private readonly InventoryItem _baseItem;

        public PoisonedDecorator(InventoryItem baseItem)
        {
            _baseItem = baseItem;
        }

        public override string Description => _baseItem.Description + " with Poison";
        public override int GetPower() => _baseItem.GetPower() + 5;
    }
}
