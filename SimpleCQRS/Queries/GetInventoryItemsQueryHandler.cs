using System.Collections.Generic;

namespace SimpleCQRS.Queries
{
    public class GetInventoryItemsQueryHandler : QueryHandler<IEnumerable<InventoryItemListDto>>
    {
        public override IEnumerable<InventoryItemListDto> Handle()
        {
            return BullShitDatabase.list;
        }
    }
}
