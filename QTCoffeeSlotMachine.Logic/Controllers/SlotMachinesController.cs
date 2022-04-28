
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

        public override Task<SlotMachine> InsertAsync(SlotMachine entity)
        {
            CheckEntity(entity);

            return base.InsertAsync(entity);
        }
        public override Task<IEnumerable<SlotMachine>> InsertAsync(IEnumerable<SlotMachine> entities)
        {
            entities.ToList().ForEach(e => CheckEntity(e));

            return base.InsertAsync(entities);
        }

        public override Task<SlotMachine> UpdateAsync(SlotMachine entity)
        {
            CheckEntity(entity);

            return base.UpdateAsync(entity);
        }

        public override Task<IEnumerable<SlotMachine>> UpdateAsync(IEnumerable<SlotMachine> entities)
        {
            entities.ToList().ForEach(e => CheckEntity(e));

            return base.UpdateAsync(entities);
        }

        private void CheckEntity(SlotMachine entity)
        {
            if (entity.Price < 0)
                throw new Modules.Exceptions.LogicException($"....");

            if (entity.DepoteCoin5 < 0)
                throw new Modules.Exceptions.LogicException($"....");

            if (entity.DepoteCoin10 < 0)
                throw new Modules.Exceptions.LogicException($"....");

            if (entity.DepoteCoin20 < 0)
                throw new Modules.Exceptions.LogicException($"....");

            if (entity.DepoteCoin50 < 0)
                throw new Modules.Exceptions.LogicException($"....");

            if (entity.DepoteCoin100 < 0)
                throw new Modules.Exceptions.LogicException($"....");

            if (entity.DepoteCoin200 < 0)
                throw new Modules.Exceptions.LogicException($"....");
        }
    }
}
