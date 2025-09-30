namespace AutoVerhuurProject.Domein.Models;

internal class Reservering
   
{
    public Guid ReserveringId { get; private set; }

    public Klant KlantReservering { get;  set;  }

    public Vestiging Luchthaven { get;  set; }

    public Auto AutoR { get;  set; }

    public Reservering(Guid reserveringId, Klant klantReservering, Vestiging luchthaven, Auto autoR, DateTime startHuurPeriode, DateTime eindeHuurPeriode)
    {
        ReserveringId = reserveringId;
        this.KlantReservering = klantReservering;
        this.Luchthaven = luchthaven;
        this.AutoR = autoR;
        StartHuurPeriode = startHuurPeriode;
        EindeHuurPeriode = eindeHuurPeriode;
    }

    private DateTime _startHuurPeriode;

    public DateTime StartHuurPeriode
    {
        get { return _startHuurPeriode; }
        set 
        { 
            if(value < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("De start van de huurperiode moet in de toekomst liggen");
            }
            else
            {
                _startHuurPeriode = value;
            }
               
        }
    }

    private DateTime _eindeHuurPeriode;

    public DateTime EindeHuurPeriode
    {
        get { return _eindeHuurPeriode; }
        private set 
        { 
            if (value < StartHuurPeriode.AddDays(1.0))
            {
                throw new ArgumentOutOfRangeException("De huur periode moet minstens 1 dag zijn.");
            }
            else
            {
                _eindeHuurPeriode = value;
            }
               
        }
    }


       

   
   
}
