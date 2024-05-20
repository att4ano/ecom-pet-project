using FluentValidation;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Grpc.Presentation.Interceptors;

public class ValidationInterceptor : Interceptor
{
    private readonly IServiceProvider _provider;

    public ValidationInterceptor(IServiceProvider provider)
    {
        _provider = provider;
    }
    
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request, 
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        var validator = _provider.GetService<IValidator<TRequest>>();
        await validator.ValidateAndThrowAsync(request);

        return await continuation(request, context);
    }
}