using System;

namespace SimpleCQRS.Queries
{
    public class GetInventoryDetailsQueryHandler : QueryHandler<Guid, InventoryItemDetailsDto>
    {
        public override InventoryItemDetailsDto Handle(Guid id)
        {
            return BullShitDatabase.details[id];
        }
    }
}
