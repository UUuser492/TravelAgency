using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test;
using TravelAgencyApp;

namespace TravelAgencyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTravel(string countriesName, string travelTypes,
             string hotelCategory, DateTime start, DateTime end,
            int maxPrice = 1500, int minPrice = 100, int numberOfPeople = 1)
        {

            using (TravelAgencyContext db = new TravelAgencyContext())
            {
                var travelAgency = new TravelAgency.TravelAgency(new ReadFromDB(db));

                if (travelAgency == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(travelAgency.FindATravel(countriesName, travelTypes, hotelCategory, start, end, maxPrice, minPrice, numberOfPeople));
                }
            }

        }



    }
}



