using Domain.Aggregates.Coordinates;

namespace Application.MessageBus.EventHandlers.Coordinates
{
    internal class CoordinatesUpdatedEventHandler : IHandleMessages<CoordinatesUpdated>
    {
        public Task Handle(CoordinatesUpdated message, IMessageHandlerContext context)
        {
            //TODO: add handler specifics when ready
            try
            {
                Console.WriteLine($"Old name changed to {message.Updated.Name}");
            }
            catch
            {
                Console.WriteLine("message empty");
            }
            return Task.CompletedTask;
        }
    }
}