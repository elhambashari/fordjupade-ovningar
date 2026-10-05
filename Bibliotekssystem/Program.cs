Bibliotek bibliotek = new Bibliotek();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Bibliotekssystem ===");
    Console.WriteLine("1. Lägg till bok");
    Console.WriteLine("2. Låna bok");
    Console.WriteLine("3. Lämna tillbaka bok");
    Console.WriteLine("4. Sök efter bok");
    Console.WriteLine("5. Visa alla tillgängliga böcker");
    Console.WriteLine("0. Avsluta");

    Console.Write("Välj ett alternativ: ");
    string val = Console.ReadLine() ?? "";

    if (val == "1")
    {
        Console.Write("Ange bokens titel: ");
        string titel = Console.ReadLine() ?? "";

        Console.Write("Ange författare: ");
        string författare = Console.ReadLine() ?? "";

        Console.Write("Ange utgivningsår: ");
        int år = int.Parse(Console.ReadLine() ?? "0");

        Bok nyBok = new Bok
        {
            Titel = titel,
            Författare = författare,
            År = år,
            ÄrUtlånad = false
        };

        bibliotek.LäggTillBok(nyBok);

        Console.WriteLine("Boken har lagts till!");
    }
    else if (val == "2")
    {
        Console.Write("Ange titeln på boken du vill låna: ");
        string titel = Console.ReadLine() ?? "";

        bibliotek.LånaBok(titel);
    }
    else if (val == "3")
    {
        Console.Write("Ange titeln på boken du vill lämna tillbaka: ");
        string titel = Console.ReadLine() ?? "";

        bibliotek.LämnaTillbakaBok(titel);
    }
    else if (val == "4")
    {
        Console.Write("Skriv titel eller författare: ");
        string sökord = Console.ReadLine() ?? "";

        bibliotek.SökBok(sökord);
    }
    else if (val == "5")
    {
        bibliotek.VisaBöcker();
    }
    else if (val == "0")
    {
        Console.WriteLine("Programmet avslutas.");
        break;
    }
}