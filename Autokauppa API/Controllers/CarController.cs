using Microsoft.AspNetCore.Mvc;
using static Autokauppa_DAO.Objects.Result;
using Autokauppa_DAO.QueryObjects;
using Autokauppa_DAL.CarRepository;
using Microsoft.AspNetCore.Authorization;

namespace Autokauppa_API.Controllers
{
    [Route("AutokauppaAPI/Car")]
    [ApiController]
    public class CarController(IGet Get, IPost Post, IDelete Delete) : ControllerBase
    {
        [Route("/ByQuery")]
        [HttpGet]
        public IActionResult ByQuery([FromQuery]Query query)
        {
            var result = Get.ByQuery(query);
            if (result.StatusCode == Status.OK)
            {
                return Ok(result.Data);
            }
            else if (result.StatusCode == Status.NoContent)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [Route("/ByBrand")]
        [HttpGet]
        public IActionResult ByBrand([FromQuery]string brand)
        {
            var result = Get.ByBrand(brand);
            if (result.StatusCode == Status.OK)
            {
                return Ok(result.Data);
            }
            else if (result.StatusCode == Status.NoContent)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [Route("/ByBrandAndModel")]
        [HttpGet]
        public IActionResult ByBrandAndModel([FromQuery] string brand, string model)
        {
            var result = Get.ByBrandAndModel(brand, model);
            if (result.StatusCode == Status.OK)
            {
                return Ok(result.Data);
            }
            else if (result.StatusCode == Status.NoContent)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [Route("/AddNewCar")]
        [HttpPost]
        public IActionResult AddNewCar([FromBody] QueryCar queryCar)
        {
            var result = Post.NewCar(queryCar);
            if (result.StatusCode == Status.OK)
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
            if (result.StatusCode == Status.OK)
            {
                return Ok();
            }
            else if (result.StatusCode == Status.NoContent)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
