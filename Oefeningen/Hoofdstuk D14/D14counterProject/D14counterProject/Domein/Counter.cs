namespace D14counterProject.Domein
{
	public class Counter
	{
		private int _value;

		public int Value
		{
			get { return _value; }
			set { _value = value; }
		}

		private int _step;

		public int Step
		{
			get { return _step; }
			set { _step = value; }
		}

		public void Advance()
		{
			_value += _step;
		}

		public Counter(int value, int step)
		{
			Value = value;
			Step = step;
		}

		public Counter() : this(0, 1)
		{
		
		}

    }
}
