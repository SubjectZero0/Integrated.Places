using System.Text.Json.Serialization;

namespace Domain.Aggregates.Coordinates
{
    [Serializable]
    public class CoordinatesUpdated : DomainEvent
    {
        public Coordinates Updated { get; set; }

        public CoordinatesUpdated(Coordinates updated)
        {
            Updated = updated;
        }
    }

    [Serializable]
    public class CoordinatesAdded : DomainEvent
    {
        public Coordinates NewCoordinates { get; set; }

        public CoordinatesAdded(Coordinates newCoordinates)
        {
            NewCoordinates = newCoordinates;
        }
    }
}