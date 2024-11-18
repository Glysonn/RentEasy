using MediatR;
using RentEasy.Domain.Abstractions;

namespace RentEasy.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
