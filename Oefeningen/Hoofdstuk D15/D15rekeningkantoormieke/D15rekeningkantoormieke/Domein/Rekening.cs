using D15rekeningkantoormieke.Domein;

namespace D15rekeningkantoor.Domein
{
    public class Rekening
    {
        private string _nummer;

        public string Nummer
        {
            get { return _nummer; }
            set { _nummer = value; }
        }
        private double _saldo;

        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
        private Kantoor _kantoor;

        public Kantoor Kantoor1
        {
            get { return _kantoor; }
            set { _kantoor = value; }
        }

        private Persoon _titularis;

        public Persoon Titularis
        {
            get { return _titularis; }
            set { _titularis = value; }
        }

        public Rekening(string nummer, double saldo, Kantoor kantoor1, Persoon titularis)
        {
            Nummer = nummer;
            Saldo = saldo;
            Kantoor1 = kantoor1;
            Titularis = titularis;
        }
    }
}
