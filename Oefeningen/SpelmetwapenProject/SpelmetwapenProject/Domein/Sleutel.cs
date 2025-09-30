namespace SpelmetwapenProject.Domein
{
    public class Sleutel : Voorwerp
    {
        private static int _aantalInOmloop;





        public Sleutel(string naam, double gewicht, int niveau, int deur) : base(naam, gewicht, niveau)
        {
            Deur = deur;

            _aantalInOmloop = _aantalInOmloop+1;

        }



        public static int AantalInOmloop()
        {
            return _aantalInOmloop;
        }
        private int _deur;

        

        public int Deur
		{
			get { return _deur; }
			set 
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Deur moet een positief getal zijn");
				} 
				else
				{
                    _deur = value;
                }
			}
		}
        private static int aantalInOmloop { get; set; } = 0;

        public override string ToString()
        {
            return string.Format($"{base.ToString()} past op deur {Deur}.");
        }


    }
}
