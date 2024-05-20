using Application.Extensions;
using DataAccess.Extensions;
using Domain.Services.Extensions;
using FluentValidation;
using Grpc.Presentation.Interceptors;
using Grpc.Presentation.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(option =>
    option.ListenLocalhost(5236, o => o.Protocols = HttpProtocols.Http2));

builder.Services.AddDataAccess(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
builder.Services.AddServices();
builder.Services.AddDomainServices();
builder.Services.AddGrpc(
    options =>
    {
        options.Interceptors.Add<ExceptionInterceptor>();
        options.Interceptors.Add<LoggingInterceptor>();
        options.Interceptors.Add<ValidationInterceptor>();
    });

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddMigrations(builder.Configuration.GetConnectionString("PostgresConnection"));
builder.Services.AddGrpcReflection();

var app = builder.Build();


app.MapGrpcService<GrpcOrderItemService>();
app.MapGrpcService<GrpcProductService>();
app.MapGrpcService<GrpcOrderService>();

app.MapGrpcReflectionService();

app.DoMigrations();

app.Run();
