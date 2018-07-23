namespace SimpleCQRS
{
    public class InventoryItemDetailsView : 
        EventHandler<InventoryItem.Events.Created>, 
        EventHandler<InventoryItem.Events.Deactivated>, 
        EventHandler<InventoryItem.Events.Renamed>, 
        EventHandler<InventoryItem.Events.RemovedFromInventory>, 
        EventHandler<InventoryItem.Events.CheckedInToInventory>
    {
        public void Handle(InventoryItem.Events.Created @event)
        {
            BullShitDatabase.details.Add(@event.Id, new InventoryItemDetailsDto(@event.Id, @event.Name, 0,0));
        }

        public void Handle(InventoryItem.Events.Renamed @event)
        {
            var view = BullShitDatabase.details[@event.AggregateId];
            view.Name = @event.NewName;
            view.Version = @event.Version;
        }

        public void Handle(InventoryItem.Events.RemovedFromInventory @event)
        {
            var view = BullShitDatabase.details[@event.AggregateId];
            view.CurrentCount -= @event.Count;
            view.Version = @event.Version;
        }

        public void Handle(InventoryItem.Events.CheckedInToInventory @event)
        {
            var view = BullShitDatabase.details[@event.AggregateId];
            view.CurrentCount += @event.Count;
            view.Version = @event.Version;
        }

        public void Handle(InventoryItem.Events.Deactivated @event)
        {
            BullShitDatabase.details.Remove(@event.AggregateId);
        }
    }
}
