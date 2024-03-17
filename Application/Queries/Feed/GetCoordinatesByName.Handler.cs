using Gateway.Clients;
using Gateway.Utils;
using Gateway.FeedTypes;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using static Common.Constants;

namespace Application.Queries.Feed
{
    internal sealed class GetCoordinatesByNameHandler : IRequestHandler<GetCoordinatesByName, NotifiableResponse<PlaceCoordinates>>
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

        async Task<NotifiableResponse<PlaceCoordinates>> IRequestHandler<GetCoordinatesByName, NotifiableResponse<PlaceCoordinates>>.Handle(GetCoordinatesByName query, CancellationToken cancellationToken)
        {
            var response = await _placesClient.GetCoordinates(query.Name, query.Language, query.Country);

            var placeCoordinates = JsonSerializer.Deserialize<PlaceCoordinates>(response, _serializerOptions);

            if (placeCoordinates is null || placeCoordinates.Status != FeedStatusCode.Success)
            {
                throw new Exception($"Place was not Found. Name: {query.Name}, Country: {query.Country}, Response Status Code: {placeCoordinates?.Status}");
            }

            return new NotifiableResponse<PlaceCoordinates>(placeCoordinates);
        }
    }
}