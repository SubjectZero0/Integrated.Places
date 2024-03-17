namespace Domain
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; }

        protected AggregateRoot()
        {
            Id = Guid.NewGuid();
        }
    }
}