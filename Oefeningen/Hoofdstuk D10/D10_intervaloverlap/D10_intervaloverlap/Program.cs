
namespace D10_intervaloverlap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een method IsOverlappend die ons kan vertellen of twee intervallen overlappen.

            //Een interval is een verzameling getallen, bepaald door een ondergrens en een bovengrens en alle getallen daartussen.

            

            Console.WriteLine(IsOverlappend(3, 6, 4, 10)); // toont true
            Console.WriteLine(IsOverlappend(4, 10, 3, 6)); // toont true
            Console.WriteLine(IsOverlappend(3, 6, 6, 10)); // toont true
            Console.WriteLine(IsOverlappend(6, 10, 3, 6)); // toont true
            Console.WriteLine(IsOverlappend(3, 6, 7, 10)); // toont false
            Console.WriteLine(IsOverlappend(7, 10, 3, 6)); // toont false
            Console.WriteLine(IsOverlappend(6, 6, 7, 7));  // toont false
            Console.WriteLine(IsOverlappend(7, 7, 6, 6));  // toont false
            Console.WriteLine(IsOverlappend(6, 6, 3, 10)); // toont true
            Console.WriteLine(IsOverlappend(3, 10, 6, 6)); // toont true
            Console.WriteLine(IsOverlappend(6, 6, 6, 10)); // toont true
            Console.WriteLine(IsOverlappend(6, 10, 6, 6)); // toont true
        }

        static bool IsOverlappend(int minInterval1, int maxInterval1, int minInterval2, int maxInterval2)
        {
            //Je mag er hierbij van uitgaan dat geldt dat minInterval1 <= maxInterval1 en minInterval2 <= maxInterval2.
            if (minInterval1 <= maxInterval2 && minInterval2 <= maxInterval1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
