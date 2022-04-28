
namespace QTCoffeeSlotMachine.Logic.Entities
{
    [Table("Products", Schema = "App")]
    public class Product : VersionEntity
    {
        public int SlotMachineId { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }

        // Navigation properties
        public SlotMachine? SlotMachine { get; set; }
    }
}
