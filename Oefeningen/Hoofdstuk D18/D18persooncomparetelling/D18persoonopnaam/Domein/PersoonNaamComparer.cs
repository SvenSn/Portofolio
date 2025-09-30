namespace D18persoonopnaam.Domein
{
    public class PersoonNaamComparer : IComparer<Persoon>
    {
        public int Compare(Persoon p1, Persoon p2 )
        {
            System.Console.WriteLine($"   {p1.Naam} en {p2.Naam} worden vergeleken");
            return p1.Naam.CompareTo( p2.Naam );
        }
    }
}
