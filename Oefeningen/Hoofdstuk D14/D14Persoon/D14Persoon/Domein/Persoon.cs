

namespace D14Persoon.Domein
{
    class Persoon
    {
        private string _naam;
        public string GetNaam()
        {
            return _naam;
        }
        public void SetNaam(string naam)
        {
            _naam = naam;
        }

        private DateTime _geboortedatum;
        public DateTime GetGeboortedatum()
        {
            return _geboortedatum;
        }
        public void SetGeboortedatum(DateTime geboortedatum)
        {
            _geboortedatum = geboortedatum;
        }

        public int Leeftijd()
        {
            int leeftijd = 0;
            DateTime dt = GetGeboortedatum().Date.AddYears(1);
            while (dt <= DateTime.Today)
            {
                leeftijd++;
                dt = dt.AddYears(1);
            }
            return leeftijd;
        }
        private string _woonplaats;
        public string GetWoonplaats()
        {
            return _woonplaats;
        }
        public void SetWoonplaats(string woonplaats)
        {
            _woonplaats = woonplaats;
        }


    }
}
