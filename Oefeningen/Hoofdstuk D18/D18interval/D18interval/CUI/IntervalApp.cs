using D18interval.Domein;

namespace D18interval.CUI
{
    public class IntervalApp
    {
        public void Run()
        {
            Interval i1 = new Interval(2, 5);
            Interval i2 = new Interval(6, 9);
            Interval i3 = new Interval(3, 6);
            Interval i4 = new Interval(3, 4);
            Interval i5 = new Interval(5, 9);

            Console.WriteLine($"i1 en i2 {i1.OverlaptMet(i2)} {i2.OverlaptMet(i1)}");  // false false
            Console.WriteLine($"i1 en i3 {i1.OverlaptMet(i3)} {i3.OverlaptMet(i1)}");  // true true
            Console.WriteLine($"i1 en i4 {i1.OverlaptMet(i4)} {i4.OverlaptMet(i1)}");  // true true
            Console.WriteLine($"i1 en i5 {i1.OverlaptMet(i5)} {i5.OverlaptMet(i1)}");  // false false


            //zelf controle voor fout die ik had 
            Console.WriteLine($"de lengte van i4 {i4.Lengte}");

            List<Interval> intervallen = new List<Interval> { i3, i5, i2, i4, i1 };

            foreach (Interval i in intervallen)
            {
                Console.WriteLine($"[{i.Min},{i.Max}[");
            }

            Console.WriteLine("Gesorteerd : ");

            // TODO : lijst sorteren met comparer 
            MinDanLengteComparer mdlc = new MinDanLengteComparer();
            intervallen.Sort(mdlc);

            foreach (Interval i in intervallen)
            {
                Console.WriteLine($"[{i.Min},{i.Max}[");
            }
        }
    }
    
}
