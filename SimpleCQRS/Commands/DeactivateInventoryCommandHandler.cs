namespace SimpleCQRS
{
    public class DeactivateInventoryCommandHandler : CommandHandler<DeactivateInventoryCommand>
    {
        private readonly IEventStore _store;

        public DeactivateInventoryCommandHandler(IEventStore store)
        {
            _store = store;
        }

        public override void Handle(DeactivateInventoryCommand command)
        {
            var item = _store.GetById<Inventory>(command.InventoryId);
            item.Deactivate();
            _store.Save(item);
        }
    }
}
