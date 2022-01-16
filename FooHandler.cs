using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatR_Demo
{
    public class FooHandler : INotificationHandler<FooEvent>
    {
        ILogger<FooHandler> _logger;
        public FooHandler(ILogger<FooHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(FooEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Foo event id: " + notification.FooId);            

            return Task.CompletedTask;
        }        
    }
}