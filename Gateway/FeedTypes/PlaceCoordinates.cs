using System.Text.Json.Serialization;

namespace Gateway.FeedTypes
{
    public sealed class PlaceCoordinates
    {
        public string Name { get; set; }
        public string Country { get; set; }

        [JsonPropertyName("lat")]
        public decimal Latitude { get; set; }

        [JsonPropertyName("lon")]
        public decimal Longtitude { get; set; }

        public long? Population { get; set; }
        public string Timezone { get; set; }
        public string Status { get; set; }
    }
}

#region Example object

// Example below

//name: "london"
//country: "GB"
//lat: 51.50853
//lon: -0.12574
//population: 7556900
//timezone: "Europe/London"
//status: "OK"

#endregion Example object