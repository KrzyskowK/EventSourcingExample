
using System;
namespace SimpleCQRS
{
    public class CheckInItemsToInventoryCommand : Command
    {
        public Guid InventoryItemId;
        public readonly int Count;

        public CheckInItemsToInventoryCommand(Guid inventoryItemId, int count) {
            InventoryItemId = inventoryItemId;
            Count = count;
        }
    }
}
