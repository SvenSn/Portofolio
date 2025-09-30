namespace D18persoonopleeftijd.Domein
{
    public class PersoonLeeftijdCompare : IComparer<Persoon>
    {
        public int Compare(Persoon p1,Persoon p2 )
        {
            return p1.Leeftijd.CompareTo( p2.Leeftijd );
        }
    }
}
