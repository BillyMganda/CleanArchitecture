using MediatR;

namespace CleanArchitecture.Application
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
