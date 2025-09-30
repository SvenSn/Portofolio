namespace SpelmetwapenProject.Domein
{
    public class Wapen : Voorwerp
    {
		private int _kracht;

		public int Kracht
		{
			get { return _kracht; }
			set 
			{ 
				if( value <= 0)
				{
					throw new ArgumentOutOfRangeException("Kracht moet een positief getal zijn!");
				}
				else
				{
                    _kracht = value;
                }
				
			}
		}

		private bool _isGebruikt;

        public Wapen(int kracht, bool isGebruikt,string naam, double gewicht, int niveau ): base(naam,gewicht,niveau) 
        {
            Kracht = kracht;
            IsGebruikt = isGebruikt;
        }

        public bool IsGebruikt
		{
			get { return _isGebruikt; }
			set { _isGebruikt = value; }
		}
		private void ControleerNiveau (int niveau)
		{
			if (niveau < 1 ||  niveau > 5)
			{
				throw new ArgumentOutOfRangeException("Niveau van een wapen moet tussen de 1 tot en met 5 zijn !");
			}
			else
			{
				niveau = Niveau;
			}
		}

        public override string ToString()
        {
			return string.Format($"{base.ToString()} en met kracht {Kracht} en {(IsGebruikt ? "is gebruikt":"is niet gebruikt")}.");
        }


    }
}
