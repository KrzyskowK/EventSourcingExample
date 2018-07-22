namespace SimpleCQRS
{
    public class InventoryListView : 
        EventHandler<InventoryItem.Events.Created>, 
        EventHandler<InventoryItem.Events.Renamed>, 
        EventHandler<InventoryItem.Events.Deactivated>
    {
        public void Handle(InventoryItem.Events.Created message)
        {
            BullShitDatabase.list.Add(new InventoryItemListDto(message.Id, message.Name));
        }

        public void Handle(InventoryItem.Events.Renamed message)
        {
            var item = BullShitDatabase.list.Find(x => x.Id == message.Id);
            item.Name = message.NewName;
        }

        public void Handle(InventoryItem.Events.Deactivated message)
        {
            BullShitDatabase.list.RemoveAll(x => x.Id == message.Id);
        }
    }
}
