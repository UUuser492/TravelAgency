using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency;
using TravelAgencyApp;

namespace Test.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CoutriesController : ControllerBase
    {
        private TravelAgencyContext ctx = new TravelAgencyContext();

        public CoutriesController(TravelAgencyContext ctx)
        {
            this.ctx = ctx;
        }

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
                    return Ok(travelAgency.GetCountries());

                }
            }


                
            
           
   
            
        }

        
    }
}
