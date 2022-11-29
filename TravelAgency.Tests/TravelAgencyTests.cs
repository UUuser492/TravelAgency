using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Moq;

namespace TravelAgency.Tests
{
    public class TravelAgencyTests
    {
        [Fact]
        public void Return_List_Of_Countries()
        {
            List<Offer> offers = new List<Offer>
            {
                new Offer(8, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(1,"Germany")) , new TravelType(1 ,"Healthy")),               
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Uk")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Germany")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Germany")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Uk")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Ukraine")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Italia")), new TravelType(2 , "Extrem")),
            };

            List<string> expected = new List<string>
            {
                  "Germany",
                  "Uk",
                  "Ukraine",
                  "Italia"
            };

            var mockOffers = new Mock<IGetOffer>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency( mockOffers.Object);
          
            //Assert
            Assert.Equal(expected, Agency.GetCountries());
        }

        [Fact]
        public void Return_List_Of_Countries_False()
        {
            List<Offer> offers = new List<Offer>
            {
                new Offer(8, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(1,"Germany")) , new TravelType(1 ,"Healthy")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Uk")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Germany")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Germany")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Uk")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Albania")), new TravelType(2 , "Extrem")),
            };

            List<string> expected = new List<string>
            {
                  "Germany",
                  "Uk",
                  "Maldive",

            };

            var mockOffers = new Mock<IGetOffer>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.NotEqual(expected, Agency.GetCountries());
        }

        [Fact]
        public void Return_List_Of_Travel_Types()
        {
            List<Offer> offers = new List<Offer>
            {
                new Offer(8, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(1,"Germany")) , new TravelType(1 ,"Healthy")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Uk")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Germany")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Germany")), new TravelType(2 , "Eazy")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Uk")), new TravelType(2 , "Extrem")),

            };

            List<string> expected = new List<string>
            {
                  "Healthy",
                  "Extrem",
                  "Eazy",                   
            };

            var mockOffers = new Mock<IGetOffer>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.Equal(expected, Agency.GetTravelType());
        }

        [Fact]
        public void Return_List_Of_Travel_Types_False()
        {
            List<Offer> offers = new List<Offer>
            {
                new Offer(8, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(1,"Germany")) , new TravelType(1 ,"Healthy")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Uk")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Germany")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Germany")), new TravelType(2 , "Eazy")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Uk")), new TravelType(2 , "Extrem")),
                new Offer(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countrie(2,"Uk")), new TravelType(2 , "Extrem")),

            };

            List<string> expected = new List<string>
            {
                  "Healthy",
                  "Extrem",
                  "Eazy",
                  "Recovery"
            };

            var mockOffers = new Mock<IGetOffer>();
            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.NotEqual(expected, Agency.GetTravelType());
        }

        [Fact]
        public void SortTravel_Incr_ForHotelPrice_ReturnListHotel()
        {
            var Offer1 = new Offer(8, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1500, "1", "Plaza", new Countrie(1, "Germany")), new TravelType(1, "Healthy"));
            var Offer2 = new Offer(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1500, "2", "Qwerty", new Countrie(2, "Uk")), new TravelType(2, "Extrem"));
            var Offer3 = new Offer(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1200, "3", "Odessa", new Countrie(2, "Albania")), new TravelType(2, "Extrem"));
            var Offer4 = new Offer(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1893, "3", "Lviv", new Countrie(2, "Spain")), new TravelType(2, "Extrem"));
            var Offer5 = new Offer(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1600, "2", "Obolon", new Countrie(2, "Uk")), new TravelType(2, "Extrem"));
            var Offer6 = new Offer(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1585, "2", "Obolon", new Countrie(2, "Uk")), new TravelType(2, "Extrem"));

            List<Offer> offers = new List<Offer>
            {
                Offer1,
                Offer2,
                Offer3,
                Offer4,
                Offer5,
                Offer6
            };

            List<Offer> expected = new List<Offer>
            {              
                Offer2 , Offer6 , Offer5
            };

            var mockOffers = new Mock<IGetOffer>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.Equal(expected, Agency.FindATravel("Uk", "Extrem","2", new DateTime(2022, 1, 1) , new DateTime(2022, 1, 15) , 1800 , 100 , 5 , new OffersSortsIncrease()));

        }

        [Fact]
        public void SortTravel_Desc_ForHotelPrice_ReturnListHotel()
        {
            var Offer1 = new Offer(8, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1500, "1", "Plaza", new Countrie(1, "Germany")), new TravelType(1, "Healthy"));
            var Offer2 = new Offer(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1500, "2", "Qwerty", new Countrie(2, "Uk")), new TravelType(2, "Extrem"));
            var Offer3 = new Offer(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1200, "3", "Odessa", new Countrie(2, "Albania")), new TravelType(2, "Extrem"));
            var Offer4 = new Offer(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1893, "3", "Lviv", new Countrie(2, "Spain")), new TravelType(2, "Extrem"));
            var Offer5 = new Offer(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1400, "2", "Obolon", new Countrie(2, "Uk")), new TravelType(2, "Extrem"));


            List<Offer> offers = new List<Offer>
            {
                Offer1,
                Offer2,
                Offer3,
                Offer4,
                Offer5
            };

            List<Offer> expected = new List<Offer>
            {
                Offer2 , Offer5
            };

            var mockOffers = new Mock<IGetOffer>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.Equal(expected, Agency.FindATravel("Uk", "Extrem", "2", new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1800, 100, 5));

        }




    }
}
