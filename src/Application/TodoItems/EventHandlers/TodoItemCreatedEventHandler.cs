using vet_clinic.Application.Common.Models;
using vet_clinic.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.TodoItems.EventHandlers
{
    //public class TodoItemCreatedEventHandler : INotificationHandler<DomainEventNotification<TodoItemCreatedEvent>>
    //{
    //    private readonly ILogger<TodoItemCompletedEventHandler> _logger;

    //    public TodoItemCreatedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public Task Handle(DomainEventNotification<TodoItemCreatedEvent> notification, CancellationToken cancellationToken)
    //    {
    //        var domainEvent = notification.DomainEvent;

    //        _logger.LogInformation("vet_clinic Domain Event: {DomainEvent}", domainEvent.GetType().Name);

    //        return Task.CompletedTask;
    //    }
    //}
}
