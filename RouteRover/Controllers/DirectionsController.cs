using Microsoft.AspNetCore.Mvc;

namespace RouteRover.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectionsController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DirectionsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> GetDirections(double originLat, double originLng, double destinationLat,
        double destinationLng, string apiKey)
    {
        try
        {
            using var client = _httpClientFactory.CreateClient();

            var apiUrl = $"https://maps.googleapis.com/maps/api/directions/json?origin={originLat},{originLng}&destination={destinationLat},{destinationLng}&key={apiKey}";

            // Send the HTTP request to the API
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<GoogleMapsDirectionsResponse>();
                if (responseData?.Routes.Count > 0)
                {
                    // Extract data and return it
                    var route = responseData.Routes[0];
                    var duration = route.Legs[0].Duration;
                    var distance = route.Legs[0].Distance;

                    return Ok(new
                    {
                        Origin = new { Latitude = originLat, Longitude = originLng },
                        Destination = new { Latitude = destinationLat, Longitude = destinationLng },
                        Duration = new { duration.Text, duration.Value },
                        Distance = new { distance.Text, distance.Value }
                    });
                }
            }

            return BadRequest("Unable to retrieve directions.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}