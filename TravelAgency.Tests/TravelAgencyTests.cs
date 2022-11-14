using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace TravelAgency.Tests
{
    public class TravelAgencyTests
    {
        [Fact]
        public void Add_Country_Return_List_Of_Countries()
        {
            //Arrange
            var Agency = new TravelAgency();
            Agency.AddCountry("Germany");
            //Act

            List<string> expected = new List<string>
            {
            "Germany",
            };
            //Assert
            Assert.Equal(expected, Agency.GetCountries());
        }

        [Fact]
        public void Add_Countries_List_Return_List_Of_Countries()
        {
            //Arrange
            var Agency = new TravelAgency();
            List<string> arrange = new List<string>
            {
            "Germany",
            "England"
            };
            //Act
            Agency.AddCountry(arrange);
            List<string> expected = new List<string>
            {
            "Germany",
            "England"
            };
            //Assert
            Assert.Equal(expected, Agency.GetCountries());
        }

        [Fact]
        public void Add_Travel_Type_Return_List_Of_Tpavel_Types()
        {
            //Arrange
            var Agency = new TravelAgency();
            Agency.AddTravelType("Family");
            Agency.AddTravelType("Extreme");
            Agency.AddTravelType("Healthy");
            //Act
            List<string> expected = new List<string>
            {
            "Family",
            "Extreme",
            "Healthy",
            };
            //Assert
            Assert.Equal(expected, Agency.GetTravelType());
        }

        [Fact]
        public void Add_Travel_Types_List_Return_List_Of_Tpavel_Types()
        {
            //Arrange
            var Agency = new TravelAgency();
            //Act
            List<string> expected = new List<string>
            {
            "Family",
            "Extreme",
            "Healthy",
            };
            Agency.AddTravelType(expected);
            //Assert
            Assert.Equal(expected, Agency.GetTravelType());
        }

        [Fact]
        public void SortTravel_ForHotelPrice_ReturnListHotel()
        {
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
            TravelAgency agency = new TravelAgency();
            agency.AddTravels(expected[0]);
            agency.AddTravels(expected[1]);
            agency.AddTravels(expected[2]);
            var act = agency.SortHotelsForPrice();

            //Assert
            Assert.Equal(expected, act);

        }

        [Fact]
        public void SortTravel_ForHotelPrice_ToString()
        {
            //Arrange
            string expected = "Назва готелю : alabama , ціна за день 1501 Назва готелю : alabama , ціна за день 1500 Назва готелю : alabama , ціна за день 1499 ";
            //Act
            TravelAgency agency = new TravelAgency();
            agency.AddTravels(new Trip("Healthy", "England", 4, new Hotel(1501, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10)));
            agency.AddTravels(new Trip("Extreme", "England", 4, new Hotel(1500, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10)));
            agency.AddTravels(new Trip("Healthy", "England", 4, new Hotel(1499, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10)));

            var act = agency.SortHotelsForPriceString();
            //Assert
            Assert.Equal(expected, act);
        }

        [Fact]
        public void FindTravelUsingAllParameters_ReturnListOfTrips()
        {
            //Arrange
            var travel1 = new Trip("Extreme", "England", 4, new Hotel(1501, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10));
            var travel2 = new Trip("Healthy", "England", 4, new Hotel(1500, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10));
            var travel3 = new Trip("Extreme", "England", 4, new Hotel(1499, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10));

            //Act
            TravelAgency agency = new TravelAgency();
            agency.AddTravels(travel1);
            agency.AddTravels(travel2);
            agency.AddTravels(travel3);

            //Assert
            Assert.Contains(travel1, agency.Trips);
        }



    }
}
