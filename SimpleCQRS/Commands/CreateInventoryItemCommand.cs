
using System;
namespace SimpleCQRS
{
    public class CreateInventoryItemCommand : Command
    {
        public readonly Guid InventoryItemId;
        public readonly string Name;

        public CreateInventoryItemCommand(Guid inventoryItemId, string name)
        {
            InventoryItemId = inventoryItemId;
            Name = name;
        }
    }
}
