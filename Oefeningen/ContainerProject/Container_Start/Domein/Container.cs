namespace Container_Oef.Domein
{
	public class Container
	{
		private string _eigenaar;
		private int _volume;
		private int _massa;
		private readonly int _serialNumber;

		// Constructor 
		public Container(string eigenaar, int volume, int massa, int serialNumber)
		{
			Eigenaar = eigenaar;
			Volume = volume;
			Massa = massa;

			ControleerSerialNumber(serialNumber);
			this._serialNumber = serialNumber;
		}

		private string Eigenaar
		{
			set
			{
				if (string.ReferenceEquals(value, null) || value.Length == 0)
				{
					throw new System.ArgumentException("Er moet een eigenaar opgegeven worden.");
				}
				this._eigenaar = value;
			}
			get
			{
				return _eigenaar;
			}
		}

		private int Volume
		{
			set
			{
				if (value <= 0)
				{
					throw new System.ArgumentException("Geen geldig volume opgegeven.");
				}
				this._volume = value;
			}
			get
			{
				return _volume;
			}
		}

		private int Massa
		{
			set
			{
				if (value <= 0)
				{
					throw new System.ArgumentException("Geen geldige massa opgegeven.");
				}
				this._massa = value;
			}
			get
			{
				return _massa;
			}
		}

		public int SerialNumber
		{
			get
			{
				return _serialNumber;
			}
		}

		private void ControleerSerialNumber(int serialNumber)
		{
			if (serialNumber <= 0)
			{
				throw new System.ArgumentException("Ongeldig serienummer!");
			}
		}

        public override bool Equals(object obj)
        {
          if(!(obj is Container))
			{
				return false;
			}
		else
			{
				return this.SerialNumber == ((Container)obj).SerialNumber;
			}
        }
    }
    }