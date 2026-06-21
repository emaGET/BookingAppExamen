using System.Text.Json;
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

        var result = new List<int>();
        
        foreach (var b in _bookings)
        {
            result.Add(b.Id);
        }

        return result;

    }

    public string AddBooking(string customerName, string room, string date, string startTime, string endTime, string description)
    {

        DateOnly parsDate = DateOnly.Parse(date);
        TimeOnly parsStart = TimeOnly.Parse(startTime);
        TimeOnly parsEnd = TimeOnly.Parse(endTime);

        foreach (var b in _bookings)
        {
            
            if (b.Room == room && b.Date == parsDate)
            {
                
                if (parsStart < b.End && parsEnd > b.Start)
                {
                    return "\nRommet er allerede reservert!\n";
                }
                
            }
            
        }

        int newId = _bookings.Count == 0 ? 1 : _bookings.Max(b => b.Id) + 1;

        var booking = new Booking(newId, customerName, room, parsDate, parsStart, parsEnd, description);
        
        _bookings.Add(booking);

        SaveToFile();
        return "\nBestillingen er lagt til!\n";

    }

    public bool DeleteBooking(int id)
    {

        Booking found = _bookings.Find(b => b.Id == id);

        if (found != null)
        {
            _bookings.Remove(found);
            SaveToFile();
            return true;
        }
        
        else
        {
            return false;
        }
        
    }

    public string EditBooking(int id, string customerName, string room, string date,
        string startTime, string endTime, string description)
    {

        int index = _bookings.FindIndex(b => b.Id == id);

        if (index == -1)
        {
            return "\nBestillingen ble ikke funnet!\n";
        }


        if (!DateOnly.TryParse(date, out DateOnly parsedDate))
        {
            return "\nUgyldig dato!\n";
        }
        
        if (!TimeOnly.TryParse(startTime, out TimeOnly parsedStart))
        {
            return "\nUgyldig starttid!\n";
        }

        if (!TimeOnly.TryParse(endTime, out TimeOnly parsedEnd))
        {
            return "\nUgyldig sluttid!\n";
        }

        if (parsedStart >= parsedEnd)
        {
            return "\nStarttid må være før sluttid!\n";
        }

        foreach (var b in _bookings)
        {
            if (b.Id != id && b.Room == room && b.Date == parsedDate)
            {
                if (parsedStart < b.End && parsedEnd > b.Start)
                {
                    return "\nBeklager! Rommet er allerede reservert!\n";
                }
            }
        }

        var updatedBooking = new Booking( id,  customerName,  room,  parsedDate,  parsedStart,  parsedEnd,  description);

        _bookings[index] = updatedBooking;

        SaveToFile();
        
        return "\nBestillingen er oppdatert!\n";
        
    }

    private void LoadFromFile()
    {

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
        
        var dataList = new List<BookingData>();
        foreach (var b in _bookings)
        {
            dataList.Add(new BookingData
            {
                Id = b.Id, CustomerName = b.CustomerName, Room = b.Room, Date = b.Date, StartTime = b.Start,
                EndTime = b.End, Description = b.Description
            });
            
            
        }
        
        string savedJson = JsonSerializer.Serialize(dataList);
        File.WriteAllText("bookings.json", savedJson);
        
    }
    
}