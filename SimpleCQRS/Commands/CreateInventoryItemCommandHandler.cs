namespace SimpleCQRS
{
    public class CreateInventoryItemCommandHandler : CommandHandler<CreateInventoryItemCommand>
    {
        private readonly IEventStore _store;

        public CreateInventoryItemCommandHandler(IEventStore store)
        {
            _store = store;
        }

        public override void Handle(CreateInventoryItemCommand command)
        {
            var item = InventoryItem.Create(command.InventoryItemId, command.Name);
            _store.Save(item);
        }
    }
}
