List<Uppgift> uppgifter = new List<Uppgift>();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Uppgiftshanterare ===");
    Console.WriteLine("1. Lägg till uppgift");
    Console.WriteLine("2. Nästa uppgift");
    Console.WriteLine("3. Visa alla uppgifter");
    Console.WriteLine("4. Markera uppgift som slutförd");
    Console.WriteLine("0. Avsluta");

    Console.Write("Välj ett alternativ: ");
    string val = Console.ReadLine() ?? "";

    if (val == "1")
    {
        Console.Write("Ange uppgiftens titel: ");
        string titel = Console.ReadLine() ?? "";

        Console.Write("Ange prioritet (1 = hög, 2 = medel, 3 = låg): ");
        int prioritet = int.Parse(Console.ReadLine() ?? "3");

        Uppgift nyUppgift = new Uppgift
        {
            Titel = titel,
            Prioritet = prioritet
        };

        uppgifter.Add(nyUppgift);

        Console.WriteLine("Uppgiften har lagts till!");
    }
    else if (val == "2")
    {
        if (uppgifter.Count > 0)
        {
            Uppgift nästaUppgift = uppgifter
                .OrderBy(uppgift => uppgift.Prioritet)
                .First();

            Console.WriteLine(
                $"Nästa uppgift: {nästaUppgift.Titel} - Prioritet: {nästaUppgift.Prioritet}"
            );
        }
        else
        {
            Console.WriteLine("Det finns inga uppgifter.");
        }
    }
    else if (val == "3")
    {
        if (uppgifter.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("=== Alla uppgifter ===");

            var sorteradeUppgifter = uppgifter
                .OrderBy(uppgift => uppgift.Prioritet);

            foreach (Uppgift uppgift in sorteradeUppgifter)
            {
                Console.WriteLine(
                    $"{uppgift.Titel} - Prioritet: {uppgift.Prioritet}"
                );
            }
        }
        else
        {
            Console.WriteLine("Det finns inga uppgifter.");
        }
    }
    else if (val == "4")
    {
        Console.Write("Ange titeln på uppgiften som är slutförd: ");
        string titel = Console.ReadLine() ?? "";

        Uppgift? slutfördUppgift = uppgifter
            .FirstOrDefault(uppgift =>
                uppgift.Titel.ToLower() == titel.ToLower());

        if (slutfördUppgift != null)
        {
            uppgifter.Remove(slutfördUppgift);

            Console.WriteLine("Uppgiften är slutförd och har tagits bort!");
        }
        else
        {
            Console.WriteLine("Uppgiften hittades inte.");
        }
    }
    else if (val == "0")
    {
        Console.WriteLine("Programmet avslutas.");
        break;
    }
}