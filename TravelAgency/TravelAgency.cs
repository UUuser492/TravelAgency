using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TravelAgency
    {
        public List<string> Countries = new List<string>();
        public List<string> TravelType = new List<string>();

        public void AddCountry(string country)
        {
            Countries.Add(country);
        }

        public void AddCountry(List<string> countries)
        {
            Countries.AddRange(countries);
        }

        public List<string> GetCountries()
        {
            return Countries;
        }

        public List<string> GetTravelType()
        {
            return TravelType;
        }
    }
}
