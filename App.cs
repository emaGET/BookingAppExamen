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
                {

                    // BookingConsole.AskForString("Name: "); 
                    // BookingConsole.AskForString("Room: ( A / B / C )"); 
                    // BookingConsole.AskForString("Day: "); 
                    // BookingConsole.AskFor ("Start: "); 
                    // BookingConsole.AskFor ("End: "); 
                    // BookingConsole.AskForString("Description: "); 

                    string customerName = BookingConsole.AskForString("Navn");
                    string room = BookingConsole.AskForString("Rom ( A / B / C )");
                    string date = BookingConsole.AskForString("Dato");
                    string startTime = BookingConsole.AskForString("Start (hh:mm)");
                    string endTime = BookingConsole.AskForString("Slutt (hh:mm)");
                    string description = BookingConsole.AskForString("Beskrivelse");


                    string result = _manager.AddBooking(customerName, room, date, startTime, endTime, description);
                    BookingConsole.ShowMessage(result);

                    break;
                    
                }

                case "3":
                {
                    var ids = _manager.GetAllIds();

                    int id = BookingConsole.AskForId(ids, "Hvilken bestilling ønsker du å redigere?");

                    string newCustomerName = BookingConsole.AskForString("Ny navn");
                    string newRoom = BookingConsole.AskForString("Ny rom ( A / B / C )");
                    string newDate = BookingConsole.AskForString("Ny dato");
                    string newStartTime = BookingConsole.AskForString("Ny start (hh:mm)");
                    string newEndTime = BookingConsole.AskForString("Ny slutt (hh:mm)");
                    string newDescription = BookingConsole.AskForString("Ny beskrivelse");

                    string result = _manager.EditBooking(id, newCustomerName, newRoom, newDate, newStartTime,
                        newEndTime, newDescription);
                    BookingConsole.ShowMessage(result);

                    break;
                }

                case "4":
                {
                    var ids = _manager.GetAllIds();
                    int id = BookingConsole.AskForId(ids, "Hvilken bestilling ønsker du å fjerne?");

                    bool removed = _manager.DeleteBooking(id);

                    if (removed)
                    {
                        BookingConsole.ShowMessage("\nBestillingen er slettet!\n");
                    }
                    else
                    {
                        BookingConsole.ShowMessage("\nBestillingen ble ikke funnet! Prøv igjen\n");
                    }

                    break;
                }
                
                case "0":
                    return;
                
                default:
                    BookingConsole.ShowMessage("\nUgyldig valg. Prøv igjen.\n");
                    break;
                
            }
        }
    }
}