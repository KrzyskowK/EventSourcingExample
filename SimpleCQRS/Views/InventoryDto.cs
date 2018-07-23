using System;

namespace SimpleCQRS
{
    public class InventoryDto
    {
        public Guid Id;
        public string Name;

        public InventoryDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
