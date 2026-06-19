namespace BookingApp;


public class BookingManager
{
    private readonly List<Booking> _bookings = [];

    public BookingManager()
    {
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
        throw new NotImplementedException();
    }

    private void SaveToFile()
    {
        throw new NotImplementedException();
    }
}