
namespace QTCoffeeSlotMachine.Logic.Controllers
{
    public class ProductsController : GenericController<Entities.Product>
    {
        public ProductsController()
        {
        }

        public ProductsController(ControllerObject other) : base(other)
        {
        }

        public async Task<Entities.Product[]> QueryAsync(int? slotMachineId, string? productName)
        {
            var query = EntitySet.AsQueryable();

            if (slotMachineId != null)
            {
                query = query.Where(e => e.SlotMachineId == slotMachineId.Value);
            }
            if (productName != null)
            {
                query = query.Where(e => e.Name == productName);
            }
            return await query.AsNoTracking().ToArrayAsync();
        }
    }
}
