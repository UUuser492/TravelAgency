using System;
using System.Collections.Generic;
using Xunit;

namespace TravelAgency.Tests
{
    public class TravelAgencyTests
    {
        [Fact]
        public void Return_List_Of_Countries()
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
    }
}
