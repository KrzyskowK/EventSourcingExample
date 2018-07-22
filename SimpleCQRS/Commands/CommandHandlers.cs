using System;

namespace SimpleCQRS
{
    public class InventoryCommandHandlers
    {
        private readonly IEventStore _store;

        public InventoryCommandHandlers(IEventStore store)
        {
            _store = store;
        }

        public void Handle(CreateInventoryItemCommand message)
        {
            var item = new InventoryItem(message.InventoryItemId, message.Name);
            _store.Save(item);
        }

        public void Handle(DeactivateInventoryItemCommand message)
        {
            var item = _store.GetById<InventoryItem>(message.InventoryItemId);
            item.Deactivate();
            _store.Save(item);
        }

        public void Handle(RemoveItemsFromInventoryCommand message)
        {
            var item = _store.GetById<InventoryItem>(message.InventoryItemId);
            item.Remove(message.Count);
            _store.Save(item);
        }

        public void Handle(CheckInItemsToInventoryCommand message)
        {
            var item = _store.GetById<InventoryItem>(message.InventoryItemId);
            item.CheckIn(message.Count);
            _store.Save(item);
        }

        public void Handle(RenameInventoryItemCommand message)
        {
            var item = _store.GetById<InventoryItem>(message.InventoryItemId);
            item.ChangeName(message.NewName);
            _store.Save(item);
        }
    }
}
