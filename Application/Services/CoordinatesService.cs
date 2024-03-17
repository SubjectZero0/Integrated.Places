using Application.Queries.Feed;
using Common.Utils;
using Common;
using Domain;
using Domain.Aggregates.Coordinates;
using Microsoft.Extensions.Logging;
using Application.MessageBus;

namespace Application.Services
{
    public interface ICoordinatesService
    {
        Task TryAddNewPlaceCoordinates(GetCoordinatesByName query);
    }

    internal sealed class CoordinatesService : ICoordinatesService
    {
        private readonly IFeedService _feedService;
        private readonly IEventsHub _eventsBus;
        private readonly ILogger<CoordinatesService> _logger;

        public CoordinatesService(IFeedService feedService, ILogger<CoordinatesService> logger, IEventsHub eventsBus)
        {
            _feedService = feedService;
            _logger = logger;
            _eventsBus = eventsBus;
        }

        public async Task TryAddNewPlaceCoordinates(GetCoordinatesByName query)
        {
            var placeCoordinates = await _feedService.GetPlaceCoordinates(query);

            if (placeCoordinates is null)
            {
                _logger.LogWarning("Method {methodName}, New Place could not be created as it was null. Query for Name: {name}, Language: {language}, Country: {country}", nameof(TryAddNewPlaceCoordinates), query.Name, query.Language, query.Country);
                return;
            }

            // TODO: search in cache and/or in db when infra is ready

            var newPlaceCoordinates = Coordinates.CreateNew(
                name: placeCoordinates.Name,
                longitude: placeCoordinates.Longtitude,
                latitude: placeCoordinates.Latitude,
                country: placeCoordinates.Country);

            var domainEvents = new NotifiableResponse<DomainEvent[]>(newPlaceCoordinates.DomainEvents.ToArray());

            await _eventsBus.PublishDomainEvent(domainEvents); //TODO: find a better way to publish domain events

            // TODO: Complete when db ready
        }
    }
}