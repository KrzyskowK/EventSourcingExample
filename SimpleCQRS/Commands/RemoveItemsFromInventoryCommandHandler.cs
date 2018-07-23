namespace SimpleCQRS
{
    public class RemoveItemsFromInventoryCommandHandler : CommandHandler<RemoveItemsFromInventoryCommand>
    {
        private readonly IEventStore _store;

        public RemoveItemsFromInventoryCommandHandler(IEventStore store)
        {
            _store = store;
        }

        public override void Handle(RemoveItemsFromInventoryCommand command)
        {
            var item = _store.GetById<InventoryItem>(command.InventoryItemId);
            item.Remove(command.Count);
            _store.Save(item);
        }
    }
}
