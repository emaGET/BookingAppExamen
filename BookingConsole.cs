namespace BookingApp;

public static class BookingConsole
{
    public static string AskForMenuChoice()
    {
        Console.WriteLine("1. Vis alle bookinger");
        Console.WriteLine("2. Legg til booking");
        Console.WriteLine("3. Rediger booking");
        Console.WriteLine("4. Slett booking");
        Console.WriteLine("0. Avslutt");
        Console.Write("\nVelg: ");
        return Console.ReadLine() ?? "";
    }

    public static int AskForId(List<int> validIds, string prompt)
    {
        Console.WriteLine(prompt);
        while (true)
        {
            Console.Write("ID: ");
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int id) && validIds.Contains(id))
                return id;
            Console.WriteLine("Ugyldig ID. Prøv igjen.");
        }
    }

    public static string AskForString(string prompt, string currentValue = "")
    {
        Console.Write(!string.IsNullOrEmpty(currentValue) ? $"{prompt} [{currentValue}]: " : $"{prompt}: ");
        string input = Console.ReadLine() ?? "";
        return string.IsNullOrWhiteSpace(input) ? currentValue : input;
    }

    public static void ShowBookings(List<Booking> bookings)
    {
        Console.WriteLine();
        if (bookings.Count == 0)
        {
            Console.WriteLine("  Ingen bookinger registrert.");
            return;
        }

        Console.WriteLine($"  {"ID",-5} {"Navn",-20} {"Rom",-8} {"Dato",-12} {"Start",-7} {"Slutt",-7} Beskrivelse");
        Console.WriteLine("  " + new string('─', 72));

        foreach (var b in bookings)
        {
            // Skriv ut bookingen her
        }
        Console.WriteLine();
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}