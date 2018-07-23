using System.Collections.Generic;

namespace SimpleCQRS.Queries
{
    public class GetInventoriesQueryHandler : QueryHandler<IEnumerable<InventoryDto>>
    {
        public override IEnumerable<InventoryDto> Handle()
        {
            return BullShitDatabase.list;
        }
    }
}
