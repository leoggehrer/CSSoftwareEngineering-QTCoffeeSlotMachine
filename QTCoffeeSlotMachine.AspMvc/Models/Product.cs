namespace QTCoffeeSlotMachine.AspMvc.Models
{
    public class Product : VersionModel
    {
        public int SlotMachineId { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }

        // Extended properties
        public string Location { get; set; } = string.Empty;

        public Logic.Entities.SlotMachine[] SlotMachines { get; set; } = Array.Empty<Logic.Entities.SlotMachine>();
    }
}
