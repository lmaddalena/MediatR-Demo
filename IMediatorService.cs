using MediatR;

namespace MediatR_Demo
{
    public interface IMediatorService
    {
        void Dispatch(INotification domainEvent); 
    }
}