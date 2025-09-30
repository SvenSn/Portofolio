namespace D15rekeningkantoor.Domein
{
    public class Persoon
    {
        // string Voornaam
        //string Familienaam
        //Adres Adres

        private string _voornaam;

        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }
        private string _familienaam;

        public string FamilieNaam
        {
            get { return _familienaam; }
            set { _familienaam = value; }
        }

        private Adres _adres;

        public Adres AdresP
        {
            get { return _adres; }
            set { _adres = value; }
        }

        public Persoon(string voornaam, string familieNaam, Adres adres1)
        {
            Voornaam = voornaam;
            FamilieNaam = familieNaam;
            AdresP = adres1;
        }
    }
}
