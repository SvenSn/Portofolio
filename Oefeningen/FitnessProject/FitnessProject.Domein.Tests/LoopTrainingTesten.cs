using FitnessProject.Domein.Models;

namespace FitnessProject.Domein.Tests;

public class LoopTrainingTesten
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(5, 5)]
    [InlineData(20, 20)]

    public void Test_Constructor_SessieNr_GeldigeWaarden(int getal, int expectResult)
    {

        //arrange
        LoopTraining lp = new LoopTraining(getal, DateTime.Now, 60, 13.6);

        //act+assert
        Assert.Equal(expectResult, lp.SessieNr);

    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-50)]
    [InlineData(null)]

    public void Test_Constructor_SessieNr_FoutiveWaarden_Exception(int getal)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new LoopTraining(getal, DateTime.Now, 60, 13.6));
    }


    [Theory]
    [InlineData(5,5)]
    [InlineData(60,60)]
    [InlineData(120,120)]
    [InlineData(180,180)]

    public void Tests_Constructor_TotaleTrainingsDuurSessie_GeldigeWaarden(int getal,int expectedresult)
    {
        //arrange

        LoopTraining lp = new LoopTraining(5, DateTime.Now, getal,13.6);
        //act

        //assert
        Assert.Equal(expectedresult, lp.TotaleTrainingsDuurSessieMinuten);
    }



    [Theory]
    [InlineData(4)]
    [InlineData(0)]
    [InlineData(-5)]
    [InlineData(181)]
    [InlineData(400)]

    public void Tests_Constructor_TotaleTrainingsDuurSessie_FoutiveWaarden_Exception(int getal)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new LoopTraining(5, DateTime.Now, getal, 13.6));
    }

}
