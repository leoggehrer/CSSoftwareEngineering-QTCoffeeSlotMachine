namespace QTCoffeeSlotMachine.Logic.Entities
{
    [Table("SlotMachines", Schema = "App")]
    [Index(nameof(Location), IsUnique = true)]
    public class SlotMachine : VersionEntity
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

        [NotMapped]
        public int DepoteValue
        {
            get
            {
                return DepoteCoin5 * 5 
                        + DepoteCoin10 * 10 
                        + DepoteCoin20 * 20 
                        + DepoteCoin50 * 50 
                        + DepoteCoin100 * 100 
                        + DepoteCoin200 * 200;
            }
        }
        // Navigation properties
        public List<Product> Products { get; set; } = new();
    }
}
