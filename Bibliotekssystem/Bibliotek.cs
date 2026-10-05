class Bibliotek
{
    private List<Bok> böcker = new List<Bok>();

    public void LäggTillBok(Bok bok)
    {
        böcker.Add(bok);
    }

    public void LånaBok(string titel)
    {
        foreach (Bok bok in böcker)
        {
            if (bok.Titel.ToLower() == titel.ToLower())
            {
                if (bok.ÄrUtlånad == false)
                {
                    bok.ÄrUtlånad = true;
                    Console.WriteLine("Boken är nu utlånad.");
                }
                else
                {
                    Console.WriteLine("Boken är redan utlånad.");
                }

                return;
            }
        }

        Console.WriteLine("Boken hittades inte.");
    }

    public void LämnaTillbakaBok(string titel)
    {
        foreach (Bok bok in böcker)
        {
            if (bok.Titel.ToLower() == titel.ToLower())
            {
                if (bok.ÄrUtlånad == true)
                {
                    bok.ÄrUtlånad = false;
                    Console.WriteLine("Boken har lämnats tillbaka.");
                }
                else
                {
                    Console.WriteLine("Boken är inte utlånad.");
                }

                return;
            }
        }

        Console.WriteLine("Boken hittades inte.");
    }

    public void SökBok(string sökord)
    {
        bool hittad = false;

        foreach (Bok bok in böcker)
        {
            if (bok.Titel.ToLower().Contains(sökord.ToLower()) ||
                bok.Författare.ToLower().Contains(sökord.ToLower()))
            {
                Console.WriteLine(
                    $"Titel: {bok.Titel}, Författare: {bok.Författare}, År: {bok.År}"
                );

                hittad = true;
            }
        }

        if (hittad == false)
        {
            Console.WriteLine("Ingen bok hittades.");
        }
    }

    public void VisaBöcker()
    {
        bool finnsTillgänglig = false;

        Console.WriteLine();
        Console.WriteLine("=== Tillgängliga böcker ===");

        foreach (Bok bok in böcker)
        {
            if (bok.ÄrUtlånad == false)
            {
                Console.WriteLine(
                    $"Titel: {bok.Titel}, Författare: {bok.Författare}, År: {bok.År}"
                );

                finnsTillgänglig = true;
            }
        }

        if (finnsTillgänglig == false)
        {
            Console.WriteLine("Det finns inga tillgängliga böcker.");
        }
    }
}