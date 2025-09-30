namespace D18persoonopnaam.Domein
{
    public class PersoonNaamComparer : IComparer<Persoon>
    {
        public int Compare(Persoon p1, Persoon p2 )
        {
            return p1.Naam.CompareTo(p2.Naam);
        }
    }
}
