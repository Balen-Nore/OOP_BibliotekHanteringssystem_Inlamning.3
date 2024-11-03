using System;
using System.Collections.Generic;
using System.Linq;

public class Bibliotek
{
    private List<Bok> böcker = new List<Bok>();
    private List<Författare> författare = new List<Författare>();

    public Bibliotek()
    {
        // Skapa förinställda böcker och författare
        SkapaFörinställdaData();
    }

    private void SkapaFörinställdaData()
    {
        // Skapa några författare
        var författare1 = new Författare { Id = 1, Namn = "J.K. Rowling", Land = "Storbritannien" };
        var författare2 = new Författare { Id = 2, Namn = "George R.R. Martin", Land = "USA" };
        författare.Add(författare1);
        författare.Add(författare2);

        // Skapa några böcker
        böcker.Add(new Bok { Id = 1, Titel = "Harry Potter och de vises sten", Författare = författare1.Namn, Genre = "Fantasy", Publiceringsår = 1997, Isbn = "978-3-16-148410-0" });
        böcker.Add(new Bok { Id = 2, Titel = "A Game of Thrones", Författare = författare2.Namn, Genre = "Fantasy", Publiceringsår = 1996, Isbn = "978-0-553-10354-0" });
    }

    public void LäggTillNyBok()
    {
        Bok nyBok = new Bok();
        Console.Write("Ange titel: ");
        nyBok.Titel = Console.ReadLine();

        Console.Write("Ange författare: ");
        nyBok.Författare = Console.ReadLine();

        Console.Write("Ange genre: ");
        nyBok.Genre = Console.ReadLine();

        Console.Write("Ange publiceringsår: ");
        if (int.TryParse(Console.ReadLine(), out int år))
        {
            nyBok.Publiceringsår = år;
        }

        Console.Write("Ange ISBN: ");
        nyBok.Isbn = Console.ReadLine();

        nyBok.Id = böcker.Count > 0 ? böcker.Max(b => b.Id) + 1 : 1; // Generera nytt Id
        böcker.Add(nyBok);
        Console.WriteLine("Ny bok har lagts till.");
        BibliotekJsonHantering.SparaDataTillJSON(this);
    }

    public void LäggTillNyFörfattare()
    {
        Författare nyFörfattare = new Författare();

        Console.Write("Ange namn: ");
        nyFörfattare.Namn = Console.ReadLine();

        Console.Write("Ange land: ");
        nyFörfattare.Land = Console.ReadLine();

        nyFörfattare.Id = författare.Count > 0 ? författare.Max(f => f.Id) + 1 : 1; // Generera nytt Id
        författare.Add(nyFörfattare);
        Console.WriteLine("Ny författare har lagts till.");
        BibliotekJsonHantering.SparaDataTillJSON(this);
    }

    public void ListaAllaBöckerOchFörfattare()
    {
        Console.WriteLine("\n--- Alla Böcker ---");
        foreach (var bok in böcker)
            Console.WriteLine($"ID: {bok.Id}, Titel: {bok.Titel}, Författare: {bok.Författare}, Genomsnittligt Betyg: {bok.GenomsnittligtBetyg}");

        Console.WriteLine("\n--- Alla Författare ---");
        foreach (var f in författare)
            Console.WriteLine($"ID: {f.Id}, Namn: {f.Namn}, Land: {f.Land}");
    }

    public void UppdateraBok(int id)
    {
        var bok = böcker.FirstOrDefault(b => b.Id == id);
        if (bok != null)
        {
            Console.Write("Ange ny titel (eller tryck Enter för att behålla): ");
            string nyTitel = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyTitel))
                bok.Titel = nyTitel;

            Console.Write("Ange ny författare (eller tryck Enter för att behålla): ");
            string nyFörfattare = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyFörfattare))
                bok.Författare = nyFörfattare;

            Console.Write("Ange ny genre (eller tryck Enter för att behålla): ");
            string nyGenre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyGenre))
                bok.Genre = nyGenre;

            Console.Write("Ange nytt publiceringsår (eller tryck Enter för att behålla): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int nyÅr))
                bok.Publiceringsår = nyÅr;

            Console.Write("Ange ny ISBN (eller tryck Enter för att behålla): ");
            string nyIsbn = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyIsbn))
                bok.Isbn = nyIsbn;

            Console.WriteLine("Boken har uppdaterats.");
            BibliotekJsonHantering.SparaDataTillJSON(this);
        }
        else
        {
            Console.WriteLine("Boken hittades inte.");
        }
    }

    public void TaBortBok(int id)
    {
        var bok = böcker.FirstOrDefault(b => b.Id == id);
        if (bok != null)
        {
            böcker.Remove(bok);
            Console.WriteLine("Boken har tagits bort.");
            BibliotekJsonHantering.SparaDataTillJSON(this);
        }
        else
        {
            Console.WriteLine("Boken hittades inte.");
        }
    }

    public void TaBortFörfattare(int id)
    {
        var författareObj = författare.FirstOrDefault(f => f.Id == id);
        if (författareObj != null)
        {
            författare.Remove(författareObj);
            Console.WriteLine("Författaren har tagits bort.");
            BibliotekJsonHantering.SparaDataTillJSON(this);
        }
        else
        {
            Console.WriteLine("Författaren hittades inte.");
        }
    }
}
