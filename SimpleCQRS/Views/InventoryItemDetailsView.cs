namespace SimpleCQRS
{
    public class InventoryItemDetailsView : 
        EventHandler<InventoryItem.Events.Created>, 
        EventHandler<InventoryItem.Events.Deactivated>, 
        EventHandler<InventoryItem.Events.Renamed>, 
        EventHandler<InventoryItem.Events.RemovedFromInventory>, 
        EventHandler<InventoryItem.Events.CheckedInToInventory>
    {
        public void Handle(InventoryItem.Events.Created message)
        {
            BullShitDatabase.details.Add(message.Id, new InventoryItemDetailsDto(message.Id, message.Name, 0,0));
        }

        public void Handle(InventoryItem.Events.Renamed message)
        {
            var d = BullShitDatabase.details[message.Id];
            d.Name = message.NewName;
            d.Version = message.Version;
        }

        public void Handle(InventoryItem.Events.RemovedFromInventory message)
        {
            var d = BullShitDatabase.details[message.Id];
            d.CurrentCount -= message.Count;
            d.Version = message.Version;
        }

        public void Handle(InventoryItem.Events.CheckedInToInventory message)
        {
            var d = BullShitDatabase.details[message.Id];
            d.CurrentCount += message.Count;
            d.Version = message.Version;
        }

        public void Handle(InventoryItem.Events.Deactivated message)
        {
            BullShitDatabase.details.Remove(message.Id);
        }
    }
}
