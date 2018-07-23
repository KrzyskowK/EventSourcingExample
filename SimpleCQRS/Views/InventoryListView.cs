namespace SimpleCQRS
{
    public class InventoryListView : 
        EventHandler<InventoryItem.Events.Created>, 
        EventHandler<InventoryItem.Events.Renamed>, 
        EventHandler<InventoryItem.Events.Deactivated>
    {
        public void Handle(InventoryItem.Events.Created @event)
        {
            BullShitDatabase.list.Add(new InventoryItemListDto(@event.Id, @event.Name));
        }

        public void Handle(InventoryItem.Events.Renamed @event)
        {
            var item = BullShitDatabase.list.Find(x => x.Id == @event.AggregateId);
            item.Name = @event.NewName;
        }

        public void Handle(InventoryItem.Events.Deactivated @event)
        {
            BullShitDatabase.list.RemoveAll(x => x.Id == @event.AggregateId);
        }
    }
}
