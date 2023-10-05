# RouteRover

RouteRover is a web application that integrates with the Google Maps API to provide directions based on user input.

Features:

**Directions API Integration:** The application uses the Google Maps Directions API to fetch directions based on the origin and destination coordinates provided by the user.

**Configurable API Settings:** The application allows configuration of the Google Maps API endpoint and API key through the appsettings.json file.

**Data Transfer Objects (DTOs):** The application defines various DTOs to handle the response from the Google Maps Directions API, including details about routes, legs, duration, distance, and more.

**Controllers:** The main controller, DirectionsController, handles the API requests to fetch directions. It uses the provided latitude and longitude to make a request to the Google Maps API and then returns the direction details, including the origin, destination, duration, and distance.

Key Files:

**DirectionsController.cs:** Contains the main logic for fetching directions using the Google Maps API.

**GoogleMapsDirectionsResponse.cs:** Defines the DTOs for handling the response from the Google Maps Directions API.

**GoogleMapsOptions.cs:** Contains the options for configuring the Google Maps API settings.

**Program.cs:** The main entry point of the application, where services are registered and the application is built and run.

**appsettings.json:** Configuration file for the application, including settings for logging and the Google Maps API.

**Note:** Ensure to replace ### YOUR_API_KEY ### in the appsettings.json file with your actual Google Maps API key before running the application.
