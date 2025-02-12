using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using QickServer.Application;
using QickServer.Infrastructure;
using QickServer.Infrastructure.Hubs;
using QickServer.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(1);
        options.PermitLimit = 100;
        options.QueueLimit = 100;
        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
    });
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<MyExceptionHandler>().AddProblemDetails();

builder.Services.AddSignalR();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/check", () => "Ok");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapPost("register", async (IMediator mediator, HttpContext httpContext, RegisterCommand request, CancellationToken cancellationToken) =>
//{
//    var response = await mediator.Send(request, cancellationToken);
//    httpContext.Response.StatusCode = response.StatusCode;
//    return response;
//});

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowCredentials().AllowAnyMethod().SetIsOriginAllowed(x => true));

app.UseAuthorization();

app.MapControllers().RequireRateLimiting("fixed");

app.UseExceptionHandler();

app.MapHub<CreateRoomHub>("/create-room");

app.MapHealthChecks("/health-check", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
    }
});

app.Run();
