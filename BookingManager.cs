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
        // throw new NotImplementedException();
        
        // private List<Student> students = new List<Student>();
        // foreach (Student student in students)
        // {
        //     student.PrintInfo();
        // }

        var result = new List<int>();
        
        foreach (var b in _bookings)
        {
            result.Add(b.Id);
        }

        return result;

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
                
                if (parsStart < b.End && parsEnd > b.Start)
                {
                    return "\nRommet er allerede reservert!\n";
                }
                
            }
            
        }

        int newId = _bookings.Count == 0 ? 1 : _bookings.Max(b => b.Id) + 1;

        var booking = new Booking(newId, customerName, room, parsDate, parsStart, parsEnd, description);
        
        //  groceries.Add(input);
        _bookings.Add(booking);

        SaveToFile();
        return "\nBestillingen er lagt til!\n";

    }

    public bool DeleteBooking(int id)
    {
        // throw new NotImplementedException();
        
        // foreach (Student student in students)
        // {
        // student.PrintInfo();
                
        // if (student.IsRepeating())
        // {
        //     Console.WriteLine("[REPEATING]\n");
        // }
        // }

        
        // string found = groceries.Find(item => item.ToLower() == input.ToLower());
        // if (groceries.Contains(found))
        // {
        //     groceries.Remove(found);
        // }
        // else
        // {
        //     Console.WriteLine("Item not found...");
        // }



            Booking found = _bookings.Find(b => b.Id == id);
            
            // if (_bookings.Contains(found))
            // {
            //     _bookings.Remove(found));
            // }

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
        // throw new NotImplementedException();

        int index = _bookings.FindIndex(b => b.Id == id);

        if (index == -1)
        {
            return "\nBestillingen ble ikke funnet!\n";
        }

        // return "Booking found!";

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
        // throw new NotImplementedException();
        
        // List<string> groceries = [];
        // foreach (string item in groceries)
        // {
        //     Console.WriteLine(item);
        // }
        
        var dataList = new List<BookingData>();
        foreach (var b in _bookings)
        {
            dataList.Add(new BookingData
            {
                Id = b.Id, CustomerName = b.CustomerName, Room = b.Room, Date = b.Date, StartTime = b.Start,
                EndTime = b.End, Description = b.Description
            });

            // string savedJson = JsonSerializer.Serialize(saveDto);
            // File.WriteAllText("account.json", savedJson);
            
            
            
        }
        
        string savedJson = JsonSerializer.Serialize(dataList);
        File.WriteAllText("bookings.json", savedJson);
        
        // var saveDto = new BankAccountDto { Balance = myAccount.CurrentBalance, Status = "GoodScore" };

    }
    
}