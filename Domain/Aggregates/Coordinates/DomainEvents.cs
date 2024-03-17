namespace Domain.Aggregates.Coordinates
{
    public class CoordinatesUpdated : DomainEvent
    {
        public Coordinates Updated { get; }

        public CoordinatesUpdated(Coordinates updated)
        {
            Updated = updated;
        }
    }

    public class CoordinatesAdded : DomainEvent
    {
        public Coordinates NewCoordinates { get; }

        public CoordinatesAdded(Coordinates newCoordinates)
        {
            NewCoordinates = newCoordinates;
        }
    }
}