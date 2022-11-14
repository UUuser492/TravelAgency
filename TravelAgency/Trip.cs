using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Trip
    {
        public string Type { get; set; }
        public string Country { get; set; }
        public int People { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime Ending { get; set; }

        public Trip(string type, string country, int people, Hotel hotel, DateTime begin, DateTime end)
        {
            Type = type;
            Country = country;
            People = people;
            Hotel = hotel;
            Beginning = begin;
            Ending = end;
        }
    }
}
