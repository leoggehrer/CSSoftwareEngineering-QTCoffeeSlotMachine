namespace QTCoffeeSlotMachine.AspMvc.Controllers
{
    public class ProductsController : GenericController<Logic.Entities.Product, Models.Product>
    {
        public ProductsController(Logic.Controllers.ProductsController controller) : base(controller)
        {
        }

        private Logic.Entities.SlotMachine[]? slotMachines = null;
        public Logic.Entities.SlotMachine[] SlotMachines
        {
            get
            {
                if (slotMachines == null)
                {
                    Task.Run(async () =>
                    {
                        using var ctrl = new Logic.Controllers.SlotMachinesController();

                        slotMachines = await ctrl.GetAllAsync();
                    }).Wait();
                }
                return slotMachines ?? Array.Empty<Logic.Entities.SlotMachine>();
            }
        }
        protected override Models.Product BeforeView(Models.Product model, ActionMode actionMode)
        {
            model.Location = SlotMachines.FirstOrDefault(s => s.Id == model.SlotMachineId)?.Location ?? string.Empty;
            model.SlotMachines = SlotMachines;

            return base.BeforeView(model, actionMode);
        }
    }
}
