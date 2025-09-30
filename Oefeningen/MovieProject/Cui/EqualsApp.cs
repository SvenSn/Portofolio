using System;
using WC_Movie.Domein;

namespace WC_Movie.Cui
{
	public class EqualsApp
	{
		static void Main(string[] args)
		{
            Movie firstMovie = new Movie("Force Awakens", 8.3, 2015);
            Movie secondMovie = new Movie("Force Awakens", 8.3, 2015);

            Console.WriteLine("Are the movies equal? ");

            // print yes or no
        }
	}
}