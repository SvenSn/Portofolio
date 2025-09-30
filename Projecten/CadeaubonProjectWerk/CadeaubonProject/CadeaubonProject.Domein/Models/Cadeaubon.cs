namespace CadeaubonProject.Domein.Models;



internal class Cadeaubon
{

    public Guid CadeaubonId { get; }
    public decimal Saldo { get; private set; }
    public ThemaType Thema { get; }
    public DateTime Datum { get; }

    

    public Cadeaubon(Guid id, decimal prijs,ThemaType thema, DateTime datum)
    {
        CadeaubonId = id;
        
        if (prijs <= 0) //minimumbedrag bij aankoop?
        {
            throw new ArgumentOutOfRangeException("Prijs moet groter zijn dan 0");
        }else
        {
            Saldo = prijs;
        };
        Thema = thema;
        Datum = datum;

       
    }

    public bool IsGeldig(DateTime aankoopdatum)
    {
        //Controleer of de datum van vandaag kleiner is dan de aankoopdatum + 1 jaar
        DateTime controleDatum = aankoopdatum.AddYears(1);

        if (!(DateTime.Now < controleDatum))
        {
            return false;
        }

        return true;
    }

    
    
}
