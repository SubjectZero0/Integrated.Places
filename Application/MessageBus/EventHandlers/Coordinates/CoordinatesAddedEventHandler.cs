using Domain.Aggregates.Coordinates;
using Microsoft.Extensions.Logging;

namespace Application.MessageBus.EventHandlers.Coordinates
{
    internal class CoordinatesAddedEventHandler : IHandleMessages<CoordinatesAdded>
    {
        public Task Handle(CoordinatesAdded message, IMessageHandlerContext context)
        {
            //TODO: add handler specifics when ready
            try
            {
                Console.WriteLine(message.NewCoordinates.Name);
            }
            catch
            {
                Console.WriteLine("message empty");
            }
            return Task.CompletedTask;
        }
    }
}