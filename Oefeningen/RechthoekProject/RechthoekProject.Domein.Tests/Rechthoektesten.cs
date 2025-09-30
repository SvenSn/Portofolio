using Rechthoek.Domein;

namespace RechthoekProject.Domein.Tests;

public class Rechthoektesten
{
    [Theory]
    [InlineData(1, 1.0)]
    [InlineData(50.4, 50.4)]
    [InlineData(0.01, 0.01)]
    [InlineData(200.5, 200.5)]

    public void Test_RechtHoek_Constructor_Breedte_Lengte_GeldigeWaarden(double getal, double expectedResult)
    {
        //arrange
        RechthoekKlasse r1 = new RechthoekKlasse(getal, getal);

        Assert.Equal(expectedResult, r1.Breedte);
        Assert.Equal(expectedResult, r1.Lengte);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-50.4)]
    [InlineData(-0.01)]
    [InlineData(0)]

    public void Test_Rechthoek_Constructor_Breedte_Lengte_Exception(double getal)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => (new RechthoekKlasse(getal,getal)));
    }

    [Theory]
    [InlineData(10, 5, 20,12,6)]
    [InlineData(15, 10, 50, 22.5, 15)]
   


    public void Test_Rechthoek_Schaal_GeldigeWaarden
        (double origineleBreedte,double OrigineLengte,int percentage,double verwachteBreedte,double verwachteLengte)
    {
        RechthoekKlasse r1 = new RechthoekKlasse(OrigineLengte, origineleBreedte);

        r1.Schaal(percentage);


        Assert.Equal(verwachteBreedte, r1.Breedte);
        Assert.Equal(verwachteLengte, r1.Lengte);
    }

    [Theory]
    [InlineData(101)]
    [InlineData(0)]
    [InlineData(150)]
    [InlineData(-5)]

    public void Test_Rechthoek_Schaal_OngeldigeWaarden_Exception(int percentage)
    {
        RechthoekKlasse r1 = new RechthoekKlasse(10, 10);

        Assert.Throws<ArgumentOutOfRangeException>(() => r1.Schaal(percentage));
    }


    [Theory]
    [InlineData(10,5,30)]
    [InlineData(20, 10, 60)]
    [InlineData(2, 4, 12)]
    [InlineData(15, 7, 44)]


    public void Tests_Rechthoek_GeefOmtrek_GeldigeWaarden(double breedte,double lengte,double omtrek)
    {
        RechthoekKlasse r1 = new RechthoekKlasse(lengte,breedte);

        Assert.Equal(omtrek,r1.GeefOmtrek(lengte,breedte));
    }

    [Theory]
    [InlineData(1,4,4)]
    [InlineData(4, 5, 20)]
    [InlineData(10, 40, 400)]
    [InlineData(8, 4, 32)]



    public void Tests_Rechthoek_GeefOppervlakte_GeldigeWaarden(double lengte,double breedte,double verwachteOppervlakte)
    {
        RechthoekKlasse r1 = new RechthoekKlasse(lengte, breedte);

        Assert.Equal(verwachteOppervlakte, r1.GeefOppervlakte(lengte, breedte));
    }
}
