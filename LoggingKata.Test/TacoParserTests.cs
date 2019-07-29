using System;
using Xunit;
using LoggingKata;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // Arrange
            // Act
            // Assert
        }

        [Theory]
        [InlineData("45.68888,-23.98567,Taco Bell Nashville", "Taco Bell Nashville", 45.68888, -23.98567)]
        [InlineData("67.9999,-67.8933,Taco Bell California", "Taco Bell California", 67.9999, -67.8933)]
        [InlineData("65.7,-88.43,Taco Bell ASFGJHKF", "Taco Bell ASFGJHKF", 65.7, -88.43)]
        public void ShouldParse(string str, string nameOfString, string latitudeOfString, string longitudeOfString)
        {
            // Arrange
            TacoParser taco = new TacoParser();
            Point TacoBellLocation = new Point(latitudeOfString, longitudeOfString);

            //Act
            ITrackable actual = taco.Parse(str);

            //Assert
            Assert.Equal(nameOfString, actual.Name);
            Assert.Equal(latitudeOfString, actual.Location.Latitude);
            Assert.Equal(longitudeOfString, actual.Location.Longitude);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("8889294Auburn Taco Bell, 8.33")]
        [InlineData("taco bell, birmingham, 8.9999, 9.3333")]
        [InlineData("No Latitude for taco bell ")]
        public void ShouldFailParse(string str)
        {
            // Arrange
            TacoParser incorrectParse = new TacoParser();

            // Act
            ITrackable actual = incorrectParse.Parse(str);

            // Assert
            Assert.Null(actual);
        }
    }
}
