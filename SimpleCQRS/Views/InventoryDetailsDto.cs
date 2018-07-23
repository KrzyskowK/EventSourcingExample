using System;

namespace SimpleCQRS
{
    public class InventoryDetailsDto
    {
        public Guid Id;
        public string Name;
        public int CurrentCount;
        public int Version;

        public InventoryDetailsDto(Guid id, string name, int currentCount, int version)
        {
            Id = id;
            Name = name;
            CurrentCount = currentCount;
            Version = version;
        }
    }
}
