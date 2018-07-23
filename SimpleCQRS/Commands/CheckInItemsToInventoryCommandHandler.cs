namespace SimpleCQRS
{
    public class CheckInItemsToInventoryCommandHandler : CommandHandler<CheckInItemsToInventoryCommand>
    {
        private readonly IEventStore _store;

        public CheckInItemsToInventoryCommandHandler(IEventStore store)
        {
            _store = store;
        }

        public override void Handle(CheckInItemsToInventoryCommand command)
        {
            var item = _store.GetById<InventoryItem>(command.InventoryItemId);
            item.CheckIn(command.Count);
            _store.Save(item);
        }
    }
}
