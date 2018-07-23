
using System;
namespace SimpleCQRS
{
    public class DeactivateInventoryCommand : Command
    {
        public readonly Guid InventoryId;

        public DeactivateInventoryCommand(Guid inventoryId)
        {
            InventoryId = inventoryId;
        }
    }
}
