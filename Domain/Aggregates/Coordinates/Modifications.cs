using Common;

namespace Domain.Aggregates.Coordinates
{
    public sealed class Modifications
    {
        public sealed class AddCoordinatesModification
        {
            public Coordinates NewCoordinates { get; private set; }
            public IReadOnlyCollection<DomainEvent> DomainEvents { get; private set; }

            public AddCoordinatesModification(Coordinates newCoordinates, DomainEvent[]? domainEvents = null)
            {
                NewCoordinates = newCoordinates;
                DomainEvents = domainEvents ?? ArrayEmpty<DomainEvent>.Instance;
            }
        }

        public sealed class UpdateCoordinatesModification
        {
            public Coordinates UpdatedCoordinates { get; private set; }
            public IReadOnlyCollection<DomainEvent> DomainEvents { get; private set; }

            public UpdateCoordinatesModification(Coordinates updatedCoordinates, DomainEvent[]? domainEvents = null)
            {
                UpdatedCoordinates = updatedCoordinates;
                DomainEvents = domainEvents ?? ArrayEmpty<DomainEvent>.Instance;
            }
        }
    }
}