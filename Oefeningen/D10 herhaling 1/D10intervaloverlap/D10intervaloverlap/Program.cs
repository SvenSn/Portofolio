
namespace D10intervaloverlap
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

        private static bool IsOverlappend(int mininterval1, int maxinterval1, int mininterval2, int maxinterval2)
        {
            bool isOverlappend = true;

            if (mininterval1 <= maxinterval2 && mininterval2 <= maxinterval1)
            {
                isOverlappend = true;
                
            }
            else
            {
                isOverlappend = false;
            }

            return isOverlappend;
        }
    }
}
