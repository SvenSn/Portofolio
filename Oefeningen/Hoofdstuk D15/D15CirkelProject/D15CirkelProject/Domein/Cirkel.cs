namespace D15CirkelProject.Domein
{
    public class Cirkel
    {
		private double _straal;

		public double Straal
		{
			get { return _straal; }
			set { _straal = value; }
		}

		public double Oppervlakte()
		{
			return Straal*Straal * Math.PI;
		}

		public double Omtrek()
		{
			return Straal*2*Math.PI;	
		}

	}
}
