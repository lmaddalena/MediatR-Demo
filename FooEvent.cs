using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatR_Demo
{
    public class FooEvent : INotification
    {
        public int FooId { get; private set; }

        public FooEvent(int fooId)
        {
            FooId = fooId;
        }


    }
}