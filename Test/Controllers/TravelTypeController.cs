using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test;
using TravelAgencyApp;

namespace TravelAgencyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelTypeController : ControllerBase
    {
       

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTravelType()
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
                    return Ok(travelAgency.GetTravelType());

                }
            }







        }
    }
}
