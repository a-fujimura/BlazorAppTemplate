using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using BlazorApp.Shared;

namespace BlazorApp.Controllers
{

	[ApiController]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IWebHostEnvironment environment;

		public WeatherForecastController(IWebHostEnvironment environment)
		{
			this.environment = environment;
		}

		[Route("api/getweatherForecast")]
		public async Task<IActionResult> GetWeatherForecast()
		{
			WeatherForecast[] rslt;
			try
			{
				// Simulate asynchronous loading to demonstrate a loading indicator
				await Task.Delay(500);

				var startDate = DateOnly.FromDateTime(DateTime.Now);
				var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
				rslt = Enumerable.Range(1, 5).Select(index => new WeatherForecast
				{
					Date = startDate.AddDays(index),
					TemperatureC = Random.Shared.Next(-20, 55),
					Summary = summaries[Random.Shared.Next(summaries.Length)]
				}).ToArray();

				return Content(JsonSerializer.Serialize(rslt), "application/json", Encoding.UTF8);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

		}
	}
}
