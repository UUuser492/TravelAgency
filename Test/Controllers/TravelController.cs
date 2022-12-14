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
        public ActionResult<IEnumerable<string>> GetCountries()
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
                    return Ok(travelAgency.FindATravel("USA", "Sport", "4", new DateTime(2020, 08, 15), new DateTime(2020, 08, 18), 30000, 100, 4));
                }
            }







        }

    }
}
