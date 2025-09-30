namespace D18persoonopnaam.Domein
{
    public class PersoonNaamComparer : IComparer<Persoon>
    {
        public int Compare(Persoon p1, Persoon p2 )
        {
            return p2.Naam.CompareTo( p1.Naam );
        }
    }
}
