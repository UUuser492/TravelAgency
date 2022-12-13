using Microsoft.EntityFrameworkCore;
using TravelAgency;
using TravelAgencyApp;

namespace Test
{
    public class ReadFromDB : IGetOffer
    {
        private readonly TravelAgencyContext travelAgencyContext;

        public ReadFromDB(TravelAgencyContext travelAgencyContext)
        {
            this.travelAgencyContext = travelAgencyContext;
        }

        public List<Offer> GetOffers()
        {
            var listOfOffers = travelAgencyContext.Offers.Include(h => h.Hotel).Include(t => t.TravelTypes)
                .Include(c => c.Hotel.Countries).ToList();

            return listOfOffers;
        }
    }
}
