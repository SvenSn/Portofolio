using System;
using System.Collections.Generic;
using System.Linq;

namespace Domein
{
	public class BierWinkel
	{

		private readonly List<Bier> _bieren;
		private readonly IBierRepository _bierRepo;

		public BierWinkel(IBierRepository bierRepo)
		{
			_bierRepo = bierRepo;
			_bieren = _bierRepo.GeefBieren();
		}

		public List<Bier> GeefBieren()
		{
			return _bieren;
        }

		public int GeefAantalBierenMetMinAlcoholPercentage(double percentage)
		{
			return _bieren.Count(b => b.Alcoholgehalte >= percentage);
        }

		public List<Bier> GeefAlleBierenMetMinAlcoholPercentage(double percentage)
		{
			return _bieren.Where(b => b.Alcoholgehalte >= percentage).ToList();
		}

		public List<string> GeefNamenBieren()
		{
			return _bieren.Select(b => b.Naam).ToList();
        }

		//Bier met hoogst aantal graden
		public Bier GeefBierMetHoogsteAlcoholPercentage()
		{
			return _bieren.MaxBy(b => b.Alcoholgehalte);
		}

		//Bier met laagst aantal graden
		public Bier GeefBierMetLaagsteAlcoholPercentage()
		{
			return _bieren.MinBy(b => b.Alcoholgehalte);	
        }

		/*Zorg ervoor dat het resultaat gesorteerd wordt op alcoholgehalte van hoog naar laag, 
		 en bij gelijk aantal graden op naam (alfabetisch).
		 */
		public List<Bier> GeefGeordendOpAlcoholGehalteEnNaam()
		{
			return _bieren
				.OrderByDescending(b => b.Alcoholgehalte)
				.ThenBy(b => b.Naam)
				.ToList();
        }

		//Alle brouwerijen
		public List<string> GeefAlleNamenBrouwerijen()
		{
			return _bieren
				.Select(b => b.Brouwerij)
				.Distinct()
                .ToList();
        }

		//Alle brouwerijen die het woord "van" bevatten
		public List<string> GeefAlleNamenBrouwerijenMetWoord(string woord)
		{
			return _bieren
				.Select(b => b.Brouwerij)
				.Where(b => b.Contains("van"))
				.Distinct()
				.ToList();

        }

		public Dictionary<string, Bier> OpzettenOverzichtBierPerNaam()
		{
			return _bieren
				.ToDictionary(b => b.Naam, b => b);
		}
		
		public Dictionary<string, List<Bier>> OpzettenOverzichtBierenPerSoort()
		{
			return _bieren
				.GroupBy(b => b.Soort)
				.ToDictionary(g => g.Key, g => g.ToList());
        }

		public Dictionary<string, int> OpzettenAantalBierenPerSoort()
		{
			return _bieren
				.GroupBy(b => b.Soort)
				.ToDictionary(g => g.Key, g => g.Count());
		}
	}
}