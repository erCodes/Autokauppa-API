using Microsoft.AspNetCore.Mvc;
using static Autokauppa_DAO.Objects.Result;
using Autokauppa_DAO.QueryObjects;
using Autokauppa_DAL.CarRepository;
using Microsoft.AspNetCore.Authorization;

namespace Autokauppa_API.Controllers
{
    [Route("AutokauppaAPI")]
    [ApiController]
    public class AutokauppaController(IGet Get, IPost Post, IDelete Delete) : ControllerBase
    {
        // Lisää by query. Älä käytä string brand vaan luo tähän oma objekti jossa kaikki optional. DAL layeriin yksi megametodi joka katsoo kaiken ja muut voi sitten poistaa.

        [Route("/ByQuery")]
        [HttpGet]
        public IActionResult ByQuery([FromQuery]Query query)
        {
            var result = Get.ByBrand("");
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Kusas");
            }
        }

        [Route("/ByBrand")]
        [HttpGet]
        public IActionResult ByBrand([FromQuery]string brand)
        {
            var result = Get.ByBrand(brand);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Kusas");
            }
        }

        [Route("/ByBrandAndModel")]
        [HttpGet]
        public IActionResult ByBrandAndModel([FromQuery] string brand, string model)
        {
            var result = Get.ByBrandAndModel(brand, model);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Kusas");
            }
        }

        [Route("/ByProductionYear")]
        [HttpGet]
        public IActionResult ByProductionYear([FromQuery] string productionYear)
        {
            return StatusCode(501);

        }

        [Route("/BySafetyFeature")]
        [HttpGet]
        public IActionResult BySafetyFeature([FromQuery] string safetyFeature)
        {
            return StatusCode(501);

        }

        [Route("/BySellerName")]
        [HttpGet]
        public IActionResult BySellerName([FromQuery] string sellerName)
        {
            return StatusCode(501);

        }

        [Route("/AddNewCar")]
        [HttpPost]
        public IActionResult AddNewCar([FromBody] QueryCar queryCar)
        {
            if (Post.NewCar(queryCar))
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }

        }

        [Route("/DeleteCarById")]
        [HttpDelete]
        public IActionResult DeleteCarById([FromQuery] string carId)
        {
            var result = Delete.CarById(carId);
            if (result == Status.OK)
            {
                return Ok();
            }
            else if (result == Status.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
