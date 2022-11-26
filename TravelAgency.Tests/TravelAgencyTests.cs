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
            List<Offers> offers = new List<Offers>
            {
                new Offers(8, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(1,"Germany")) , new TravelTypes(1 ,"Healthy")),               
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Uk")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Germany")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Germany")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Uk")), new TravelTypes(2 , "Extrem")),
            };

            List<string> expected = new List<string>
            {
                  "Germany",
                  "Uk",                 
            };

            var mockOffers = new Mock<IGetOffers>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency( mockOffers.Object);
          
            //Assert
            Assert.Equal(expected, Agency.GetCountries());
        }

        [Fact]
        public void Return_List_Of_Countries_False()
        {
            List<Offers> offers = new List<Offers>
            {
                new Offers(8, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(1,"Germany")) , new TravelTypes(1 ,"Healthy")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Uk")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Germany")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Germany")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Uk")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Albania")), new TravelTypes(2 , "Extrem")),
            };

            List<string> expected = new List<string>
            {
                  "Germany",
                  "Uk",
                  "Maldive",

            };

            var mockOffers = new Mock<IGetOffers>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.NotEqual(expected, Agency.GetCountries());
        }

        [Fact]
        public void Return_List_Of_Travel_Types()
        {
            List<Offers> offers = new List<Offers>
            {
                new Offers(8, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(1,"Germany")) , new TravelTypes(1 ,"Healthy")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Uk")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Germany")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Germany")), new TravelTypes(2 , "Eazy")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Uk")), new TravelTypes(2 , "Extrem")),

            };

            List<string> expected = new List<string>
            {
                  "Healthy",
                  "Extrem",
                  "Eazy",                   
            };

            var mockOffers = new Mock<IGetOffers>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.Equal(expected, Agency.GetTravelType());
        }

        [Fact]
        public void Return_List_Of_Travel_Types_False()
        {
            List<Offers> offers = new List<Offers>
            {
                new Offers(8, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(1,"Germany")) , new TravelTypes(1 ,"Healthy")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Uk")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Germany")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Germany")), new TravelTypes(2 , "Eazy")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Uk")), new TravelTypes(2 , "Extrem")),
                new Offers(5, new DateTime(2022,1,1) , new DateTime(2022,1,15) , 1520 , new Hotel(1500 , "qwerty" , "Plaza" , new Countries(2,"Uk")), new TravelTypes(2 , "Extrem")),

            };

            List<string> expected = new List<string>
            {
                  "Healthy",
                  "Extrem",
                  "Eazy",
                  "Recovery"
            };

            var mockOffers = new Mock<IGetOffers>();
            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.NotEqual(expected, Agency.GetTravelType());
        }

        [Fact]
        public void SortTravel_Incr_ForHotelPrice_ReturnListHotel()
        {
            var Offer1 = new Offers(8, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1500, "1", "Plaza", new Countries(1, "Germany")), new TravelTypes(1, "Healthy"));
            var Offer2 = new Offers(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1500, "2", "Qwerty", new Countries(2, "Uk")), new TravelTypes(2, "Extrem"));
            var Offer3 = new Offers(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1200, "3", "Odessa", new Countries(2, "Albania")), new TravelTypes(2, "Extrem"));
            var Offer4 = new Offers(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1893, "3", "Lviv", new Countries(2, "Spain")), new TravelTypes(2, "Extrem"));
            var Offer5 = new Offers(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1600, "2", "Obolon", new Countries(2, "Uk")), new TravelTypes(2, "Extrem"));
            var Offer6 = new Offers(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1585, "2", "Obolon", new Countries(2, "Uk")), new TravelTypes(2, "Extrem"));

            List<Offers> offers = new List<Offers>
            {
                Offer1,
                Offer2,
                Offer3,
                Offer4,
                Offer5,
                Offer6
            };

            List<Offers> expected = new List<Offers>
            {              
                Offer2 , Offer6 , Offer5
            };

            var mockOffers = new Mock<IGetOffers>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.Equal(expected, Agency.FindATravel("Uk", "Extrem","2", new DateTime(2022, 1, 1) , new DateTime(2022, 1, 15) , 1800 , 100 , 5 , new OffersSortsIncrease()));

        }

        [Fact]
        public void SortTravel_Desc_ForHotelPrice_ReturnListHotel()
        {
            var Offer1 = new Offers(8, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1500, "1", "Plaza", new Countries(1, "Germany")), new TravelTypes(1, "Healthy"));
            var Offer2 = new Offers(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1500, "2", "Qwerty", new Countries(2, "Uk")), new TravelTypes(2, "Extrem"));
            var Offer3 = new Offers(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1200, "3", "Odessa", new Countries(2, "Albania")), new TravelTypes(2, "Extrem"));
            var Offer4 = new Offers(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1893, "3", "Lviv", new Countries(2, "Spain")), new TravelTypes(2, "Extrem"));
            var Offer5 = new Offers(5, new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1520, new Hotel(1400, "2", "Obolon", new Countries(2, "Uk")), new TravelTypes(2, "Extrem"));


            List<Offers> offers = new List<Offers>
            {
                Offer1,
                Offer2,
                Offer3,
                Offer4,
                Offer5
            };

            List<Offers> expected = new List<Offers>
            {
                Offer2 , Offer5
            };

            var mockOffers = new Mock<IGetOffers>();

            mockOffers.Setup(p => p.GetOffers()).Returns(offers);

            //Arrange
            var Agency = new TravelAgency(mockOffers.Object);

            //Assert
            Assert.Equal(expected, Agency.FindATravel("Uk", "Extrem", "2", new DateTime(2022, 1, 1), new DateTime(2022, 1, 15), 1800, 100, 5));

        }




    }
}
