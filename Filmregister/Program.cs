List<Film> filmer = new List<Film>();


while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Mini-Filmregister ===");
    Console.WriteLine("1. Lägg till film");
    Console.WriteLine("2. Sök filmer efter genre");
    Console.WriteLine("3. Visa topp 3 filmer");
    Console.WriteLine("4. Ta bort film");
    Console.WriteLine("0. Avsluta");

    Console.Write("Välj ett alternativ: ");
    string val = Console.ReadLine() ?? "";

    if (val == "1")
    {
        Console.Write("Ange filmens titel: ");
        string titel = Console.ReadLine() ?? "";

        Console.Write("Ange genre: ");
        string genre = Console.ReadLine() ?? "";

        Console.Write("Ange betyg (1-10): ");
        int betyg = int.Parse(Console.ReadLine() ?? "0");

        Film nyFilm = new Film
        {
            Titel = titel,
            Genre = genre,
            Betyg = betyg
        };

        filmer.Add(nyFilm);

        Console.WriteLine("Filmen har lagts till!");
    }
    else if (val == "2")
    {
        Console.Write("Ange genre att söka efter: ");
        string genre = Console.ReadLine() ?? "";

        bool hittad = false;

        foreach (Film film in filmer)
        {
            if (film.Genre.ToLower() == genre.ToLower())
            {
                Console.WriteLine(
                    $"{film.Titel} - {film.Genre} - Betyg: {film.Betyg}"
                );

                hittad = true;
            }
        }

        if (hittad == false)
        {
            Console.WriteLine("Inga filmer hittades i den genren.");
        }
    }
    else if (val == "3")
    {
        if (filmer.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("=== Topp 3 filmer ===");

            var toppTre = filmer
                .OrderByDescending(film => film.Betyg)
                .Take(3);

            foreach (Film film in toppTre)
            {
                Console.WriteLine(
                    $"{film.Titel} - {film.Genre} - Betyg: {film.Betyg}"
                );
            }
        }
        else
        {
            Console.WriteLine("Det finns inga filmer.");
        }
    }
    else if (val == "4")
    {
        Console.Write("Ange titeln på filmen du vill ta bort: ");
        string titel = Console.ReadLine() ?? "";

        Film? filmAttTaBort = filmer.FirstOrDefault(
            film => film.Titel.ToLower() == titel.ToLower()
        );

        if (filmAttTaBort != null)
        {
            filmer.Remove(filmAttTaBort);

            Console.WriteLine("Filmen har tagits bort!");
        }
        else
        {
            Console.WriteLine("Filmen hittades inte.");
        }
    }
    else if (val == "0")
    {
        Console.WriteLine("Programmet avslutas.");
        break;
    }
}