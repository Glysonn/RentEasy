﻿using MediatR;
using Microsoft.Extensions.Logging;
using RentEasy.Application.Abstractions.Messaging;

namespace RentEasy.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing command {Command}.", name);

            var result = await next();

            _logger.LogInformation("Command {Command} processed successfully.", name);

            return result;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Command {Command} processing failed.", name);
            
            throw new InvalidOperationException($"An error occurred while processing command '{name}'.", exception);
        }
    }
}
