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

            mockCountries.Setup(p => p.GetCountries()).Returns(expected);

            //Arrange
            var Agency = new TravelAgency(mockCountries.Object , mockTravelTypes.Object);
          
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

            //Arrange
            var Agency = new TravelAgency(mockCountries.Object , mockTravelTypes.Object);

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

            mockTravelTypes.Setup(p => p.GetTravelTypes()).Returns(expected);

            //Arrange
            var Agency = new TravelAgency(mockCountries.Object, mockTravelTypes.Object);

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

            //Arrange
            var Agency = new TravelAgency(mockCountries.Object, mockTravelTypes.Object);

            //Assert
            Assert.Throws<Exception>(() => Agency.GetTravelType());
        }















        //[Fact]
        //public void Add_Countries_List_Return_List_Of_Countries()
        //{
        //    //Arrange
        //    var Agency = new TravelAgency();
        //    List<string> arrange = new List<string>
        //    {
        //    "Germany",
        //    "England"
        //    };
        //    //Act
        //    Agency.AddCountry(arrange);
        //    List<string> expected = new List<string>
        //    {
        //    "Germany",
        //    "England"
        //    };
        //    //Assert
        //    Assert.Equal(expected, Agency.GetCountries());
        //}

        //[Fact]
        //public void Add_Travel_Type_Return_List_Of_Tpavel_Types()
        //{
        //    //Arrange
        //    var Agency = new TravelAgency();
        //    Agency.AddTravelType("Family");
        //    Agency.AddTravelType("Extreme");
        //    Agency.AddTravelType("Healthy");
        //    //Act
        //    List<string> expected = new List<string>
        //    {
        //    "Family",
        //    "Extreme",
        //    "Healthy",
        //    };
        //    //Assert
        //    Assert.Equal(expected, Agency.GetTravelType());
        //}

        //[Fact]
        //public void Add_Travel_Types_List_Return_List_Of_Tpavel_Types()
        //{
        //    //Arrange
        //    var Agency = new TravelAgency();
        //    //Act
        //    List<string> expected = new List<string>
        //    {
        //    "Family",
        //    "Extreme",
        //    "Healthy",
        //    };
        //    Agency.AddTravelType(expected);
        //    //Assert
        //    Assert.Equal(expected, Agency.GetTravelType());
        //}

        //[Fact]
        //public void SortTravel_ForHotelPrice_ReturnListHotel()
        //{
        //    //Arrange
        //    Hotel hotel1 = new Hotel(1501, "test", "alabama");
        //    Hotel hotel2 = new Hotel(1500, "test", "alabama");
        //    Hotel hotel3 = new Hotel(1499, "test", "alabama");
        //    List<Trip> expected = new List<Trip>
        //    {
        //        new Trip ("Extreme","England",4,hotel1,new DateTime(2020,11,10), new DateTime(2020,12,10)),
        //        new Trip ("Extreme","England",4,hotel2,new DateTime(2020,11,10), new DateTime(2020,12,10)),
        //        new Trip ("Extreme","England",4,hotel3,new DateTime(2020,11,10), new DateTime(2020,12,10))
        //    };

        //    //Act
        //    TravelAgency agency = new TravelAgency();
        //    agency.AddTravels(expected[0]);
        //    agency.AddTravels(expected[1]);
        //    agency.AddTravels(expected[2]);
        //    var act = agency.SortHotelsForPrice();

        //    //Assert
        //    Assert.Equal(expected, act);

        //}

        //[Fact]
        //public void SortTravel_ForHotelPrice_ToString()
        //{
        //    //Arrange
        //    string expected = "����� ������ : alabama , ���� �� ���� 1501 ����� ������ : alabama , ���� �� ���� 1500 ����� ������ : alabama , ���� �� ���� 1499 ";
        //    //Act
        //    TravelAgency agency = new TravelAgency();
        //    agency.AddTravels(new Trip("Healthy", "England", 4, new Hotel(1501, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10)));
        //    agency.AddTravels(new Trip("Extreme", "England", 4, new Hotel(1500, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10)));
        //    agency.AddTravels(new Trip("Healthy", "England", 4, new Hotel(1499, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10)));

        //    var act = agency.SortHotelsForPriceString();
        //    //Assert
        //    Assert.Equal(expected, act);
        //}

        //[Fact]
        //public void FindTravelUsingAllParameters_ReturnListOfTrips()
        //{
        //    //Arrange
        //    var travel1 = new Trip("Extreme", "England", 4, new Hotel(1501, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10));
        //    var travel2 = new Trip("Healthy", "England", 4, new Hotel(1500, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10));
        //    var travel3 = new Trip("Extreme", "England", 4, new Hotel(1499, "test", "alabama"), new DateTime(2020, 11, 10), new DateTime(2020, 12, 10));

        //    //Act
        //    TravelAgency agency = new TravelAgency();
        //    agency.AddTravels(travel1);
        //    agency.AddTravels(travel2);
        //    agency.AddTravels(travel3);

        //    //Assert
        //    Assert.Contains(travel1, agency.Trips);
        //}



    }
}
