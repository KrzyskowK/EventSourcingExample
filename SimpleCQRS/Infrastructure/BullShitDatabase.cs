using System;
using System.Collections.Generic;

namespace SimpleCQRS
{
    public static class BullShitDatabase
    {
        public static Dictionary<Guid, InventoryDetailsDto> details = new Dictionary<Guid,InventoryDetailsDto>();
        public static List<InventoryDto> list = new List<InventoryDto>();
    }
}
