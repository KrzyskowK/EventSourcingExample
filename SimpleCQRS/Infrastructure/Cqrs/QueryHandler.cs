namespace SimpleCQRS
{
    public abstract class QueryHandler<TQuery, TResult>
    {
        public abstract TResult Handle(TQuery query);
    }

    public abstract class QueryHandler<TResult>
    {
        public abstract TResult Handle();
    }
}
