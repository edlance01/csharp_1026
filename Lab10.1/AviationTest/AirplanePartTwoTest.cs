using NTier.Aviation;
using Moq;

namespace AviationTest
{
    public class AirplanePartTwoTest
    {
        private AirplanePart _airplanePart;

        [SetUp]
        public void Setup()
        {
           var airplanePart = new Mock<AirplanePart>();
            _airplanePart = airplanePart.Object;
        }

        [Test]
        public void ValidPartNumberSucceeds()
        {
            _airplanePart.PartNumber = "12345";
            Assert.That(_airplanePart.PartNumber, Is.EqualTo("12345"));
        }

        [Test]
        public void NullPartNumberFails()
        {
            Assert.Throws<NTier.Aviation.PartNumberInvalidFormatException>(() => _airplanePart.PartNumber = null);
        }

        [Test]
        public void EmptyPartNumberFails()
        {
            Assert.Throws<NTier.Aviation.PartNumberInvalidFormatException>(() => _airplanePart.PartNumber = "");
        }
       
        [Test]
        public void BlankPartNumberFails()
        {
            Assert.Throws<NTier.Aviation.PartNumberInvalidFormatException>(() => _airplanePart.PartNumber = " ");
        }

        [Test]
        public void PartNumberWithQuestionMarkFails()
        {
            Assert.Throws<NTier.Aviation.PartNumberInvalidFormatException>(() => _airplanePart.PartNumber = "12?45");
        }

        [Test]
        public void PartNumberWithQuestionMarkAtStartFails()
        {
            Assert.Throws<NTier.Aviation.PartNumberInvalidFormatException>(() => _airplanePart.PartNumber = "?2345");
        }

        public void PartNumberWithQuestionMarkAtEndFails()
        {
            Assert.Throws<NTier.Aviation.PartNumberInvalidFormatException>(() => _airplanePart.PartNumber = "1234?");
        }

        public void PartNumberWithStarFails()
        {
            Assert.Throws<NTier.Aviation.PartNumberInvalidFormatException>(() => _airplanePart.PartNumber = "12*45");
        }

        public void PartNumberWithStarAtStartFails()
        {
            Assert.Throws<NTier.Aviation.PartNumberInvalidFormatException>(() => _airplanePart.PartNumber = "*2345");
        }

        [Test]
        public void NegativePriceFails()
        {
            Assert.Throws<ArgumentException>(() => _airplanePart.Price = -1.0);
        }

        [Test]
        public void ZeroPriceSucceeds()
        {
            _airplanePart.Price = 0.0;
            Assert.That(_airplanePart.Price, Is.EqualTo(0.0));
        }

        [Test]
        public void PositivePriceSucceeds()
        {
            _airplanePart.Price = 1.0;
            Assert.That(_airplanePart.Price, Is.EqualTo(1.0));
        }


    }

    // NOTE - no need to build this out
    //public class MockAirplanePart : AirplanePart
    //{
    //    //    public MockAirplanePart(string partNumber, double price, string? description = null)
    //    //{
    //    //    PartNumber = partNumber;
    //    //    Price = price;
    //    //    Description = description;
    //    //}



    //}
   
}
