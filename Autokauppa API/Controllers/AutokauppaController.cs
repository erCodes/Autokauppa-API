using Microsoft.AspNetCore.Mvc;
using static Autokauppa_DAL.CarRepository.Delete;
using Autokauppa_DAO.QueryObjects;
using Autokauppa_DAL.CarRepository;
using Autokauppa_DAL;
using Microsoft.AspNetCore.Authorization;

namespace Autokauppa_API.Controllers
{
    [Route("AutokauppaAPI")]
    [ApiController]
    public class AutokauppaController(IGet Get, IPost Post, IDelete Delete) : ControllerBase
    {
        //private IGet? get;
        //private IPost? post;
        //private IDelete? delete;

        //public IGet Get
        //{
        //    get => get ??= new Get(new Context());
        //    set => get = value;
        //}

        //public IPost Post
        //{
        //    get => post ??= new Post(new Context());
        //    set => post = value;
        //}

        //public IDelete Delete
        //{
        //    get => delete ??= new Delete(new Context());
        //    set => delete = value;
        //}



        // Lisää by query. Älä käytä string brand vaan luo tähän oma objekti jossa kaikki optional. DAL layeriin yksi megametodi joka katsoo kaiken ja muut voi sitten poistaa.

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
            if (result == Result.OK)
            {
                return Ok();
            }
            else if (result == Result.NotFound)
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
