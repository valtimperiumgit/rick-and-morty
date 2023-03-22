using RickAndMorty.Api.Integrations;
using RickAndMorty.Api.Integrations.RickAndMorty;
using RickAndMorty.Api.Middleware;
using RickAndMorty.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRickAndMortyClient, RickAndMortyClient>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddHttpClient<IRickAndMortyClient, RickAndMortyClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("RickAndMortyApiUrl"));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();