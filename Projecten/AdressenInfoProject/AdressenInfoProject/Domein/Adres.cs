
namespace AdressenInfoProject.Domein;

public class Adres
{
    public string Provincie { get; set; }
    public string Stad { get; set; }
    public string Straat { get; set; }

    public Adres(string provincie, string stad, string straat)
    {
        Provincie = provincie;
        Stad = stad;
        Straat = straat;
    }

    public override bool Equals(object? obj)
    {
        return obj is Adres adres &&
               Straat == adres.Straat;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Straat);
    }


}
