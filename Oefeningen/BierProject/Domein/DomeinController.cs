using System;
using System.Collections.Generic;
using System.Linq;

namespace Domein
{

	public class DomeinController
	{

		private readonly BierWinkel _bierWinkel;

		public DomeinController(IBierRepository bierRepo)
		{
			_bierWinkel = new BierWinkel(bierRepo);
		}

		public int GeefAantalBierenMetMinAlcoholPercentage(double percentage)
		{
			return _bierWinkel.GeefAantalBierenMetMinAlcoholPercentage(percentage);	
        }

		public List<string> GeefLijstAlleBierenMetMinAlcoholPercentage(double percentage)
		{
			return _bierWinkel.GeefAlleBierenMetMinAlcoholPercentage(percentage)
				.Select(b => b.ToString()).ToList();
        }

		public string GeefNamenBieren()
		{
			return _bierWinkel.GeefNamenBieren()
				.Aggregate((a , b) => a + "\n" + b);
        }

		public string GeefAlleNamenBrouwerijen()
		{
			return _bierWinkel.GeefAlleNamenBrouwerijen()
				.Aggregate((a, b) => a + "\n" + b);
        }

		public List<string> GeefAlleBieren()
		{
			return _bierWinkel.GeefBieren()
				.Select(b => b.ToString()).ToList();	
        }

		public string GeefBierMetHoogsteAlcoholPercentage()
		{
			return _bierWinkel.GeefBierMetHoogsteAlcoholPercentage().ToString();
        }

		public string GeefBierMetLaagsteAlcoholPercentage()
		{
			return _bierWinkel.GeefBierMetLaagsteAlcoholPercentage().ToString();
        }

		public List<string> GeefGeordendOpAlcoholGehalteEnNaam()
		{
			return _bierWinkel.GeefGeordendOpAlcoholGehalteEnNaam()
				.Select(b => b.ToString()).ToList();

		}

		public string GeefAlleNamenBrouwerijenMetWoord(string woord)
		{
			return _bierWinkel.GeefAlleNamenBrouwerijenMetWoord(woord)
				.Aggregate((a, b) => a + "\n" + b);
        }

		public string OpzettenAantalBierenPerSoort()
		{
			return _bierWinkel.OpzettenAantalBierenPerSoort()
				.Select(kvp => $"{kvp.Key}: {kvp.Value}")
				.Aggregate((a, b) => a + "\n" + b);	
        }

		public string OpzettenOverzichtBierenPerSoort()
		{
			return _bierWinkel.OpzettenOverzichtBierenPerSoort()
				.Select(kvp => $"{kvp.Key}: {string.Join(", ", kvp.Value.Select(b => b.ToString()))}")
				.Aggregate((a, b) => a + "\n" + b);
        }
	}
}