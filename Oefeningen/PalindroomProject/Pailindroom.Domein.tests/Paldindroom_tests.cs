using PalindroomProject;

namespace Pailindroom.Domein.tests
{
    public class Paldindroom_tests
    {
        [Theory]
        [InlineData("racecar","racecar")]
        [InlineData("kat","kat")]
        [InlineData("muis","muis")]
        [InlineData("hond","hond")]

        public void Tests_Constructor_tekst_GeldigeWaarden(string tekst , string verwachtetekst)
        {
            Palindroom pd = new Palindroom(tekst);


            Assert.Equal(verwachtetekst, pd.Tekst);
        }



        [Theory]
        [InlineData("b")]
        [InlineData("i")]
        [InlineData("c")]
        [InlineData("t")]

        public void Tests_Constructor_Tekst_OngeldigeWaarden_Exception(string tekst)
        {
            Assert.Throws<ArgumentException>(() => new Palindroom(tekst));
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        
        public void Test_Constructor_FouteWaarden_Exception(string tekst)
        {
            Assert.Throws<ArgumentException>(() => new Palindroom(tekst));
        }
    }
}
