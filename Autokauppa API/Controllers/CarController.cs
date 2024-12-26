using Microsoft.AspNetCore.Mvc;
using static Autokauppa_DAO.Objects.Result;
using Autokauppa_DAO.QueryObjects;
using Autokauppa_DAL.CarRepository;

namespace Autokauppa_API.Controllers
{
    [Route("AutokauppaAPI/Car")]
    [ApiController]
    public class CarController(IGet Get, IPost Post, IPut Put, IDelete Delete) : ControllerBase
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

        [Route("/ByBrand/{brand}")]
        [HttpGet]
        public IActionResult ByBrand([FromRoute]string brand)
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

        [Route("/ByBrandAndModel/{brand}/{model}")]
        [HttpGet]
        public IActionResult ByBrandAndModel([FromRoute] string brand, string model)
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
            else if (result.StatusCode == Status.BadRequest)
            {
                return BadRequest();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [Route("/UpdateCar/{carId}")]
        [HttpPut]
        public IActionResult UpdateCar([FromRoute]string carId, CarUpdateInfo update)
        {
            var result = Put.UpdateCar(carId, update);
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

        [Route("/DeleteCarById/{carId}")]
        [HttpDelete]
        public IActionResult DeleteCarById([FromRoute] string carId)
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
