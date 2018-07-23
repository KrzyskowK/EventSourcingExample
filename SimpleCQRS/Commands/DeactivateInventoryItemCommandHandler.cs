namespace SimpleCQRS
{
    public class DeactivateInventoryItemCommandHandler : CommandHandler<DeactivateInventoryItemCommand>
    {
        private readonly IEventStore _store;

        public DeactivateInventoryItemCommandHandler(IEventStore store)
        {
            _store = store;
        }

        public override void Handle(DeactivateInventoryItemCommand command)
        {
            var item = _store.GetById<InventoryItem>(command.InventoryItemId);
            item.Deactivate();
            _store.Save(item);
        }
    }
}
