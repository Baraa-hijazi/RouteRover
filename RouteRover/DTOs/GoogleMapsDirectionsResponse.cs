namespace RouteRover.DTOs;

public class GoogleMapsDirectionsResponse
{
    public List<Route> Routes { get; set; } = new();
}

public class Route
{
    public OverviewPolyline OverviewPolyline { get; set; } = null!;
    public List<Leg> Legs { get; set; }
}

public class OverviewPolyline
{
    public string Points { get; set; } = null!;
}

public class Leg
{
    public Duration Duration { get; set; } = null!;
    public Distance Distance { get; set; } = null!;
}

public class Duration
{
    public string Text { get; set; } = null!;
    public int Value { get; set; }
}

public class Distance
{
    public string Text { get; set; } = null!;
    public int Value { get; set; }
}

public class LatLng
{
    public double OriginLatitude { get; set; }
    public double OriginLongitude { get; set; }
    public double DestinationLatitude { get; set; }
    public double DestinationLongitude { get; set; }
}