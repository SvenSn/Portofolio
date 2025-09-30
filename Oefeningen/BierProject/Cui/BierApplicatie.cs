using Domein;
using System;

namespace Cui
{
	public class BierApplicatie
	{

		private readonly DomeinController _domeinController;

		public BierApplicatie(DomeinController dc)
		{
			_domeinController = dc;
		}

		public void Run()
		{
			//Alles gebeurt adhv de gegeven BierMapper
			//Bereken het aantal bieren die minstens 8 graden hebben
			Console.WriteLine("======================================================");
			Console.WriteLine("Bereken het aantal bieren die minstens 8 graden hebben");

			Console.WriteLine("Aantal bieren van minstens 8 graden:" + _domeinController.GeefAantalBierenMetMinAlcoholPercentage(8));

			//Maak een lijst met alle bieren van minstens 8 graden
			Console.WriteLine("======================================================");
			Console.WriteLine("Maak een lijst met alle bieren van minstens 8 graden");
			_domeinController.GeefLijstAlleBierenMetMinAlcoholPercentage(8).ForEach(bier => Console.WriteLine(bier));

			//Enkel namen van bieren laten zien
			Console.WriteLine("======================================================");
			Console.WriteLine("Enkel namen van bieren laten zien");
			Console.WriteLine(_domeinController.GeefNamenBieren());


			//Bier met hoogst aantal graden
			Console.WriteLine("======================================================");
			Console.WriteLine("Bier met hoogste aantal graden");
			Console.WriteLine("Bier met hoogste aantal graden: " + _domeinController.GeefBierMetHoogsteAlcoholPercentage());

			//Bier met laagst aantal graden
			Console.WriteLine("======================================================");
			Console.WriteLine("Bier met laagst aantal graden");
			Console.WriteLine("Bier met laagste aantal graden: " + _domeinController.GeefBierMetLaagsteAlcoholPercentage());

			/*Zorg ervoor dat het resultaat gesorteerd wordt op alcoholgehalte van hoog naar laag, 
			 en bij gelijk aantal graden op naam (alfabetisch).
			 */
			Console.WriteLine("======================================================");
			Console.WriteLine("resultaat op alcoholgehalte van hoog naar laag, dan op naam");
			_domeinController.GeefGeordendOpAlcoholGehalteEnNaam().ForEach(Console.WriteLine);

			//Alle brouwerijen
			Console.WriteLine("======================================================");
			Console.WriteLine("Alle brouwerijen");
			Console.WriteLine(_domeinController.GeefAlleNamenBrouwerijen());
			//Alle brouwerijen die het woord "van" bevatten
			Console.WriteLine("======================================================");
			Console.WriteLine("Alle brouwerijen die het woord \"van\" bevatten");
			Console.WriteLine(_domeinController.GeefAlleNamenBrouwerijenMetWoord("van"));

			//Bieren per soort
			Console.WriteLine("======================================================");
			Console.WriteLine("Alle bieren per soort");
			Console.WriteLine(_domeinController.OpzettenOverzichtBierenPerSoort());

			//Aantal bieren per soort
			Console.WriteLine("======================================================");
			Console.WriteLine("Aantal bieren per soort");
			Console.WriteLine(_domeinController.OpzettenAantalBierenPerSoort());
		}
	}
}