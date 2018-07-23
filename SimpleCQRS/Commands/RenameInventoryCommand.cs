
using System;
namespace SimpleCQRS
{
    public class RenameInventoryCommand : Command
    {
        public readonly Guid InventoryId;
        public readonly string NewName;

        public RenameInventoryCommand(Guid inventoryId, string newName)
        {
            InventoryId = inventoryId;
            NewName = newName;
        }
    }
}
