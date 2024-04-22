namespace FlightDataExtractor.App;

internal class Program
{
    public static void Main()
    {
        string filepath;

        do
        {
            Console.WriteLine("Please enter the path to the PDF file from which to extract data:");
            filepath = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrEmpty(filepath))
            {
                Console.WriteLine("Error: No file path provided. Please try again.");
                continue;
            }

            if (!filepath.ToLower().EndsWith(".pdf"))
            {
                Console.WriteLine("Error: The file provided is not a PDF file. Please provide a valid PDF file.");
                continue;
            }

            if (!File.Exists(filepath))
            {
                Console.WriteLine($"Error: The file `{filepath}` does not exist.");
                continue;
            }

            break;
        } while (true);

        var extractor = new Core.Services.FlightDataExtractor();
        var flights = extractor.ExtractFlightData(filepath);

        foreach (var flight in flights) Console.WriteLine($"Flight: {flight.FlightNumber}");
    }
}