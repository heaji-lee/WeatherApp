using System.Text.Json;
using var httpClient = new HttpClient();

var apiKey = Environment.GetEnvironmentVariable("VISUAL_CROSSING_API_KEY");

if (string.IsNullOrEmpty(apiKey)) {
  Console.WriteLine("API key not found.");
  return;
}

var weatherService = new WeatherService(httpClient, apiKey);

Console.WriteLine("Weather Console App 🌤️");

var city = ConsoleInput.ReadRequired("Enter a city: ");
var startDate = string.Empty;
var endDate = string.Empty;
var field = string.Empty;
var today = DateTime.Now.ToString("yyyy-MM-dd");

WeatherResponse? response = null;

string weatherDataType;
string weatherField;

while (true) {
  weatherDataType = ConsoleInput.ReadRequired(
    "What weather data do you want? (historical, current, forecast)"
  ).ToLower();

  if (weatherDataType == "historical" ||
      weatherDataType == "current" ||
      weatherDataType == "forecast") {
    break;
  }
  Console.WriteLine("Invalid weather data type. Please enter historical, current, or forecast.");
}

while (true) {
  weatherField = ConsoleInput.ReadRequired(
    "What weather field do you want? (humidity, conditions, min temp, max temp, sunrise, sunset.)"
  ).ToLower().Replace(" ", "");

  if (weatherField == "humidity" ||
      weatherField == "conditions" ||
      weatherField == "mintemp" ||
      weatherField == "maxtemp" ||
      weatherField == "sunrise" ||
      weatherField == "sunset") {
    break;
  }
  Console.WriteLine("Invalid weather field. Please enter humidity, conditions, min temp, max temp, sunrise, or sunset.");
}

if (weatherDataType.ToLower() == "current") {
  response = await weatherService.GetWeatherAsync(city, today, null);
} else if (weatherDataType.ToLower() == "forecast") {
  var days = ConsoleInput.ReadRequired(
    "Enter number of days for forecast (up to 15): "
  );

  if (!int.TryParse(days, out int numDays) || numDays < 1 || numDays > 15) {
    Console.WriteLine("Invalid number of days. Please enter a number between 1 and 15.");
    return;
  }

  endDate = DateTime.Now.AddDays(numDays).ToString("yyyy-MM-dd");
  response = await weatherService.GetWeatherAsync(city, today, endDate);
} else if (weatherDataType.ToLower() == "historical") {
  startDate = ConsoleInput.ReadRequired("Enter start date (YYYY-MM-DD):");

  Console.WriteLine("(Optional) Enter end date (YYYY-MM-DD):");
  endDate = Console.ReadLine();

  response = await weatherService.GetWeatherAsync(city, startDate, endDate);
}

try {
  if (response == null) {
    Console.WriteLine("No weather data retrieved.");
    return;
  }

  if (response.Days == null || response.Days.Count == 0) {
    Console.WriteLine("No data found for the specified field.");
    return;
  }

  foreach (var day in response.Days) {
    var value = WeatherField.GetWeatherFieldValue(day, weatherField);
    Console.WriteLine($"{day.Datetime}: {value}");
    Console.WriteLine("-------------------------");
  }
  Console.WriteLine("Would you like to see more data? (y/n)");
  var moreData = Console.ReadLine();
  if (moreData?.ToLower() == "y") {
    Console.WriteLine("Would you like to see another field? (y/n)");
    var anotherField = Console.ReadLine();
    if (anotherField?.ToLower() == "y") {
      weatherField = ConsoleInput.ReadRequired(
        "What weather field do you want? (humidity, conditions, min temp, max temp, sunrise, sunset.)"
      ).ToLower().Replace(" ", "");
      foreach (var day in response.Days) {
        var value = WeatherField.GetWeatherFieldValue(day, weatherField);
        Console.WriteLine($"{day.Datetime}: {value}");
        Console.WriteLine("-------------------------");
      }
    }
  }
}
catch (Exception ex) {
  Console.WriteLine($"Error: {ex.Message}");
}