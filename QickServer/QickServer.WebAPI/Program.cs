using QickServer.Application;
using QickServer.Infrastructure;
using QickServer.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

builder.Services.AddHttpContextAccessor();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<MyExceptionHandler>().AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();
