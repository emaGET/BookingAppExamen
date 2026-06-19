namespace BookingApp;


public class BookingManager
{
    private readonly List<Booking> _bookings = [];

    public BookingManager()
    {
        LoadFromFile();
    }

    public List<Booking> GetAll() => _bookings;

    public List<int> GetAllIds()
    {
        throw new NotImplementedException();
    }

    public string AddBooking(string customerName, string room, string date,
        string startTime, string endTime, string description)
    {
        throw new NotImplementedException();
    }

    public bool DeleteBooking(int id)
    {
        throw new NotImplementedException();
    }

    public string EditBooking(int id, string customerName, string room, string date,
        string startTime, string endTime, string description)
    {
        throw new NotImplementedException();
    }

    private void LoadFromFile()
    {
        // throw new NotImplementedException();
        var data = BookingData.LoadFromFile();
        if (data == null) return;

        foreach (var d in data)
        {
            var booking = new Booking(d.Id, d.CustomerName, d.Room, d.Date, d.StartTime, d.EndTime, d.Description);
            _bookings.Add(booking);
        }
    }

    private void SaveToFile()
    {
        throw new NotImplementedException();
    }
    
}