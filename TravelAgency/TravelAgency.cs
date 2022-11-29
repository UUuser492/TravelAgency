using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TravelAgency
    {      
        public IGetOffer getOffers;

        public TravelAgency(IGetOffer getOffers)
        {           
            this.getOffers = getOffers;
        }

        /// <summary>
        /// Повертає список всіх країн
        /// </summary>
        /// <returns></returns>
        public List<string> GetCountries()
        {
            var listOfOffers = getOffers.GetOffers();
            var listOfCountries = new List<string>();

            if (listOfOffers == null || listOfOffers.Count == 0 )
            {
                throw new Exception();
            }
            else
            {

                var temp = from emp in listOfOffers
                                   .GroupBy(x => x.Hotel.Countries.Name)
                                   .Select(y=>y.First())
                                   select emp.Hotel.Countries.Name;

                listOfCountries = temp.ToList();
            }
            return listOfCountries;
        }

        /// <summary>
        /// Повертає список всіх типів подорожей
        /// </summary>
        /// <returns></returns>
        public List<string> GetTravelType()
        {
            var listOfOffers = getOffers.GetOffers();
            var listOfTravelTypes = new List<string>();

            if (listOfOffers == null || listOfOffers.Count == 0)
            {
                throw new Exception();
            }
            else
            {
                var temp = from emp in listOfOffers
                                   .GroupBy(x => x.TravelTypes.Types)
                                   .Select(y => y.First())
                                   select emp.TravelTypes.Types.ToString();

                listOfTravelTypes = temp.ToList();
            }
            return listOfTravelTypes;
        }

        /// <summary>
        /// Повертає список всіх подорожей
        /// </summary>
        /// <returns></returns>
        public List<Offer> FindATravel(string countriesName , string travelTypes ,
             string hotelCategory , DateTime start , DateTime end , 
            int maxPrice = 1500 , int minPrice = 100, int numberOfPeople = 1 , IComparer<Offer> comparer = null)
        {
            var listOfOffers = new List<Offer>();
            if (comparer == null)
            {
                listOfOffers = Sort(new OffersSortsDesc());
            }
            else
            {
                listOfOffers = Sort(comparer);
            }
            
            var returnedListOfOffers = new List<Offer>();

            if (listOfOffers == null || listOfOffers.Count == 0)
            {
                throw new Exception();
            }
            else
            {
                var query = listOfOffers.Select(o => o).Where(
                    x => x.Hotel.Countries.Name == countriesName &&
                    x.TravelTypes.Types == travelTypes &&
                    x.Hotel.HotelCategory == hotelCategory &&
                    x.Beginning == start &&
                    x.Ending == end &&
                    x.Price >= minPrice && x.Price <= maxPrice);

                return query.ToList();
            }

        }

        private List<Offer> Sort(IComparer<Offer> comparer)
        {
            var listOfTrips = getOffers.GetOffers();
            List<Offer> TravelReturn = new List<Offer>();
                  
            listOfTrips.Sort(comparer);

            var query = listOfTrips.Select(o => o);

            return query.ToList();       
          
        }

    }
}
