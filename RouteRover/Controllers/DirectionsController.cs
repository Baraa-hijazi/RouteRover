using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RouteRover.DTOs;
using RouteRover.Options;

namespace RouteRover.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectionsController : ControllerBase
{
    private readonly GoogleMapsOptions _options;
    private readonly HttpClient _httpClient;

    public DirectionsController(HttpClient httpClient, IOptions<GoogleMapsOptions> options)
    {
        _options = options.Value;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_options.Uri);
    }

    [HttpGet]
    public async Task<IActionResult> GetDirections([FromQuery] LatLng latLng)
    {
        try
        {
            var apiUrl = $"directions/json?origin={latLng.OriginLatitude},{latLng.OriginLongitude}" +
                         $"&destination={latLng.DestinationLatitude},{latLng.DestinationLongitude}" +
                         $"&key={_options.Key}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode) return BadRequest("Unable to retrieve directions.");

            var responseData = await response.Content.ReadFromJsonAsync<GoogleMapsDirectionsResponse>();

            if (!(responseData?.Routes.Count > 0)) return BadRequest("Unable to retrieve directions.");

            var route = responseData.Routes[0];
            var duration = route.Legs[0].Duration;
            var distance = route.Legs[0].Distance;

            return Ok(new
            {
                Origin = new { Latitude = latLng.OriginLatitude, Longitude = latLng.OriginLongitude },
                Destination = new { Latitude = latLng.DestinationLatitude, Longitude = latLng.DestinationLongitude },
                Duration = new { duration.Text, duration.Value },
                Distance = new { distance.Text, distance.Value }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}