using HttpClientInWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<IWeatherForecastService,WeatherForecastService>(c =>
{
    c.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
