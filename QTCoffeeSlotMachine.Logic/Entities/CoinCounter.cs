namespace QTCoffeeSlotMachine.Logic.Entities
{
    public class CoinCounter : VersionEntity
    {
        public int SlotMachineId { get; set; }
        public ContainerCoinType CoinType { get; set; }
        public int CentValue { get; set; }
        public int Counter { get; set; }

        // Navigation properties
        public SlotMachine? SlotMachine { get; set; }
    }
}
