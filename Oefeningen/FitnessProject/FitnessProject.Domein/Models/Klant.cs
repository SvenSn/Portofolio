namespace FitnessProject.Domein.Models;

internal class Klant
{

	private int _KlantNr;

	public int KlantNr
	{
		get { return _KlantNr; }
		 set
		{
			if (value > 0)
			{
				_KlantNr = value;
			}
			else
			{
				throw new ArgumentException(nameof(KlantNr),"Klantnummer moet groter zijn dan 0.");
			}
		}
	}

	private List<LoopTraining> _looptrainingen;

    public Klant(int klantNr)
    {
        KlantNr = klantNr;
    }
}
