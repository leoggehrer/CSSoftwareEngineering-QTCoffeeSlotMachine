namespace QTCoffeeSlotMachine.AspMvc.Controllers
{
    public class SlotMachinesController : GenericController<Logic.Entities.SlotMachine, Models.SlotMachine>
    {
        public SlotMachinesController(Logic.Controllers.SlotMachinesController controller) : base(controller)
        {
        }
    }
}
