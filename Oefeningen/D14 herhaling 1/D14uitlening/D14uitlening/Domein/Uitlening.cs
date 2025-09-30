namespace D14uitlening.Domein
{
    public class Uitlening
    {
        private string _omschrijving;
        public void SetOmschrijving(string omschrijving)
        {
            _omschrijving = omschrijving;
        }
        public string GetOmschrijving()
        {
            return _omschrijving;
        }

        private DateTime _ontleenDatum;
        public void SetOntleendatum(DateTime datum)
        {
            _ontleenDatum = datum;
        }
        public DateTime GetOntleendatum()
        {
            return _ontleenDatum;
        }

        public DateTime UitersteInleverdatum()
        {
            return GetOntleendatum().AddDays(14);
        }
    }
}
