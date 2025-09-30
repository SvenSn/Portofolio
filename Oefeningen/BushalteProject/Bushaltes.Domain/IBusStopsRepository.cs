namespace BusStops.Domain
{
    public interface IBusStopsRepository
    {
        public void GetAllHalted();

        public void GetAllHalteNamen();

        public void GetGemeenteNamenAlfabetischDistinctw();

        public void GetHaltenamenGemeente(string gemeente);

        public void GetHaltesZonderToegankelijkheden();

        public void GetGemeenteMetMeesteHaltes();

        public void GetAantalHaltesPerGemeente();

        public void GetSharedHaltes();

        public void GetUniqueHaltesGemeente();

        public void GetLongestStopname();

        public void GetSharedHaltesGemeentes();

        public void GetAllToegankelijkheden();


    }
}
