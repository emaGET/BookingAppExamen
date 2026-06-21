namespace BookingApp;

public class App
{
    private readonly BookingManager _manager = new BookingManager();

    public void Run()
    {
        while (true)
        {
            var choice = BookingConsole.AskForMenuChoice();

            switch (choice)
            {
                
                case "1":BookingConsole.ShowBookings(_manager.GetAll());
                    break;
                
                case "2":
                    // BookingConsole.AskForString("Name: "); 
                    // BookingConsole.AskForString("Room: ( A / B / C )"); 
                    // BookingConsole.AskForString("Day: "); 
                    // BookingConsole.AskFor ("Start: "); 
                    // BookingConsole.AskFor ("End: "); 
                    // BookingConsole.AskForString("Description: "); 
                    
                    string customerName = BookingConsole.AskForString("Name: ");
                    string room = BookingConsole.AskForString("Room: ( A / B / C ) " );
                    string date = BookingConsole.AskForString("Day: ");
                    string startTime = BookingConsole.AskForString("Start (hh:mm) : ");
                    string endTime = BookingConsole.AskForString("End (hh:mm) : ");
                    string description = BookingConsole.AskForString("Any note: ");
                    
                    
                    string result = _manager.AddBooking(customerName, room, date, startTime, endTime, description);
                    BookingConsole.ShowMessage(result);

                    break;
                
                case "3":
                    
                    break;
                
                case "4":
                    var ids = _manager.GetAllIds();
                    int id = BookingConsole.AskForId(ids, "Which booking would you like to remove?");

                    bool removed = _manager.DeleteBooking(id);

                    if (removed)
                    {
                        BookingConsole.ShowMessage("Booking removed!");
                    }
                    else
                    {
                        BookingConsole.ShowMessage("Booking not found! Try again"); 
                    }
                    break;
                
                case "0":
                    return;
                
                default:
                    BookingConsole.ShowMessage("Ugyldig valg. Prøv igjen.");
                    break;
                
            }
        }
    }
}