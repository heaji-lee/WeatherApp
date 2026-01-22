public static class WeatherField {
  public static string GetWeatherFieldValue(Day day, string field) {
    field = field.ToLower().Replace(" ", "");

    return field switch {
      "maxtemp" or "max" or "max temp" => $"{day.MaxTemp:0.0} °C",
      "mintemp" or "min" or "min temp" => $"{day.MinTemp:0.0} °C",
      "humidity" => $"{day.Humidity:0.0} %",
      "conditions" => day.Conditions ?? "N/A",
      "sunrise" => day.Sunrise ?? "N/A",
      "sunset" => day.Sunset ?? "N/A",
      _ => "Unknown field"
    };
  }
}