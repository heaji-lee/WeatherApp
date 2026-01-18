# Weather Console App 🌤️

A C# console application that fetches weather data from the [Visual Crossing Weather API](https://www.visualcrossing.com/weather-api) and displays it in a simple, user-friendly format.

---

## Features

- Fetch **current**, **historical**, and **forecast** weather data.
- Select specific fields to display:
  - Temperature
  - Humidity
  - Sunrise / Sunset
  - Conditions
- Limit forecast results to a user-defined number of days (up to 15).
- Clean separation of concerns using:
  - `WeatherService` for API calls
  - `WeatherHandle` for data filtering
- Handles invalid inputs and missing data gracefully.

---

## Tech Stack

- C# (.NET 10)
- Console application
- HttpClient for API requests
- Environment variables for API key management

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- A [Visual Crossing Weather API](https://www.visualcrossing.com/weather-api) key
- VS Code (optional, but recommended)

### Setup

1. Clone the repository: [GitHub Repo](https://github.com/helen-heaji-lee/Weather)

```bash
git clone https://github.com/helen-heaji-lee/Weather.git
cd WeatherApp
```
2. Set your API key as an environment variable: 

* Windows (Powershell):
```powershell
#env:VISUAL_CROSSING_API_KEY="YOUR_API_KEY_HERE"
```
* macOS / Linux: 
```bash
export VISUAL_CROSSING_API_KEY="YOUR_API_KEY_HERE"
```

3. Restore packages and build:
```
dotnet restore
dotnet build
```

4. Run the application:
```
dotnet run
```

## Usage
1. Enter the city you want to check. 
2. Select weather data type: `current`, `historical`, or `forecast`.
3. Choose a weather field to display (`temperature`, `humidity`, `sunrise`, `sunset`, `conditions`, etc.).
4. If `historical`, provide start and optional end dates. 
5. If `forecase`, provide the number of days (up to 15). 
6. View the results in your terminal!

## Notes
* Forecasts are limited to 15 days maximum by the API.

## Future Enhancements
* Allow User to go back to the options.
* Additional Weather Fields - Add wind speed, precipitation, UV index, etc. 
* Colour-Coded Output - Highlight extremes or key fields in console output. 
* Better Date Input - Allow shortcuts like "today", "tomorrow", or "last week".
