List<string> historik = new List<string>();
Stack<string> ångrade = new Stack<string>();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Texteditor ===");
    Console.WriteLine("1. Lägg till text");
    Console.WriteLine("2. Ångra");
    Console.WriteLine("3. Gör om");
    Console.WriteLine("4. Visa hela historiken");
    Console.WriteLine("5. Rensa");
    Console.WriteLine("6. Visa historik och ångrade texter");
    Console.WriteLine("0. Avsluta");

    Console.Write("Välj ett alternativ: ");
    string val = Console.ReadLine() ?? "";

    if (val == "1")
    {
        Console.Write("Skriv text: ");
        string text = Console.ReadLine() ?? "";

        historik.Add(text);

        Console.WriteLine("Texten har lagts till.");
    }
    else if (val == "2")
    {
        if (historik.Count > 0)
        {
            string senasteTexten = historik[historik.Count - 1];

            historik.RemoveAt(historik.Count - 1);

            ångrade.Push(senasteTexten);

            Console.WriteLine($"Ångrade: {senasteTexten}");
        }
        else
        {
            Console.WriteLine("Det finns inget att ångra.");
        }
    }
    else if (val == "3")
    {
        if (ångrade.Count > 0)
        {
            string textAttGöraOm = ångrade.Pop();

            historik.Add(textAttGöraOm);

            Console.WriteLine($"Gjorde om: {textAttGöraOm}");
        }
        else
        {
            Console.WriteLine("Det finns inget att göra om.");
        }
    }
    else if (val == "4")
    {
        Console.WriteLine();
        Console.WriteLine("=== Historik ===");

        if (historik.Count > 0)
        {
            foreach (string text in historik)
            {
                Console.WriteLine(text);
            }
        }
        else
        {
            Console.WriteLine("Historiken är tom.");
        }
    }
    else if (val == "5")
    {
        historik.Clear();
        ångrade.Clear();

        Console.WriteLine("Historiken har rensats.");
    }
    else if (val == "6")
    {
        Console.WriteLine();
        Console.WriteLine("=== Historik ===");

        if (historik.Count > 0)
        {
            foreach (string text in historik)
            {
                Console.WriteLine(text);
            }
        }
        else
        {
            Console.WriteLine("Historiken är tom.");
        }

        Console.WriteLine();
        Console.WriteLine("=== Ångrade texter ===");

        if (ångrade.Count > 0)
        {
            foreach (string text in ångrade)
            {
                Console.WriteLine(text);
            }
        }
        else
        {
            Console.WriteLine("Det finns inga ångrade texter.");
        }
    }
    else if (val == "0")
    {
        Console.WriteLine("Programmet avslutas.");
        break;
    }
}