using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Offer
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime Ending { get; set; }
        public int Price { get; set; }      
        public virtual Hotel Hotel { get; set; }
        public virtual TravelType TravelTypes { get; set; }

        //public Offer(int number, DateTime beginning, DateTime ending, int price, Hotel hotel, TravelType travelTypes)
        //{
        //    NumberOfPeople = number;
        //    Beginning = beginning;
        //    Ending = ending;
        //    Price = price;
        //    Hotel = hotel;
        //    TravelTypes = travelTypes;
        //}
    }

    /// <summary>
    /// Сортує готелі по ціні від більшого до меншого 
    /// </summary>
    public class OffersSortsDesc : IComparer<Offer>
    {
        public int Compare(Offer first, Offer second)
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
    public class OffersSortsIncrease : IComparer<Offer>
    {
        public int Compare(Offer first, Offer second)
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
