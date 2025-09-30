namespace FitnessProject.Domein.Models;

internal class LoopInterval
{
    public int TijdsDuurIntervalSeconden { get; set; }

    public double GemiddeldeSnelheidInterval { get; set; }

    public int IntervalNr { get; private set; }

    public LoopInterval(int tijdsDuurIntervalSeconden, double gemiddeldeSnelheidInterval,int intervalNr)
    {
        TijdsDuurIntervalSeconden = tijdsDuurIntervalSeconden;
        GemiddeldeSnelheidInterval = gemiddeldeSnelheidInterval;
        IntervalNr = intervalNr;
    }
}
