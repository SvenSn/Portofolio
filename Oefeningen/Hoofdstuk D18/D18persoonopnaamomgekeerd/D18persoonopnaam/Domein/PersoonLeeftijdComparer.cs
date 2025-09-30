namespace D18persoonopnaam.Domein
{
    public class PersoonLeeftijdComparer : IComparer<Persoon>
    {

        public int Compare(Persoon p1, Persoon p2)
        {
            return p1.Leeftijd.CompareTo(p2.Leeftijd);
        }
    }
}
