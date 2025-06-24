using System.Net.Http.Json;
using DevHabit.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DevHabit.Api.Tests.WeatherTests;

public class WeatherForecastTests
{
    [Fact]
    public async Task GetWeatherForecast_ReturnsFiveItems()
    {
        await using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/weatherforecast");

        response.EnsureSuccessStatusCode();
        var forecasts = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();
        Assert.NotNull(forecasts);
        Assert.Equal(5, forecasts!.Length);
    }
}
