using User.Api.Extensions;
using Common.Miscellaneous.Middleware.HeaderMiddleware;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true; // Enable response compression for HTTPS
    options.Providers.Add<GzipCompressionProvider>(); // Add Gzip compression
    options.Providers.Add<BrotliCompressionProvider>(); // Add Brotli compression
});


builder.Services.AddControllers()
    .AddJsonOptions(opts =>
        opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
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
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
app.HeadersValidationMiddleware();
app.UseResponseCompression();

app.MapControllers();

app.Run();
