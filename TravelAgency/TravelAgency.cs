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
        private IGetCountries getCountries;
        private IGetTravelTypes getTravelTypes;
        public IGetTrips getTrips;

        public TravelAgency(IGetCountries getCountries , IGetTravelTypes getTravelTypes , IGetTrips getTrips)
        {
            this.getCountries = getCountries;
            this.getTravelTypes = getTravelTypes;
            this.getTrips = getTrips;
        }

        /// <summary>
        /// Повертає список всіх країн
        /// </summary>
        /// <returns></returns>
        public List<string> GetCountries()
        {
            var listOfCountries = getCountries.GetCountries();

            if (listOfCountries == null || listOfCountries.Count == 0 )
            {
                throw new Exception();
            }
            else
            {
                return listOfCountries;
            }            
        }

        /// <summary>
        /// Повертає список всіх типів подорожей
        /// </summary>
        /// <returns></returns>
        public List<string> GetTravelType()
        {
            var listOfTravelTypes = getTravelTypes.GetTravelTypes();

            if (listOfTravelTypes == null || listOfTravelTypes.Count == 0)
            {
                throw new Exception();
            }
            else
            {
                return listOfTravelTypes;
            }
        }

        /// <summary>
        /// Повертає список всіх подорожей
        /// </summary>
        /// <returns></returns>
        public List<Trip> GetTrips()
        {
            var listOfTrips = getTrips.GetTrips();

            if (listOfTrips == null || listOfTrips.Count == 0)
            {
                throw new Exception();
            }
            else
            {
                return listOfTrips;
            }
        }

        public List<Trip> Sort(IComparer<Trip> comparer)
        {
            var listOfTrips = getTrips.GetTrips();
            List<Trip> TravelReturn = new List<Trip>();
                  
           listOfTrips.Sort(comparer);                
           for (int i = 0; i < listOfTrips.Count; i++)
           {
                TravelReturn.Add(listOfTrips[i]);
           }
           
            return TravelReturn;       
          
        }



    }
}
