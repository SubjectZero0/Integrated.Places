using Common.Utils;
using Domain;

namespace Application.MessageBus
{
    public interface IEventsHub
    {
        Task PublishDomainEvent(NotifiableResponse<DomainEvent[]> domainEvents);
    }
}