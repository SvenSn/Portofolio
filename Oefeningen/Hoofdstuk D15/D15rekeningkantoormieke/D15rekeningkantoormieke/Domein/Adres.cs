namespace D15rekeningkantoormieke.Domein
{
    public class Adres
    {
        private string _straat;

        public string Straat
        {
            get { return _straat; }
            set { _straat = value; }
        }

        private string _Huisnummer;

        public string Huisnummer
        {
            get { return _Huisnummer; }
            set { _Huisnummer = value; }
        }
        private string _postcode;

        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }
        private string _gemeente;

        public string Gemeente
        {
            get { return _gemeente; }
            set { _gemeente = value; }
        }

        public Adres(string straat, string huisnummer, string postcode, string gemeente)
        {
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Gemeente = gemeente;
        }

    }

}
