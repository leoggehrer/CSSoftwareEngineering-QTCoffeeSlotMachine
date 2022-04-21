//@CodeCopy
//MdStart

namespace QTCoffeeSlotMachine.Logic
{
    public interface IVersionable : IIdentifyable
    {
        byte[]? RowVersion { get; }
    }
}
//MdEnd
