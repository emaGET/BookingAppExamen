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
        string startTime, string endTime, string description) // this parsing i can do like in the UniRegister
    {
        // throw new NotImplementedException();
        
        // int age = int.Parse(Console.ReadLine());

        DateOnly parsDate = DateOnly.Parse(date);
        TimeOnly parsStart = TimeOnly.Parse(startTime);
        TimeOnly parsEnd = TimeOnly.Parse(endTime);

        foreach (var b in _bookings)
        {
            if (b.Room == room && b.Date == parsDate)
            {
                if (parsStart < b.Start && parsEnd > b.End)
                {
                    return "The room is already taken!";
                }
            }
        }

        int newId = _bookings.Count == 0 ? 1 : _bookings.Max(b => b.Id) + 1;

        var booking = new Booking(newId, customerName, room, parsDate, parsStart, parsEnd, description);
        
        //  groceries.Add(input);
        _bookings.Add(booking);

        SaveToFile();
        return "Boooking added!";

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