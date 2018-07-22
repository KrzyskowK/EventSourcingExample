
using System;
namespace SimpleCQRS
{
    public class RemoveItemsFromInventoryCommand : Command
    {
        public Guid InventoryItemId;
        public readonly int Count;

        public RemoveItemsFromInventoryCommand(Guid inventoryItemId, int count)
        {
            InventoryItemId = inventoryItemId;
            Count = count;
        }
    }
}
