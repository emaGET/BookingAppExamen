namespace BookingApp;
public class Booking
{
    public int Id { get; }
    public string CustomerName { get; } = "";
    public string Room { get; } = "";
    public DateOnly Date { get; }
    public TimeOnly Start { get; }
    public TimeOnly End { get; }
    public string Description { get; } = "";
    
    public Booking(int id, string customerName, string room, DateOnly date, TimeOnly start, TimeOnly end, string description)
    {
        Id = id;
        CustomerName = customerName;
        Room = room;
        Date = date;
        Start = start;
        End = end;
        Description = description;
    }

}

