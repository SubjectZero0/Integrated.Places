using Application.MessageBus;
using Common.Utils;
using Domain;
using NServiceBus;

namespace Infrastructure.MessageBus
{
    internal class EventsHub : IEventsHub
    {
        private readonly IMessageSession _session;

        public EventsHub(IMessageSession session)
        {
            _session = session;
        }

        public async Task PublishDomainEvent(NotifiableResponse<DomainEvent[]> domainEvents)
        {
            foreach (var domainEvent in domainEvents.Value)
            {
                try
                {
                    await _session.Publish(domainEvent);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}