namespace WC_Movie.Domein;

// A class 'Movie' that implements Comparable 
public class Movie
{	
	// Getter & setter methods for accessing data 
	public double Rating { get; set; }
	public string Name { get; set; }
	public int Year { get; set; }

	// Constructor 
	public Movie(string nm, double rt, int yr)
	{
		Name = nm;
		Rating = rt;
		Year = yr;
	}

	public override string ToString()
	{
		return string.Format("{0} {1:F2} {2:D}", Name, Rating, Year);
	}
}