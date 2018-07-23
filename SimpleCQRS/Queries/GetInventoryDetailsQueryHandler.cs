using System;

namespace SimpleCQRS.Queries
{
    public class GetInventoryDetailsQueryHandler : QueryHandler<Guid, InventoryDetailsDto>
    {
        public override InventoryDetailsDto Handle(Guid id)
        {
            return BullShitDatabase.details[id];
        }
    }
}
