namespace D18factuur.Domein
{
    public class FactuurBedragComparer : IComparer<Factuur>
    {
        public int Compare(Factuur f1 , Factuur f2)
        {
            return f2.Bedrag.CompareTo(f1.Bedrag);
        }
    }
}
