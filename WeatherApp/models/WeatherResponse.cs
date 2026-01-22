using System.Text.Json.Serialization;

public class WeatherResponse {
  [JsonPropertyName("days")]
  public List<Day>? Days { get; set; }
}

public class Day {
  [JsonPropertyName("datetime")]
  public string? Datetime { get; set; }

  [JsonPropertyName("tempmax")]
  public double MaxTemp { get; set; }

  [JsonPropertyName("tempmin")]
  public double MinTemp { get; set; }

  [JsonPropertyName("humidity")]
  public double Humidity { get; set; }

  [JsonPropertyName("conditions")]
  public string? Conditions { get; set; }

  [JsonPropertyName("sunrise")]
  public string? Sunrise { get; set; }

  [JsonPropertyName("sunset")]
  public string? Sunset { get; set; }
}