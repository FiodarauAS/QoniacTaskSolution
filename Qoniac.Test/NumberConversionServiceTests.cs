using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Qoniac.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Qoniac.Tests
{
    [TestFixture]
    public class NumberConversionServiceTests
    {
        private readonly INumberConversionService _converter;
        public NumberConversionServiceTests()
        {
            _converter = new NumberConversionService();
        }

        [Test]
        public async Task ConvertZeroDollars_ReturnsZeroDollarsInWords()
        {
            //Arrange
            double value = 0;
            string expectedResult = "zero dollars";

            //Act
            string actualValue = await _converter.GetConvertedNumber(value);

            //Assert
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public async Task ConvertOneDollar_ReturnsOneDollarInWords()
        {
            //Arrange
            double value = 1;
            string expectedResult = "one dollar";

            //Act            
            string actualValue = await _converter.GetConvertedNumber(value);

            //Assert
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public async Task Convert25Dollars10Cents_Returns25Dollars10CentsInWords()
        {
            //Arrange
            double value = 25.1;
            string expectedResult = "twenty-five dollars and ten cents";

            //Act
            string actualValue = await _converter.GetConvertedNumber(value);

            //Assert
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public async Task Convert1Cent_Returns1CentInWords()
        {
            //Arrange
            double value = 0.01;
            string expectedResult = "one cent";

            //Act
            string actualValue = await _converter.GetConvertedNumber(value);

            //Assert
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public async Task Convert45100Dollars_Returns45100DollarsInWords()
        {
            //Arrange
            double value = 45100;
            string expectedResult = "forty-five thousand one hundred dollars";

            //Act
            string actualValue = await _converter.GetConvertedNumber(value);

            //Assert
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public async Task Convert999MillionDollars_Returns999MillionDollarsInWords()
        {
            //Arrange
            double value = 999999999.99;
            string expectedResult = "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents";

            //Act
            string actualValue = await _converter.GetConvertedNumber(value);

            //Assert
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public async Task ConvertNegativeNumber_ReturnsWrongFormat()
        {
            //Arrange
            double value = -25;
            string expectedResult = "The value is out of range.";

            //Act
            string actualValue = await _converter.GetConvertedNumber(value);

            //Assert
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public async Task ConvertNotInRangeCentsNumber_ReturnsValueOutOfRange()
        {
            //Arrange
            double value = 25.9876;
            string expectedResult = "The value is out of range.";

            //Act
            string actualValue = await _converter.GetConvertedNumber(value);

            //Assert
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public async Task ConvertNotInRangeDollarsNumber_ReturnsValueOutOfRange()
        {
            //Arrange
            double value = 1000000000;
            string expectedResult = "The value is out of range.";

            //Act
            string actualValue = await _converter.GetConvertedNumber(value);

            //Assert
            Assert.AreEqual(expectedResult, actualValue);
        }
    }
}
