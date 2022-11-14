using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TravelAgency
    {
        public List<string> Countries = new List<string>();
        public List<string> TravelType = new List<string>();
        public List<Trip> Trips = new List<Trip>();

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

        public void AddTravelType(string travel_types)
        {
            TravelType.Add(travel_types);
        }

        public void AddTravelType(List<string> travel_types)
        {
            TravelType.AddRange(travel_types);
        }

        public List<Trip> SortHotelsForPrice()
        {
            TravelSorts sorts = new TravelSorts();
            Trips.Sort(sorts);
            List<Trip> TravelReturn = new List<Trip>();

            for (int i = 0; i < Trips.Count; i++)
            {
                TravelReturn.Add(Trips[i]);
            }
            return TravelReturn;
        }

        public void AddTravels(Trip trip)
        {
            Trips.Add(trip);
        }

        public string SortHotelsForPriceString()
        {
            TravelSorts sorts = new TravelSorts();
            Trips.Sort(sorts);

            string result = null;
            for (int i = 0; i < Trips.Count; i++)
            {
                result += $"Назва готелю : {Trips[i].Hotel.Name} , ціна за день {Trips[i].Hotel.Price} ";
            }
            return result;
        }
    }
}
