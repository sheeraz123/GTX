using User.Api.Extensions;
using Common.Miscellaneous.Middleware.HeaderMiddleware;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApiServiceRegistration(builder.Environment, builder.Configuration, builder.Configuration, builder.Host);

var app = builder.Build();
app.Map("/APIStatus", async context =>
{
    await context.Response.WriteAsync("User API");
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.HeadersValidationMiddleware();

app.MapControllers();

app.Run();
