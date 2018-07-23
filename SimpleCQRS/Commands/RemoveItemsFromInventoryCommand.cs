
using System;
namespace SimpleCQRS
{
    public class RemoveItemsFromInventoryCommand : Command
    {
        public Guid InventoryId;
        public readonly int Count;

        public RemoveItemsFromInventoryCommand(Guid inventoryId, int count)
        {
            InventoryId = inventoryId;
            Count = count;
        }
    }
}
