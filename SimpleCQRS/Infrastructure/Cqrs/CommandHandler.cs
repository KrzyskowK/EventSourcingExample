namespace SimpleCQRS
{
    public abstract class CommandHandler<TCommand> where TCommand : Command
    {
        public abstract void Handle(TCommand command);
    }
}
