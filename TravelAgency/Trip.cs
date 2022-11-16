﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    /// <summary>
    /// Сортує готелі по ціні від більшого до меншого 
    /// </summary>
    public class TravelSortsDesc : IComparer<Trip>
    {
        public int Compare(Trip first, Trip second)
        {
            if (first.Hotel.Price > second.Hotel.Price)
            {
                return -1;
            }
            else if (first.Hotel.Price < second.Hotel.Price)
            {
                return 1;
            }
            return 0;
        }
    }

    /// <summary>
    /// Сортує готелі по ціні від меншого до більшого 
    /// </summary>
    public class TravelSortsIncrease : IComparer<Trip>
    {
        public int Compare(Trip first, Trip second)
        {
            if (first.Hotel.Price > second.Hotel.Price)
            {
                return 1;
            }
            else if (first.Hotel.Price < second.Hotel.Price)
            {
                return -1;
            }
            return 0;
        }
    }


}
