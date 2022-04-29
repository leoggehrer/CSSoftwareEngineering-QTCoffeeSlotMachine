
using QTCoffeeSlotMachine.Logic.Entities;

namespace QTCoffeeSlotMachine.Logic.Controllers
{
    public class SlotMachinesController : GenericController<Entities.SlotMachine>
    {
        public SlotMachinesController()
        {
        }

        public SlotMachinesController(ControllerObject other) : base(other)
        {
        }
        protected override void ValidateEntity(ActionType actionType, SlotMachine entity)
        {
            CheckEntity(entity);

            base.ValidateEntity(actionType, entity);
        }

        private void CheckEntity(SlotMachine entity)
        {
            if (entity.Price < 0)
                throw new Modules.Exceptions.LogicException($"Invalide value {entity.Price} for {nameof(entity.Price)}");

            if (entity.DepoteCoin5 < 0)
                throw new Modules.Exceptions.LogicException($"Invalide value {entity.DepoteCoin5} for {nameof(entity.DepoteCoin5)}");

            if (entity.DepoteCoin10 < 0)
                throw new Modules.Exceptions.LogicException($"Invalide value {entity.DepoteCoin10} for {nameof(entity.DepoteCoin10)}");

            if (entity.DepoteCoin20 < 0)
                throw new Modules.Exceptions.LogicException($"Invalide value {entity.DepoteCoin20} for {nameof(entity.DepoteCoin20)}");

            if (entity.DepoteCoin50 < 0)
                throw new Modules.Exceptions.LogicException($"Invalide value {entity.DepoteCoin50} for {nameof(entity.DepoteCoin50)}");

            if (entity.DepoteCoin100 < 0)
                throw new Modules.Exceptions.LogicException($"Invalide value {entity.DepoteCoin100} for {nameof(entity.DepoteCoin100)}");

            if (entity.DepoteCoin200 < 0)
                throw new Modules.Exceptions.LogicException($"Invalide value {entity.DepoteCoin200} for {nameof(entity.DepoteCoin200)}");
        }
    }
}
