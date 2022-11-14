using System;
using System.Collections.Generic;
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
    }
}
