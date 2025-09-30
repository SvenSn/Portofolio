namespace Rechthoek.Domein;

internal class RechthoekKlasse
{
	private double _Lengte;

	public double Lengte
	{
		get { return _Lengte; }
		private set 
		{ 

			if(value > 0)
			{
                _Lengte = value;
            }
			else
			{
				throw new ArgumentOutOfRangeException("De lengte moet groter zijn dan 0.");
			}
		}
	}


	private double _breedte;

	public double Breedte
	{
		get { return _breedte; }
		private set 
		{
            if (value > 0)
            {
                _breedte = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("De Bredte moet groter zijn dan 0.");
            }
             
		}
	}

    public RechthoekKlasse(double lengte, double breedte)
    {
        Lengte = lengte;
        Breedte = breedte;
    }


	public double GeefOmtrek(double lengte,double breedte)
	{
		double resultaat = (2 * lengte) + (2 * breedte);

		return resultaat;
	}

	public double GeefOppervlakte(double lengte , double breedte)
	{
		double resultaat = lengte * breedte;

		return resultaat;
	}

	public void Schaal(int percentage)
	{
		if(percentage > 0 && percentage <= 100)
		{
            Lengte = (Lengte * (1 + percentage / 100.0));
            Breedte = (Breedte * (1 + percentage / 100.0));
        }
		else
		{
			throw new ArgumentOutOfRangeException("Het schaalpercentage moet tussen 1 tot en met 100 liggen.");
		}
	
    }
}
