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
            List<string> expected = new List<string>
            {
                  "Germany",
                  "Uk",
                  "Ukraine",
            };

            var mockCountries = new Mock<IGetCountries>();
            var mockTravelTypes = new Mock<IGetTravelTypes>();
            var mockTrips = new Mock<IGetTrips>();

            mockCountries.Setup(p => p.GetCountries()).Returns(expected);

            //Arrange
            var Agency = new TravelAgency(mockCountries.Object , mockTravelTypes.Object , mockTrips.Object);
          
            //Assert
            Assert.Equal(expected, Agency.GetCountries());
        }

        [Fact]
        public void Return_List_Of_Countries_False()
        {
            List<string> expected = new List<string>
            {
                  "Germany",
                  "Uk",
                  "Ukraine",
            };

            var mockCountries = new Mock<IGetCountries>();
            var mockTravelTypes = new Mock<IGetTravelTypes>();
            var mockTrips = new Mock<IGetTrips>();

            //Arrange
            var Agency = new TravelAgency(mockCountries.Object , mockTravelTypes.Object , mockTrips.Object);

            //Assert
            Assert.Throws<Exception>(() => Agency.GetCountries());
        }

        [Fact]
        public void Return_List_Of_Travel_Types()
        {
            List<string> expected = new List<string>
            {
                  "Healthy",
                  "Extrem",
                  "Eazy",
            };

            var mockCountries = new Mock<IGetCountries>();
            var mockTravelTypes = new Mock<IGetTravelTypes>();
            var mockTrips = new Mock<IGetTrips>();

            mockTravelTypes.Setup(p => p.GetTravelTypes()).Returns(expected);

            //Arrange
            var Agency = new TravelAgency(mockCountries.Object, mockTravelTypes.Object , mockTrips.Object);

            //Assert
            Assert.Equal(expected, Agency.GetTravelType());
        }

        [Fact]
        public void Return_List_Of_Travel_Types_False()
        {
            List<string> expected = new List<string>
            {
                  "Healthy",
                  "Extrem",
                  "Eazy",
            };

            var mockCountries = new Mock<IGetCountries>();
            var mockTravelTypes = new Mock<IGetTravelTypes>();
            var mockTrips = new Mock<IGetTrips>();

            //Arrange
            var Agency = new TravelAgency(mockCountries.Object, mockTravelTypes.Object , mockTrips.Object);

            //Assert
            Assert.Throws<Exception>(() => Agency.GetTravelType());
        }


        [Fact]
        public void SortTravel_Desc_ForHotelPrice_ReturnListHotel()
        {
            var mockCountries = new Mock<IGetCountries>();
            var mockTravelTypes = new Mock<IGetTravelTypes>();
            var mockTrips = new Mock<IGetTrips>();

            //Arrange
            Hotel hotel1 = new Hotel(1501, "test", "alabama");
            Hotel hotel2 = new Hotel(1500, "test", "alabama");
            Hotel hotel3 = new Hotel(1499, "test", "alabama");
            List<Trip> expected = new List<Trip>
            {
                new Trip ("Extreme","England",4,hotel1,new DateTime(2020,11,10), new DateTime(2020,12,10)),
                new Trip ("Extreme","England",4,hotel2,new DateTime(2020,11,10), new DateTime(2020,12,10)),
                new Trip ("Extreme","England",4,hotel3,new DateTime(2020,11,10), new DateTime(2020,12,10))
            };

            //Act

            mockTrips.Setup(p => p.GetTrips()).Returns(expected);

            TravelAgency agency = new TravelAgency(mockCountries.Object, mockTravelTypes.Object , mockTrips.Object);           
            var act = agency.Sort(new TravelSortsDesc());

            //Assert
            Assert.Equal(expected, act);

        }

        [Fact]
        public void SortTravel_Increase_ForHotelPrice_ReturnListHotel()
        {
            var mockCountries = new Mock<IGetCountries>();
            var mockTravelTypes = new Mock<IGetTravelTypes>();
            var mockTrips = new Mock<IGetTrips>();

            //Arrange
            Hotel hotel1 = new Hotel(1501, "test", "alabama");
            Hotel hotel2 = new Hotel(1500, "test", "alabama");
            Hotel hotel3 = new Hotel(1499, "test", "alabama");
            List<Trip> expected = new List<Trip>
            {
                new Trip ("Extreme","England",4,hotel3,new DateTime(2020,11,10), new DateTime(2020,12,10)),
                new Trip ("Extreme","England",4,hotel2,new DateTime(2020,11,10), new DateTime(2020,12,10)),
                new Trip ("Extreme","England",4,hotel1,new DateTime(2020,11,10), new DateTime(2020,12,10))
            };

            //Act            
            
            mockTrips.Setup(p => p.GetTrips()).Returns(expected);

            TravelAgency agency = new TravelAgency(mockCountries.Object, mockTravelTypes.Object, mockTrips.Object);
            var act = agency.Sort(new TravelSortsIncrease());

            //Assert
            Assert.Equal(expected, act);

        }


        [Fact]
        public void FindTravelUsingAllParameters_ReturnListOfTrips()
        {
            var mockCountries = new Mock<IGetCountries>();
            var mockTravelTypes = new Mock<IGetTravelTypes>();
            var mockTrips = new Mock<IGetTrips>();

            //Arrange
            Hotel hotel1 = new Hotel(1501, "test", "alabama");
            Hotel hotel2 = new Hotel(1500, "test", "alabama");
            Hotel hotel3 = new Hotel(1499, "test", "alabama");
            List<Trip> expected = new List<Trip>
            {
                new Trip ("Extreme","England",4,hotel1,new DateTime(2020,11,10), new DateTime(2020,12,10)),
                new Trip ("Extreme","England",4,hotel2,new DateTime(2020,11,10), new DateTime(2020,12,10)),
                new Trip ("Extreme","England",4,hotel3,new DateTime(2020,11,10), new DateTime(2020,12,10))
            };


            //Act
            TravelAgency agency = new TravelAgency(mockCountries.Object, mockTravelTypes.Object, mockTrips.Object);
            mockTrips.Setup(p => p.GetTrips()).Returns(expected);
            var listOfTrips = agency.GetTrips();

            //Assert
            Assert.Contains(expected[2], listOfTrips);
        }



    }
}
