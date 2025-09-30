using System.Collections;

namespace ContainerProject.Domein
{
    public class Container : IComparable<Container>
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

        public string Eigenaar
        {
            private set
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

        public int Volume
        {
           private set
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

        public int Massa
        {
            private set
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
       

        public override string ToString()
        {
            return $"{Volume}m³ - {Eigenaar} - {Massa}kg";
        }

        public int CompareTo(Container other)
        {
            if (other == null) return 1;
            return this._volume.CompareTo(other._volume); // Vergelijkt op basis van volume
        }


    }
}
