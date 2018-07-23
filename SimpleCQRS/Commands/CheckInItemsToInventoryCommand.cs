
using System;
namespace SimpleCQRS
{
    public class CheckInItemsToInventoryCommand : Command
    {
        public Guid InventoryId;
        public readonly int Count;

        public CheckInItemsToInventoryCommand(Guid inventoryId, int count) {
            InventoryId = inventoryId;
            Count = count;
        }
    }
}
