namespace D18afspraak.Domein
{
    public class TijdsduurComparer : IComparer<Afspraak>
    {
        public int Compare(Afspraak a,Afspraak b)
        {
            return a.Duur.CompareTo(b.Duur);
        }
    }
}
