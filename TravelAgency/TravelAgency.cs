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
        public List<Trip> Trips = new List<Trip>();

        public TravelAgency(IGetCountries getCountries , IGetTravelTypes getTravelTypes)
        {
            this.getCountries = getCountries;
            this.getTravelTypes = getTravelTypes;
        }

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

      
        public List<Trip> SortHotelsForPrice(IComparer comparer = null)
        {

            TravelSorts sorts = new TravelSorts();
            TravelSortsIncrease sortsAces = new TravelSortsIncrease();

            if (comparer==null)
            {
                Trips.Sort(sorts);
                List<Trip> TravelReturn = new List<Trip>();
                for (int i = 0; i < Trips.Count; i++)
                {
                    TravelReturn.Add(Trips[i]);
                }
                return TravelReturn;
            }
            else
            {
                Trips.Sort(sortsAces);
                List<Trip> TravelReturn = new List<Trip>();
                for (int i = 0; i < Trips.Count; i++)
                {
                    TravelReturn.Add(Trips[i]);
                }
                return TravelReturn;
            }
          
          
        }

        //public string SortHotelsForPriceString()
        //{
        //    TravelSorts sorts = new TravelSorts();
        //    Trips.Sort(sorts);

        //    string result = null;
        //    for (int i = 0; i < Trips.Count; i++)
        //    {
        //        result += $"Назва готелю : {Trips[i].Hotel.Name} , ціна за день {Trips[i].Hotel.Price} ";
        //    }
        //    return result;
        //}
    }
}
