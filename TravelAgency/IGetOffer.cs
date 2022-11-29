using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public interface IGetOffer
    {
        public List<Offer> GetOffers();
    }
}
