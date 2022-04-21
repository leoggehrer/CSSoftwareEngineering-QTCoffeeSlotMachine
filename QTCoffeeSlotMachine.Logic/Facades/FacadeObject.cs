//@CodeCopy
//MdStart

using QTCoffeeSlotMachine.Logic.Controllers;

namespace QTCoffeeSlotMachine.Logic.Facades
{
    public abstract class FacadeObject
    {
        internal ControllerObject ControllerObject { get; private set; }

        protected FacadeObject(ControllerObject controllerObject)
        {
            ControllerObject = controllerObject;
        }
    }
}

//MdEnd
