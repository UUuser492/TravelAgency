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
        public IGetOffers getOffers;

        public TravelAgency(IGetOffers getOffers)
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
                for (int i = 0; i < listOfOffers.Count; i++)
                {

                    if (!listOfCountries.Contains(listOfOffers[i].Hotel.Countries.Name))
                    {
                        listOfCountries.Add(listOfOffers[i].Hotel.Countries.Name);
                    }

                }
                return listOfCountries;
            }            
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
                for (int i = 0; i < listOfOffers.Count; i++)
                {                    

                    if (!listOfTravelTypes.Contains(listOfOffers[i].TravelTypes.Types))
                    {
                        listOfTravelTypes.Add(listOfOffers[i].TravelTypes.Types);
                    }

                }
                return listOfTravelTypes;
            }
        }

        /// <summary>
        /// Повертає список всіх подорожей
        /// </summary>
        /// <returns></returns>
        public List<Offers> FindATravel(string countriesName , string travelTypes ,
             string hotelCategory , DateTime start , DateTime end , 
            int maxPrice = 1500 , int minPrice = 100, int numberOfPeople = 1 , IComparer<Offers> comparer = null)
        {
            var listOfOffers = new List<Offers>();
            if (comparer == null)
            {
                listOfOffers = Sort(new OffersSortsDesc());
            }
            else
            {
                listOfOffers = Sort(comparer);
            }
            
            var returnedListOfOffers = new List<Offers>();

            if (listOfOffers == null || listOfOffers.Count == 0)
            {
                throw new Exception();
            }
            else
            {
               

                for (int i = 0; i < listOfOffers.Count; i++)
                {
                    if (listOfOffers[i].Hotel.Countries.Name == countriesName && listOfOffers[i].TravelTypes.Types == travelTypes
                        && listOfOffers[i].Hotel.HotelCategory == hotelCategory && listOfOffers[i].Beginning == start
                        && listOfOffers[i].Ending == end && listOfOffers[i].Price >= minPrice && listOfOffers[i].Price <= maxPrice)
                    {
                        returnedListOfOffers.Add(listOfOffers[i]);
                    }

                }

                return returnedListOfOffers;


            }

            

        }

        private List<Offers> Sort(IComparer<Offers> comparer)
        {
            var listOfTrips = getOffers.GetOffers();
            List<Offers> TravelReturn = new List<Offers>();
                  
            listOfTrips.Sort(comparer);                


            for (int i = 0; i < listOfTrips.Count; i++)
            {
                 TravelReturn.Add(listOfTrips[i]);
            }
           
            return TravelReturn;       
          
        }



    }
}
