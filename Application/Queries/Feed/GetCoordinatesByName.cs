using Gateway.FeedTypes;
using MediatR;

namespace Application.Queries.Feed
{
    public sealed record GetCoordinatesByName(string Name = "", string Language = "en", string Country = "") : IRequest<PlaceCoordinates> { }
}