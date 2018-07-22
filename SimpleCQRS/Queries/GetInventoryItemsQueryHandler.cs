using System.Collections.Generic;

namespace SimpleCQRS.Queries
{
    public class GetInventoryItemsQueryHandler
    {
        public IEnumerable<InventoryItemListDto> Handle()
        {
            return BullShitDatabase.list;
        }
    }
}
