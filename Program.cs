using HttpClientInWebApi;

using Microsoft.Extensions.DependencyInjection;

using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<IWeatherForecastService, WeatherForecastService>()
    .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2)));

//builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection(WeatherApiOptions.WeatherApiSection));
builder.Services.AddOptions<WeatherApiOptions>()
    .Bind(builder.Configuration.GetSection(WeatherApiOptions.WeatherApiSection))
    .ValidateDataAnnotations();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
