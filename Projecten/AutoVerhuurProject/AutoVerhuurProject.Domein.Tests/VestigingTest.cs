using AutoVerhuurProject.Domein.Models;
using System.Security.Cryptography.X509Certificates;

namespace AutoVerhuurProject.Domein.Tests;

public class VestigingTest
{

    [Theory]
    [InlineData("Schiphol", "Schiphol")]
    [InlineData("Charles de Gaulle", "Charles de Gaulle")]
    [InlineData("El Prat", "El Prat")]
    [InlineData("Dubai International", "Dubai International")]


    public void Test_Constructor_Luchthaven_GeldigeWaarden(string luchthaven,string expectedResult)
    {
        Vestiging vestiging = new Vestiging(luchthaven, "test123", "1118 CP", "Amsterdam", "Nederland");


        Assert.Equal(expectedResult, vestiging.LuchthavenVestiging);
    }



    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("\t")]
    [InlineData("\n")]


    public void Test_Constructor_Luchthaven_OnGeldigeWaarden_Exception(string luchthaven)
    {

        Assert.Throws<ArgumentNullException>(() => new Vestiging(luchthaven, "test123", "1118 CP", "Amsterdam", "Nederland"));
    }


    [Theory]
    [InlineData("Evert van de Beek straat", "Evert van de Beek straat")]
    [InlineData("Rue Des Halles", "Rue Des Halles")]
    [InlineData("Carrtera del Prat", "Carrtera del Prat")]
    [InlineData("Avenido de la hispanidad", "Avenido de la hispanidad")]

    public void Test_Constructor_Straat_GeldigeWaarden(string straat , string expectedResult)
    {

        Vestiging v1 = new Vestiging("Schiphol",straat,"1200","Amsterdam","Nederland");

        Assert.Equal(expectedResult, v1.StraatVestiging);

    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("\t")]
    [InlineData("\n")]

    public void Test_Constructor_Straat_OnGeldigeWaarden_Exception(string straat)
    {

        Assert.Throws<ArgumentNullException>(() => new Vestiging("Schiphol", straat, "1200", "Amsterdam", "Nederland"));

    }

    [Theory]
    [InlineData("1200 CP", "1200 CP")]
    [InlineData("9270", "9270")]
    [InlineData("2000", "2000")]
    [InlineData("8300 TI", "8300 TI")]

    public void Test_Constructor_Postcode_GeldigeWaarden(string postcode,string expectedResult)
    {
        Vestiging vest = new Vestiging("Schiphol","test123 straat",postcode,"Amsterdam","Nederland");

        Assert.Equal(expectedResult,vest.PostcodeVestiging);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("\t")]
    [InlineData("\n")]

    public void Test_Constructor_Postcode_OnGeldigeWaarden_Exception(string postcode)
    {
        Assert.Throws<ArgumentNullException>(() => new Vestiging("Schiphol", "test123 straat", postcode, "Amsterdam", "Nederland"));
    }


    [Theory]
    [InlineData("Amsterdam", "Amsterdam")]
    [InlineData("Brussel", "Brussel")]
    [InlineData("Barcelona", "Barcelona")]
    [InlineData("Madrid", "Madrid")]


    public void Test_Constructor_Plaats_GeldigeWaarden(string plaats, string expectedResult)
    {
        Vestiging vest = new Vestiging("Schiphol", "test123 straat", "1000", plaats, "Nederland");


        Assert.Equal(expectedResult,vest.PlaatsVestiging);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("\t")]
    [InlineData("\n")]

    public void Test_Constructor_Plaats_OnGeldigeWaarden_Exception(string plaats)
    {
        Assert.Throws<ArgumentNullException>(() => new Vestiging("Schiphol", "test123 straat", "1000", plaats, "Nederland"));
    }


    [Theory]
    [InlineData("Belgie", "Belgie")]
    [InlineData("Nederland", "Nederland")]
    [InlineData("Spanje", "Spanje")]
    [InlineData("Duitsland", "Duitsland")]

    public void Test_Constructor_Land_GeldigeWaarden(string land, string expectedResult)
    {
        Vestiging vest = new Vestiging("Schiphol", "test123 straat", "1000", "Amsterdam", land);


        Assert.Equal(expectedResult, vest.LandVestiging);
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("\t")]
    [InlineData("\n")]

    public void Test_Constructor_Land_OnGeldigeWaarden_Exception(string land)
    {
        Assert.Throws<ArgumentNullException>(() => new Vestiging("Schiphol", "test123 straat", "1000", "Amsterdam", land));
    }
}
