using Application.Queries.Feed;
using Gateway.FeedTypes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public interface IFeedService
    {
        Task<PlaceCoordinates?> GetPlaceCoordinates(GetCoordinatesByName query);
    }

    internal sealed class FeedService : IFeedService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FeedService> _logger;

        public FeedService(IMediator mediator, ILogger<FeedService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<PlaceCoordinates?> GetPlaceCoordinates(GetCoordinatesByName query)
        {
            var placeCoordinates = await _mediator.Send(query);

            return placeCoordinates.Value;
        }
    }
}