using System;

public class BibliotekMeny
{
    private Bibliotek _bibliotek;

    public BibliotekMeny()
    {
        _bibliotek = BibliotekJsonHantering.LaddaDataFrånJSON();
    }

    public void Start()
    {
        bool kör = true;
        while (kör)
        {
            VisaMeny();
            kör = HanteraVal();
        }
        BibliotekJsonHantering.SparaDataTillJSON(_bibliotek);
    }

    private void VisaMeny()
    {
        Console.WriteLine("\n--- BIBLIOTEK MENY ---");
        Console.WriteLine("1. Lägg till ny bok");
        Console.WriteLine("2. Lägg till ny författare");
        Console.WriteLine("3. Uppdatera bokdetaljer");
        Console.WriteLine("4. Ta bort bok");
        Console.WriteLine("5. Ta bort författare");
        Console.WriteLine("6. Lista alla böcker och författare");
        Console.WriteLine("7. Avsluta och spara data");
        Console.Write("Välj ett alternativ: ");
    }

    private bool HanteraVal()
    {
        if (!int.TryParse(Console.ReadLine(), out int val))
        {
            Console.WriteLine("Ogiltigt val, försök igen.");
            return true;
        }

        switch (val)
        {
            case 1:
                _bibliotek.LäggTillNyBok();
                break;
            case 2:
                _bibliotek.LäggTillNyFörfattare();
                break;
            case 3:
                Console.Write("Ange bok ID för uppdatering: ");
                if (int.TryParse(Console.ReadLine(), out int uppdateraId))
                {
                    _bibliotek.UppdateraBok(uppdateraId);
                }
                else
                {
                    Console.WriteLine("Ogiltigt ID.");
                }
                break;
            case 4:
                Console.Write("Ange bok ID för borttagning: ");
                if (int.TryParse(Console.ReadLine(), out int taBortId))
                {
                    _bibliotek.TaBortBok(taBortId);
                }
                else
                {
                    Console.WriteLine("Ogiltigt ID.");
                }
                break;
            case 5:
                Console.Write("Ange författar ID för borttagning: ");
                if (int.TryParse(Console.ReadLine(), out int taBortFörfattareId))
                {
                    _bibliotek.TaBortFörfattare(taBortFörfattareId);
                }
                else
                {
                    Console.WriteLine("Ogiltigt ID.");
                }
                break;
            case 6:
                _bibliotek.ListaAllaBöckerOchFörfattare();
                break;
            case 7:
                return false; // Avsluta programmet
            default:
                Console.WriteLine("Ogiltigt val, försök igen.");
                break;
        }

        return true;
    }
}
