namespace BusStops.Domain
{
    public class BusStop
    {
        public int StopNumber { get; set; }
        public string StopName { get; set; }
        public EToegankelijkHeden ToegankelijkHeden { get; }
        public string Municipality { get; set; }

        public override string ToString()
        {
            return $"{StopNumber} ,{StopName}, {ToegankelijkHeden}, {Municipality}";
        }
    }
}
