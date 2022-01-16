using MediatR;

namespace MediatR_Demo
{
    public class MediatorService : IMediatorService
    {
        private IMediator _mediator;
        public MediatorService(IMediator mediator)
        {            
            _mediator = mediator;
        }

        public void Dispatch(INotification domainEvent)
        {
            _mediator.Publish(domainEvent);
        }   
    }
}