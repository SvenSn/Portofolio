using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Factories;
using CadeaubonProject.Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Tests
{
    public class CadeaubonTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]

        public void Cadeaubon_Constructor_GeldigePrijs(decimal prijs)
        {
            // Arrange
            var id = Guid.NewGuid();
            var thema = ThemaType.Verjaardag;
            var datum = DateTime.Now;

            // Act
            var bon = new Cadeaubon(id, prijs, thema, datum);

            // Assert
            Assert.Equal(id, bon.CadeaubonId);
            Assert.Equal(prijs, bon.Saldo);
            Assert.Equal(thema, bon.Thema);
            Assert.Equal(datum, bon.Datum);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        [InlineData(-25)]
        public void Cadeaubon_Constructor_OngeldigePrijs(decimal prijs)
        {
            //Arrange
            var id = Guid.NewGuid();
            var thema = ThemaType.Verjaardag;
            var datum = DateTime.Now;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Cadeaubon(id, prijs, thema, datum));
        }

        [Fact]
        public void Cadeaubon_IsGeldig_MetDatumBinnenJaar_GeeftTrue()
        {
            // Arrange
            var bon = new Cadeaubon(Guid.NewGuid(), 25m, ThemaType.Verjaardag, DateTime.Now.AddMonths(-3));

            // Act
            var resultaat = bon.IsGeldig(DateTime.Now.AddMonths(-3));

            // Assert
            Assert.True(resultaat);
        }

        [Fact]
        public void Cadeaubon_IsGeldig_MetDatumLangerDanJaar_GeeftFalse()
        {
            // Arrange
            var bon = new Cadeaubon(Guid.NewGuid(), 25m, ThemaType.Verjaardag, DateTime.Now.AddMonths(-11));

            // Simuleer een oude datum
            var oudeDatum = DateTime.Now.AddYears(-2);

            // Act
            var resultaat = bon.IsGeldig(oudeDatum);

            // Assert
            Assert.False(resultaat);
        }
    }
    
}

