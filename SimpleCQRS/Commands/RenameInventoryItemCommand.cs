
using System;
namespace SimpleCQRS
{
    public class RenameInventoryItemCommand : Command
    {
        public readonly Guid InventoryItemId;
        public readonly string NewName;

        public RenameInventoryItemCommand(Guid inventoryItemId, string newName)
        {
            InventoryItemId = inventoryItemId;
            NewName = newName;
        }
    }
}
