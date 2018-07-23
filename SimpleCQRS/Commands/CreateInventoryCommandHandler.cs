namespace SimpleCQRS
{
    public class CreateInventoryCommandHandler : CommandHandler<CreateInventoryCommand>
    {
        private readonly IEventStore _store;

        public CreateInventoryCommandHandler(IEventStore store)
        {
            _store = store;
        }

        public override void Handle(CreateInventoryCommand command)
        {
            var item = Inventory.Create(command.InventoryId, command.Name);
            _store.Save(item);
        }
    }
}
