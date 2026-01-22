public static class ConsoleInput {
  public static string ReadRequired(string prompt) {
    while (true) {
      Console.WriteLine(prompt);
      var input = Console.ReadLine();

      if (!string.IsNullOrWhiteSpace(input))
        return input;

      Console.WriteLine("Input cannot be empty. Please try again.");
    }
  }
}