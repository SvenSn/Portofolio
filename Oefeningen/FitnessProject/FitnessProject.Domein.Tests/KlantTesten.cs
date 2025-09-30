using FitnessProject.Domein.Models;

namespace FitnessProject.Domein.Tests;

public class KlantTesten
{
    [Theory]
    [InlineData(1,1)]
    [InlineData(5,5)]
    [InlineData(20,20)]

    public void Test_Constructor_KlantNr_GeldigeWaarden(int getal,int expectResult)
    {

        //arrange
        Klant klant = new Klant(getal);

        //act+assert
        Assert.Equal(expectResult, klant.KlantNr);

    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-5)]
    [InlineData(-100)]
    [InlineData(null)]

    public void Tests_Constructor_KlantNr_FouteWaarden_Exception(int getal)
    {
        Assert.Throws<ArgumentException>(() => new Klant(getal));
    }

}
