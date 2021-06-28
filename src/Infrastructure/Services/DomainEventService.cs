using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Application.Common.Models;
using vet_clinic.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace vet_clinic.Infrastructure.Services
{
    public class DomainEventService
    {
        //private readonly ILogger<DomainEventService> _logger;
        //private readonly IPublisher _mediator;

        //public DomainEventService(ILogger<DomainEventService> logger, IPublisher mediator)
        //{
        //    _logger = logger;
        //    _mediator = mediator;
        //}

        //public async Task Publish(DomainEvent domainEvent)
        //{
        //    _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
        //    await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
        //}

        //private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        //{
        //    return (INotification)Activator.CreateInstance(
        //        typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
        //}
    }
}