
using System;
namespace SimpleCQRS
{
    public class CreateInventoryCommand : Command
    {
        public readonly Guid InventoryId;
        public readonly string Name;

        public CreateInventoryCommand(Guid inventoryId, string name)
        {
            InventoryId = inventoryId;
            Name = name;
        }
    }
}
