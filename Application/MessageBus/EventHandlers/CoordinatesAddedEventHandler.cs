using Domain.Aggregates.Coordinates;
using Microsoft.Extensions.Logging;

namespace Application.MessageBus.EventHandlers
{
    internal class CoordinatesAddedEventHandler : IHandleMessages<CoordinatesAdded>
    {
        public Task Handle(CoordinatesAdded message, IMessageHandlerContext context)
        {
            Console.WriteLine(message.NewCoordinates.Name);
            return Task.CompletedTask;
        }
    }
}