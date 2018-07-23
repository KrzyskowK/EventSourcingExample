namespace SimpleCQRS
{
    public class RenameInventoryItemCommandHandler : CommandHandler<RenameInventoryItemCommand>
    {
        private readonly IEventStore _store;

        public RenameInventoryItemCommandHandler(IEventStore store)
        {
            _store = store;
        }

        public override void Handle(RenameInventoryItemCommand command)
        {
            var item = _store.GetById<InventoryItem>(command.InventoryItemId);
            item.ChangeName(command.NewName);
            _store.Save(item);
        }
    }
}
