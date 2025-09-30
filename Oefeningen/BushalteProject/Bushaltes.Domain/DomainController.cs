using System;

namespace BusStops.Domain
{
    public class DomainController
    {
        private IBusStopsRepository _repository;
        public DomainController(IBusStopsRepository repository)
        {
            _repository = repository;
        }


        public void GeefAlleHaltes()
        {
             _repository.GetAllHalted();
        }

        public void GeefAlleHalteNamen()
        {
            _repository.GetAllHalteNamen();
        }

        public void GeefAlleGemeenteNamenAlfabetisch()
        {
            _repository.GetGemeenteNamenAlfabetischDistinctw();
        }

        public void GeefHalteNamenGegevenGemeente()
        {

            Console.WriteLine("Geef een gemeente in: ");
            string gemeente = Console.ReadLine();
            _repository.GetHaltenamenGemeente(gemeente);
        }

        public void GeefHaltesZonderToegankelijkheden()
        {
            _repository.GetHaltesZonderToegankelijkheden();
        }

        public void GeefGemeenteMetMeesteHaltes()
        {
            _repository.GetGemeenteMetMeesteHaltes();
        }

        public void GeefAantalHaltesPergemeente()
        {
            _repository.GetAantalHaltesPerGemeente();
        }

        public void GeefGedeeldeHaltes()
        {
            _repository.GetSharedHaltes();
        }

        public void GeefUniekeHaltesPerGemeente()
        {
            _repository.GetUniqueHaltesGemeente();
        }

        public void GeefLangsteHaltnaam()
        {
            _repository.GetLongestStopname();
        }

        public void GeefAllesharedHaltesGemeente()
        {
            _repository.GetSharedHaltesGemeentes();
        }

        public void GeefAlleToegankelijkHeden()
        {
            _repository.GetAllToegankelijkheden();
        }
    }
}
