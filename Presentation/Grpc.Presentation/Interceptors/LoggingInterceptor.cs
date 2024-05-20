using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Grpc.Presentation.Interceptors;

public class LoggingInterceptor : Interceptor
{
    private readonly ILogger<LoggingInterceptor> _logger;

    public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request, 
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        _logger.LogInformation($"Method {context.Method} is executing with request: {request}");
        var response = await continuation(request, context);
        _logger.LogInformation($"Method {context.Method} is executed with response: {response}");

        return response;
    }
}