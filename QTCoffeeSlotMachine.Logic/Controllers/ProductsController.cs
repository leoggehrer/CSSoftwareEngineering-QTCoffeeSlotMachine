
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
    }
}
