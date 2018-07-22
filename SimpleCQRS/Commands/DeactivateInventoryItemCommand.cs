
using System;
namespace SimpleCQRS
{
    public class DeactivateInventoryItemCommand : Command
    {
        public readonly Guid InventoryItemId;

        public DeactivateInventoryItemCommand(Guid inventoryItemId)
        {
            InventoryItemId = inventoryItemId;
        }
    }
}
