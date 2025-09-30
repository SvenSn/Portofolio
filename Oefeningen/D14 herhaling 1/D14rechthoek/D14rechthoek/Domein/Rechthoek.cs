namespace D14rechthoek.Domein
{
    public class Rechthoek
    {
		private double _hoogte;

		public double Hoogte
		{
			get { return _hoogte; }
			set { _hoogte = value; }
		}
		private double _breedte;

		public double Breedte
		{
			get { return _breedte; }
			set { _breedte = value; }
		}

		public double Oppervlakte()
		{
			double oppervlakte = this.Hoogte * this.Breedte;
			return oppervlakte;
		}
	}
}
