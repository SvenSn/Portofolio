namespace D14cirkel.Domein
{
    public class Cirkel
    {
		private double _straal;

		public double Straal
		{
			get { return _straal; }
			set { _straal = value; }
		}

		public double Omtrek()
		{
			double omtrek = (2 * this.Straal)  * Math.PI;
			return omtrek;
		}
		public double Oppervlakte ()
		{
			double oppervlakte = Math.PI * Math.Pow(this.Straal,2);
			return oppervlakte;
		}


	}
}
