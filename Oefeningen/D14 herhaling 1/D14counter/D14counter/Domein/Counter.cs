namespace D14counter.Domein
{
    public class Counter
    {
		private int _value;

		public int Value
		{
			get { return _value; }
			set { _value = value; }
		}

		private int _stepvalue = 1;

		public int Stepvalue
		{
			get { return _stepvalue; }
			set { _stepvalue = value; }
		}

		public void Advance()
		{
			this.Value += Stepvalue;
		}
	}
}
