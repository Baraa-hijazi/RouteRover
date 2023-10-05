using Microsoft.Extensions.Options;

namespace RouteRover.Options;

public class GoogleMapsOptions : IOptions<GoogleMapsOptions>
{
    public const string GoogleMaps = "Google.Maps";

    public string Uri { get; set; } = null!;

    public string Key { get; set; } = null!;

    public GoogleMapsOptions Value => this;
}