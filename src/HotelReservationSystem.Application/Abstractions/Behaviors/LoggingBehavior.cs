
using MediatR;

namespace HotelReservationSystem.Application.Abstractions.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse>
        where TRequest : IBaseCommand
    {
    }
}
