namespace QTCoffeeSlotMachine.AspMvc.Models
{
    public class SlotMachine : VersionModel
    {
        [Required]
        [MaxLength(128)]
        public string Location { get; set; } = string.Empty;
        [MaxLength(256)]
        public string Address { get; set; } = string.Empty;
        public int Price { get; set; } = 50;
        public int DepoteCoin5 { get; set; }
        public int DepoteCoin10 { get; set; }
        public int DepoteCoin20 { get; set; }
        public int DepoteCoin50 { get; set; }
        public int DepoteCoin100 { get; set; }
        public int DepoteCoin200 { get; set; }
    }
}
