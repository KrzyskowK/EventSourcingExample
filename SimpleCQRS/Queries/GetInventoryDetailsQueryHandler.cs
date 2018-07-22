using System;

namespace SimpleCQRS.Queries
{
    public class GetInventoryDetailsQueryHandler
    {
        public InventoryItemDetailsDto Handle(Guid id)
        {
            return BullShitDatabase.details[id];
        }
    }
}
