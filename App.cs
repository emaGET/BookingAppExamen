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
                    break;
                case "3":
                    break;
                case "4":
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