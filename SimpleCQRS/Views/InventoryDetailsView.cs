namespace SimpleCQRS
{
    public class InventoryDetailsView : 
        EventHandler<Inventory.Events.Created>, 
        EventHandler<Inventory.Events.Deactivated>, 
        EventHandler<Inventory.Events.Renamed>, 
        EventHandler<Inventory.Events.RemovedFromInventory>, 
        EventHandler<Inventory.Events.CheckedInToInventory>
    {
        public void Handle(Inventory.Events.Created @event)
        {
            BullShitDatabase.details.Add(@event.AggregateId, new InventoryDetailsDto(@event.AggregateId, @event.Name, 0,0));
        }

        public void Handle(Inventory.Events.Renamed @event)
        {
            var view = BullShitDatabase.details[@event.AggregateId];
            view.Name = @event.NewName;
            view.Version = @event.Version;
        }

        public void Handle(Inventory.Events.RemovedFromInventory @event)
        {
            var view = BullShitDatabase.details[@event.AggregateId];
            view.CurrentCount -= @event.Count;
            view.Version = @event.Version;
        }

        public void Handle(Inventory.Events.CheckedInToInventory @event)
        {
            var view = BullShitDatabase.details[@event.AggregateId];
            view.CurrentCount += @event.Count;
            view.Version = @event.Version;
        }

        public void Handle(Inventory.Events.Deactivated @event)
        {
            BullShitDatabase.details.Remove(@event.AggregateId);
        }
    }
}
