using CadeaubonProject.Domein.Models;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace CadeaubonProject.Domein.Tests
{
    public class BestellingTests
    {
        [Theory]
        [InlineData("Kleine bon")]
        [InlineData("Bon voor verjaardag")]
        [InlineData("Kerstmisbon")]
        [InlineData("Kerstmisbon klein")]

        public void Tests_Constructor_Beschrijving_GeldigeWaarden(string beschrijving)
        {
            Bestelling bestelling = new Bestelling(Guid.NewGuid(), new Klant(Guid.NewGuid(), "test@mail.com",
                "1234", "sven", "snoeck"),beschrijving, new Cadeaubon(Guid.NewGuid(), 25, ThemaType.Nieuwjaar, DateTime.Now));

            Assert.Equal(beschrijving, bestelling.Beschrijving);
        }


        [Theory]
        [InlineData("")]
        [InlineData("\n")]
        [InlineData(null)]
        [InlineData("\t")]

        public void Tests_Constructor_Beschrijving_OngeldigdeWaarden_Exception(string beschrijving)
        {
            Assert.Throws<ArgumentException>(() => new Bestelling(Guid.NewGuid(), new Klant(Guid.NewGuid(), "test@mail.com",
                "1234", "sven", "snoeck"), beschrijving, new Cadeaubon(Guid.NewGuid(), 25, ThemaType.Nieuwjaar, DateTime.Now)));
        }
    }
}
