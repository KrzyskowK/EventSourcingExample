namespace SimpleCQRS
{
    public class RenameInventoryCommandHandler : CommandHandler<RenameInventoryCommand>
    {
        private readonly IEventStore _store;

        public RenameInventoryCommandHandler(IEventStore store)
        {
            _store = store;
        }

        public override void Handle(RenameInventoryCommand command)
        {
            var item = _store.GetById<Inventory>(command.InventoryId);
            item.ChangeName(command.NewName);
            _store.Save(item);
        }
    }
}
