using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

public static class BibliotekJsonHantering
{
    private const string filnamn = "LibraryData.json";

    public static Bibliotek LaddaDataFrånJSON()
    {
        if (!File.Exists(filnamn))
        {
            Console.WriteLine("Ingen datafil hittades, en ny fil kommer att skapas.");
            return new Bibliotek(); // Returnerar ett nytt Bibliotek-objekt om filen inte finns
        }

        try
        {
            string json = File.ReadAllText(filnamn);
            return JsonConvert.DeserializeObject<Bibliotek>(json) ?? new Bibliotek();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid inläsning från JSON: {ex.Message}");
            return new Bibliotek();
        }
    }

    public static void SparaDataTillJSON(Bibliotek bibliotek)
    {
        if (bibliotek == null)
        {
            Console.WriteLine("Biblioteket är null, kan inte spara data.");
            return;
        }

        try
        {
            string json = JsonConvert.SerializeObject(bibliotek, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filnamn, json); // Skapar eller uppdaterar LibraryData.json
            Console.WriteLine("Data har sparats till JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid sparande till JSON: {ex.Message}");
        }
    }
}
