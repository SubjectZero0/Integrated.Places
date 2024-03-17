using static Domain.Aggregates.Coordinates.Modifications;

namespace Domain.Aggregates.Coordinates
{
    public sealed class Coordinates : AggregateRoot
    {
        public string Name { get; private set; }
        public decimal Longtitude { get; private set; }
        public decimal Latitude { get; private set; }
        public string Country { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Coordinates() : base()
        {
            Name = string.Empty;
            Country = string.Empty;
        }

        private Coordinates(string name, decimal longtitude, decimal latitude, string country) : base()
        {
            Name = name;
            Longtitude = longtitude;
            Latitude = latitude;
            Country = country;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static AddCoordinatesModification CreateNew(string name, decimal longitude, decimal latitude, string country)
        {
            var coordinates = new Coordinates(name, longitude, latitude, country);
            var domainEvent = new CoordinatesAdded(coordinates);

            return new AddCoordinatesModification(coordinates, [domainEvent]);
        }

        public UpdateCoordinatesModification UpdateName(string name)
        {
            var now = DateTime.UtcNow;

            Name = name;
            UpdatedAt = now;

            var domainEvent = new CoordinatesUpdated(updated: this);

            return new UpdateCoordinatesModification(this, [domainEvent]);
        }

        public UpdateCoordinatesModification UpdateCoordinatesValue(decimal longitude, decimal latitude)
        {
            var now = DateTime.UtcNow;

            Longtitude = longitude;
            Latitude = latitude;
            UpdatedAt = now;

            var domainEvent = new CoordinatesUpdated(updated: this);

            return new UpdateCoordinatesModification(this, [domainEvent]);
        }
    }
}