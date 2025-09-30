namespace D18interval.Domein
{
    public class MinDanLengteComparer : IComparer<Interval>
    {
        public int Compare(Interval a , Interval b)
        {
            int resultaat = 0;
            if (a.Min != b.Min)
            {
                resultaat =  a.Min.CompareTo(b.Min);
            }
            else if (a.Min == b.Min)
            {
              resultaat =  a.Lengte.CompareTo(b.Lengte);
            }

           
            return resultaat;
        }

    }
}
