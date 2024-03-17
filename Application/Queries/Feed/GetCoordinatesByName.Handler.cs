using Gateway.Clients;
using Gateway.FeedTypes;
using MediatR;
using System.Text.Json;
using static Common.Constants;

namespace Application.Queries.Feed
{
    internal sealed class GetCoordinatesByNameHandler : IRequestHandler<GetCoordinatesByName, PlaceCoordinates>
    {
        private readonly IPlacesClient _placesClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public GetCoordinatesByNameHandler(IPlacesClient clientService)
        {
            _placesClient = clientService;
            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
        }

        async Task<PlaceCoordinates> IRequestHandler<GetCoordinatesByName, PlaceCoordinates>.Handle(GetCoordinatesByName query, CancellationToken cancellationToken)
        {
            var response = await _placesClient.GetCoordinates(query.Name, query.Language, query.Country);

            var placeCoordinates = JsonSerializer.Deserialize<PlaceCoordinates>(response, _serializerOptions);

            if (placeCoordinates is null || placeCoordinates.Status != FeedStatusCode.Success)
            {
                throw new Exception($"Place was not Found. Name: {query.Name}, Country: {query.Country}, Response Status Code: {placeCoordinates?.Status}");
            }

            return placeCoordinates;
        }
    }
}