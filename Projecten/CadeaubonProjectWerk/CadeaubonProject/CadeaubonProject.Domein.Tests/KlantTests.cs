using CadeaubonProject.Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Tests
{
    public class KlantTests
    {
        [Fact]
        public void Klant_MetGeldigeGegevens_MaaktObject()
        {
            var klantId = Guid.NewGuid();
            var klant = new Klant(klantId, "test@mail.com", "wachtwoord", "Astrid", "Staessens");

            Assert.Equal(klantId, klant.KlantId);
            Assert.Equal("test@mail.com", klant.Email);
            Assert.Equal("wachtwoord", klant.Passwoord);
            Assert.Equal("Astrid", klant.Voornaam);
            Assert.Equal("Staessens", klant.Achternaam);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("testmail.com")] // geen @
        [InlineData(null)]
        public void Klant_MetOngeldigeEmail_GooitArgumentException(string email)
        {
            Assert.Throws<ArgumentException>(() =>
                new Klant(Guid.NewGuid(), email, "wachtwoord", "Astrid", "Staessens"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Klant_MetLegeVoornaam_GooitArgumentException(string voornaam)
        {
            Assert.Throws<ArgumentException>(() =>
                new Klant(Guid.NewGuid(), "test@mail.com", "wachtwoord", voornaam, "Staessens"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("123")]
        [InlineData("abcde")]
        [InlineData(null)]
        public void Klant_MetOngeldigWachtwoord_GooitArgumentException(string wachtwoord)
        {
            Assert.Throws<ArgumentException>(() =>
                new Klant(Guid.NewGuid(), "test@mail.com", wachtwoord, "Astrid", "Staessens"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Klant_MetLegeAchternaam_GooitArgumentException(string achternaam)
        {
            Assert.Throws<ArgumentException>(() =>
                new Klant(Guid.NewGuid(), "test@mail.com", "wachtwoord", "Astrid", achternaam));
        }


    }
}
