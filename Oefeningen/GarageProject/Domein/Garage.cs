using System;
using System.Collections.Generic;
using System.Linq;

namespace Domein
{
	public class Garage
	{
		private IAutoRepository _autoRepo;
		private IOnderhoudRepository _onderhoudRepo;

		private Dictionary<string, Auto> _autoDictionary;
		private Dictionary<string, List<Onderhoud>> _autoOnderhoudDictionary;

		public Garage(IAutoRepository autoRepo, IOnderhoudRepository onderhoudRepo)
		{
			_autoRepo = autoRepo;
			_onderhoudRepo = onderhoudRepo;

			InitGarage();
		}

		private void InitGarage()
		{
			// Stap 1: List<Auto> inlezen 
			List<Auto> autoList = _autoRepo.GeefAutos();

			// Schrijf de inhoud van de lijst (met dubbels) als controle naar het scherm.
			// Dit mag eigenlijk niet binnen het domein, we doen het enkel ter controle
			Console.WriteLine("STAP 1 - Originele lijst met dubbels");

			autoList.ForEach(a => Console.WriteLine(a));

            // Omzetten naar een set (dubbels worden automatisch verwijderd)

			HashSet<Auto> autoSet = new HashSet<Auto>(autoList);	

            // Schrijf de inhoud van de set als controle naar het scherm.
            // Dit mag eigenlijk niet binnen het domein, we doen het enkel ter controle
            Console.WriteLine("\nSTAP 1 - Set van autos");

            foreach (var item in autoSet)
            {
				Console.WriteLine(item);
            }

			// Haal de dubbels uit de lijst van autos.
			var gefilterdeAuto = autoList
				.Distinct();


            // Schrijf de inhoud van de lijst (nu zonder dubbels) als controle naar het scherm.
            // Dit mag eigenlijk niet binnen het domein, we doen het enkel ter controle
            Console.WriteLine("\nSTAP 1 - Lijst nu zonder dubbels");

			gefilterdeAuto.ToList().ForEach(a => Console.WriteLine(a));	

            // Stap 2: maak op basis van deze lijst een dictionary van auto's: volgens nummerplaat
            // Sla deze op in een attribuut voor later.
            _autoDictionary = gefilterdeAuto
				.ToDictionary(a => a.Nummerplaat, a => a);

            // Schrijf de inhoud van de Dictionary als controle naar het scherm.
            // Dit mag eigenlijk niet binnen het domein, we doen het enkel ter controle
            Console.WriteLine("\nSTAP 2 - Dictionary Nummerplaat -> Auto");

            foreach (var item in _autoDictionary)
            {
				Console.WriteLine(item.Key + item.Value);
            }

            // Stap 3: Onderhoud inlezen

            // Schrijf de inhoud van de lijst als controle naar het scherm.
            // Dit mag eigenlijk niet binnen het domein, we doen het enkel ter controle
            Console.WriteLine("\nSTAP 3 : ONDERHOUDLijst ");

			// Stap 4: Sorteer de lijst van onderhoudsbeurten

			// Schrijf de inhoud van de lijst als controle naar het scherm.
			// Dit mag eigenlijk niet binnen het domein, we doen het enkel ter controle
			Console.WriteLine("\nSTAP 4");

			// Stap 5 (optioneel)
			// Koppel de aangrenzende onderhoudsbeurten aan elkaar.

			// Schrijf de inhoud van de lijst als controle naar het scherm.
			// Dit mag eigenlijk niet binnen het domein, we doen het enkel ter controle


			// Stap 6: Maak een dictionary van onderhoudsbeurten volgens nummerplaat
			// Sla deze op in een attribuut voor later.

			// Schrijf de inhoud van de dictionary als controle naar het scherm.
			// Dit mag eigenlijk niet binnen het domein, we doen het enkel ter controle
			Console.WriteLine("\nSTAP 6");
		}

		private Dictionary<string, List<Onderhoud>> OmzettenNaarOnderhoudDictionary(List<Onderhoud> onderhoudLijst)
		{
            throw new NotImplementedException();
		}

		public string ConvertAutoDictionaryToString()
		{
            throw new NotImplementedException();
        }

		private string ConvertOnderhoudsLijstToString(List<Onderhoud> l)
        {
            throw new NotImplementedException();
        }

		public string ConvertAutoOnderhoudDictionaryToString()
		{
            throw new NotImplementedException();
        }
	}

}