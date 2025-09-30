using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Tests;

public class KlantTests
{

    [Theory]
    [InlineData("sven", "sven")]
    [InlineData("Liam", "Liam")]
    [InlineData("Dusty","Dusty")]
    [InlineData("Jordan", "Jordan")]

    public void Test_Constructor_Voornaam_GeldigdeWaarden(string voornaam,string expectedResult)
    {
        Klant klant = new Klant(voornaam,"test123","abc@gmail.com");

        Assert.Equal(expectedResult, klant.Voornaam);
    }



    [Theory]
    [InlineData("")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData(null)]

    public void Test_Constructor_Voornaam_OnGeldigdeWaarden_Exception(string voornaam)
    {
        
        Assert.Throws<ArgumentNullException>(() => new Klant(voornaam, "test123", "abc@gmail.com"));
    }

    [Theory]
    [InlineData("Kaas","Kaas")]
    [InlineData("Van Basten","Van Basten")]
    [InlineData("Kane", "Kane")]
    [InlineData("Mbappe", "Mbappe")]

    public void Test_Constructor_Achternaam_GeldigeWaarden(string achternaam,string expectedresult)
    {
        //act

        Klant klant = new Klant("Sven",achternaam,"abc.hotmail.com");


        Assert.Equal(expectedresult,klant.Achternaam);
    }



    [Theory]
    [InlineData("")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData(null)]

    public void Test_Constructor_Achternaam_OnGeldigdeWaarden_Exception(string achternaam)
    {

        Assert.Throws<ArgumentNullException>(() => new Klant("test123", achternaam, "abc@gmail.com"));
    }



    [Theory]
    [InlineData("j5xq92@gmail.com", "j5xq92@gmail.com")]
    [InlineData("t9hrwz@yahoo.com", "t9hrwz@yahoo.com")]
    [InlineData("z8fpt3@outlook.com", "z8fpt3@outlook.com")]
    [InlineData("k2mqlb@hotmail.com", "k2mqlb@hotmail.com")]

    public void Test_Constructor_Email_GeldigeWaarden(string email, string expectedresult)
    {
        
        Klant klant = new Klant("Sven", "Van Basten", email);
        
        Assert.Equal(expectedresult, klant.Email);
    }

    [Theory]
    [InlineData("")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData(null)]

    public void Test_Constructor_Email_OnGeldigdeWaarden_Exception(string email)
    {

        Assert.Throws<ArgumentNullException>(() => new Klant("sven", "Mbappe", email));
    }
}
