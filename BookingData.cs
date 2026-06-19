using System.Text.Json;
namespace BookingApp;

public class BookingData
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = "";
    public string Room { get; set; } = "";
    public string Description { get; set; } = "";
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; } 

    public static List<BookingData>? LoadFromFile()
    {
        string filePath = "bookings.json";
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<BookingData>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}