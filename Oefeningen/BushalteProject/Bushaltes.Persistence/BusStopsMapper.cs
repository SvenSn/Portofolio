using BusStops.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace BusStops.Persistence
{
    public class BusStopsMapper : IBusStopsRepository
    {
        private List<BusStop> _bushaltes;
        public BusStopsMapper()
        {
            // If the .json file is not found! (e.g. you get an exception...)
            // Open Project > Properties > Configuration Properties > Debugging.
            // Change The Working Directory entry to $(SolutionDir)
            // Place your json file next to your project .sln file

            _bushaltes = JsonConvert.DeserializeObject<List<BusStop>>(File.ReadAllText(@"bushaltes-gent-short.json"));
        }

        public void GetAantalHaltesPerGemeente()
        {
            var result = _bushaltes
                .GroupBy(a => a.Municipality)
                .Select(g => new
                {
                    Gemeente = g.Key,
                    aantalhaltes = g.Count()
                });

            foreach (var gemeente in result)
            {
                Console.WriteLine($"{gemeente.Gemeente} heeft : {gemeente.aantalhaltes} aantal haltes");
            }
        }

        public void GetAllHalted()
        {
            _bushaltes.ForEach(a => Console.WriteLine(a.ToString()));
        }

        public void GetAllHalteNamen()
        {
            _bushaltes.ForEach(a => Console.WriteLine(a.StopName));
        }

        public void GetAllToegankelijkheden()
        {
            var toegankelijkheden = _bushaltes
                .Where(h => h.ToegankelijkHeden != null)
                .Select(h => h.ToegankelijkHeden)
                .Distinct()
                .ToList();

           toegankelijkheden.ForEach(t => Console.WriteLine(t));
        }

        public void GetGemeenteMetMeesteHaltes()
        {
            BusStop result = _bushaltes
                .OrderByDescending(a => a.StopName.Count())
                .First();
            
            Console.WriteLine($"{result.ToString()}  ,aantal haltes: {result.StopName.Count()}");

        }


        public void GetGemeenteNamenAlfabetischDistinctw()
        {
            var result = _bushaltes
                .OrderBy(a => a.Municipality)
                .Select(a => a.Municipality)
                .Distinct();

            foreach (var bushalte in result)
            {
                Console.WriteLine(bushalte);
            }
        }

        public void GetHaltenamenGemeente(string gemeente)
        {
            string goedeGemeente = gemeente.ToLower().Trim();

            var result = _bushaltes
                .Where(b => b.Municipality.ToLower().Trim() == goedeGemeente)
                .Select(b => b.StopName);


            foreach (var stopnaam in result)
            {
                Console.WriteLine($"{stopnaam}");
            }

        }

        public void GetHaltesZonderToegankelijkheden()
        {
            var result = _bushaltes
                 .Where(a => a.ToegankelijkHeden.ToString() == "" || a.ToegankelijkHeden == null);

            foreach (var bushalte in result)
            {
                Console.WriteLine($"{bushalte.ToString()}");
            }
        }

        public void GetLongestStopname()
        {
            var filter = _bushaltes
                .Where(b => !string.IsNullOrWhiteSpace(b.StopName))
                .ToList();

            var longestName = filter
                .OrderByDescending(b => b.StopName.Length)
                .Select (b => b.StopName)
                .FirstOrDefault();

            Console.WriteLine(longestName);
        }

        public void GetSharedHaltes()
        {


            Console.WriteLine("Geef uw 1ste gemeente in:");
            string gemeente1 = Console.ReadLine();

            Console.WriteLine("Geef uw 2de gemeente in:");
            string gemeente2 = Console.ReadLine();


            var haltesGemeente1 = _bushaltes
                .Where(b => b.Municipality == gemeente1)
                .Select(b => b.StopName);



            var haltesGemeente2 = _bushaltes
                .Where(b => b.Municipality == gemeente2)
                .Select(b => b.StopName);

            var gedeeldeHaltes = haltesGemeente1.Intersect(haltesGemeente2);




            foreach (var halte in gedeeldeHaltes)
            {
                Console.WriteLine(halte);
            }


        }

        public void GetSharedHaltesGemeentes()
        {
            var sharedhaltes = _bushaltes
                .GroupBy(b => b.StopName)
                .Where(g => g.Select(h => h.Municipality).Distinct().Count() > 1)
                .Select(g => new
                {
                    halte = g.Key,
                    gemeente = g.Select(h => h.Municipality)
                });

            foreach (var halte in sharedhaltes)
            {
               Console.WriteLine($"{halte.halte} komt voor in  :{string.Join(", ",halte.gemeente)}");
            }

        }

        public void GetUniqueHaltesGemeente()
        {
            Console.WriteLine("Geef een gemeente in: ");
            string gemeente1 = Console.ReadLine().ToLower().Trim();

            var uniekeHaltes = _bushaltes
                .Where(b => b.Municipality.ToLower().Trim() == gemeente1)
                .Select(b => b.StopName)
                .Distinct();

            var allehaltes = _bushaltes
               .Where(b => b.Municipality.ToLower().Trim() != gemeente1)
               .Select(b => b.StopName)
               .Distinct();
                
            var result = uniekeHaltes.Except(allehaltes).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
