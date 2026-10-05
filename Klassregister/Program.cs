Dictionary<string, List<int>> elever = new Dictionary<string, List<int>>();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Klassregister ===");
    Console.WriteLine("1. Lägg till elev och första betyg");
    Console.WriteLine("2. Lägg till fler betyg");
    Console.WriteLine("3. Visa en elevs genomsnitt");
    Console.WriteLine("4. Visa alla elever och snittbetyg");
    Console.WriteLine("0. Avsluta");

    Console.Write("Välj ett alternativ: ");
    string val = Console.ReadLine() ?? "";

    if (val == "1")
    {
        Console.Write("Ange elevens namn: ");
        string namn = Console.ReadLine() ?? "";

        Console.Write("Ange elevens första betyg: ");
        int betyg = int.Parse(Console.ReadLine() ?? "0");

        elever.Add(namn, new List<int> { betyg });

        Console.WriteLine("Eleven och betyget har lagts till!");
    }
    else if (val == "2")
    {
        Console.Write("Ange elevens namn: ");
        string namn = Console.ReadLine() ?? "";

        if (elever.ContainsKey(namn))
        {
            Console.Write("Ange nytt betyg: ");
            int betyg = int.Parse(Console.ReadLine() ?? "0");

            elever[namn].Add(betyg);

            Console.WriteLine("Betyget har lagts till!");
        }
        else
        {
            Console.WriteLine("Eleven finns inte.");
        }
    }
    else if (val == "3")
    {
        Console.Write("Ange elevens namn: ");
        string namn = Console.ReadLine() ?? "";

        if (elever.ContainsKey(namn))
        {
            double genomsnitt = elever[namn].Average();

            Console.WriteLine($"Genomsnitt för {namn}: {genomsnitt}");
        }
        else
        {
            Console.WriteLine("Eleven finns inte.");
        }
    }
    else if (val == "4")
    {
        Console.WriteLine();
        Console.WriteLine("=== Alla elever ===");

        var sorteradeElever = elever
            .OrderByDescending(elev => elev.Value.Average());

        foreach (var elev in sorteradeElever)
        {
            double genomsnitt = elev.Value.Average();

            Console.WriteLine(
                $"{elev.Key} - Snittbetyg: {genomsnitt}"
            );
        }
    }
    else if (val == "0")
    {
        Console.WriteLine("Programmet avslutas.");
        break;
    }
}