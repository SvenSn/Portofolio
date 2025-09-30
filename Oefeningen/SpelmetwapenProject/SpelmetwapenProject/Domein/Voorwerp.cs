namespace SpelmetwapenProject.Domein
{
    public class Voorwerp
    {
		private string _naam;

		public string Naam
		{
			get { return _naam; }
		}

		private double _gewicht;

		public double Gewicht
		{
			get { return _gewicht; }
			private set 
			{ 
				if(value > 0 && value < 1000.0)
				{
                    _gewicht = value;
                }
				else
				{
					throw new ArgumentOutOfRangeException("Gewicht moet positief zijn en onder de 1000kg");
				}
			}
		}
		private int _niveau;

		public int Niveau
		{
			get { return _niveau; }
			private set 
			{
				if (value >= 1 && value <= 10)
				{
                    _niveau = value;
                }
				else
				{
					throw new ArgumentOutOfRangeException("Niveaus gaan van 1 tot en met 10.");
				}
			}
		}

        public Voorwerp(string naam, double gewicht, int niveau)
        {
            ControleerNaam(naam);
            _gewicht = gewicht;
			_niveau= niveau;

        }

        public Voorwerp(string naam, double gewicht)
        {
            ControleerNaam(naam);
			this._naam = naam;
			gewicht = _gewicht;
        }

		private void ControleerNaam(string naam)
		{
            if (naam == null || string.IsNullOrEmpty(naam))
            {
                throw new ArgumentNullException("Naam mag niet null of leeg zijn!!!");
            }
            else
            {
               _naam = naam;
            }
        }
		public virtual string ToString()
		{
			return string.Format($"{GetType().Name} {Naam} met gewicht {Gewicht,0:F3} kg uit niveau {Niveau}");
		}
    }
}
