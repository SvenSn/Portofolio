using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Tests;

public class AutoTests
{
    [Theory]
    [InlineData("1-ABC-123")]
    [InlineData("1-JGH-563")]
    [InlineData("2-WED-781")]
    [InlineData("1-XYH-123")]

    public void Test_Constructor_Nummerplaat_GeldigeWaaren(string nummerplaat)
    {
        Auto auto = new Auto(nummerplaat, "Tesla", 2, Auto.EMotorType.Elektrisch);


        Assert.Equal(nummerplaat, auto.Nummerplaat);
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("\n")]
    [InlineData("\t")]

    public void Test_Constructor_Nummerplaat_OnGeldigeWaaren(string nummerplaat)
    {
        Assert.Throws<ArgumentNullException>(() => new Auto(nummerplaat, "Volvo", 4, Auto.EMotorType.Diesel));
    }



    [Theory]
    [InlineData("Tesla","Tesla")]
    [InlineData("Volvo","Volvo")]
    [InlineData("Aston martin", "Aston martin")]
    [InlineData("Lada", "Lada")]

    public void Test_Constructor_Model_GeldigeWaaren(string model,string expectedmodel)
    {
        Auto auto = new Auto("1-AFK-788", model, 4, Auto.EMotorType.Elektrisch);


        Assert.Equal(model, auto.Model);
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("\t")]
    [InlineData("\n")]

    public void Test_Constructor_Model_OnGeldigeWaaren_Exception(string model)
    {
        Assert.Throws<ArgumentNullException>(() => new Auto("1-ABC-782", model, 4, Auto.EMotorType.Benzine));
    }

    [Theory]
    [InlineData(2,2)]
    [InlineData(9,9)]
    [InlineData(4,4)]
    [InlineData(8,8)]

    public void Test_Constructor_Zitplaatsen_GeldigdeWaarden(int zitplaatsen, int expectedresult)
    {
        Auto auto = new Auto("1-GGG-888", "VOLVO", zitplaatsen, Auto.EMotorType.Elektrisch);

        Assert.Equal(expectedresult, auto.Zitplaatsen);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(-5)]
    [InlineData(10)]
    [InlineData(50)]
    public void Test_Constructor_Zitplaatsen_OnGeldigdeWaarden_Exception(int zitplaatsen)
    {


        Assert.Throws<ArgumentOutOfRangeException>(() => new Auto("1-GGG-888", "VOLVO", zitplaatsen, Auto.EMotorType.Elektrisch));
    }


    //enum nog checken , vraag stellen ....

}
