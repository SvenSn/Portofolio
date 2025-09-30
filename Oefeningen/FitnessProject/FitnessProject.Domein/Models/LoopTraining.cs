namespace FitnessProject.Domein.Models;

internal class LoopTraining
{
    private int _sessieNr;

    public int SessieNr
    {
        get { return _sessieNr; }
        set 
        {
            if (value > 0)
            {
                _sessieNr = value;

            }
            else
            {
                throw new ArgumentOutOfRangeException("SessieNr moet positief en strikt boven 0 zijn.");
            }
        }
    }


    public DateTime StartDatumSessie { get; set; }


    private int _totaleTrainingsDuurSessieMinuten;

    public int TotaleTrainingsDuurSessieMinuten
    {
        get { return _totaleTrainingsDuurSessieMinuten; }
        set 
        { 
            if (value >= 5 && value <= 180)
            {
                _totaleTrainingsDuurSessieMinuten = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("De trainingsessie moet minstens 5 minuten duren en maximum 3 uur");
            }
        }
    }

    private double _gemiddeldeSnelheidLooptraining;

    public double GemiddeldeSnelheidLoopTraining
    {
        get { return _gemiddeldeSnelheidLooptraining; }
        set { _gemiddeldeSnelheidLooptraining = value; }
    }


    private List<LoopInterval> _loopIntervallen;


    public LoopTraining(int sessieNr, DateTime startDatumSessie, int totaleTrainingsDuurSessieMinuten, double gemiddeldeSnelheidLoopTraining)
    {
        SessieNr = sessieNr;
        StartDatumSessie = startDatumSessie;
        TotaleTrainingsDuurSessieMinuten = totaleTrainingsDuurSessieMinuten;
        GemiddeldeSnelheidLoopTraining = gemiddeldeSnelheidLoopTraining;
        
    }

}
