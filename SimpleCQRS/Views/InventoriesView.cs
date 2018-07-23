namespace SimpleCQRS
{
    public class InventoriesView : 
        EventHandler<Inventory.Events.Created>, 
        EventHandler<Inventory.Events.Renamed>, 
        EventHandler<Inventory.Events.Deactivated>
    {
        public void Handle(Inventory.Events.Created @event)
        {
            BullShitDatabase.list.Add(new InventoryDto(@event.Id, @event.Name));
        }

        public void Handle(Inventory.Events.Renamed @event)
        {
            var item = BullShitDatabase.list.Find(x => x.Id == @event.AggregateId);
            item.Name = @event.NewName;
        }

        public void Handle(Inventory.Events.Deactivated @event)
        {
            BullShitDatabase.list.RemoveAll(x => x.Id == @event.AggregateId);
        }
    }
}
