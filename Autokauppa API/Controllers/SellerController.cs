using Microsoft.AspNetCore.Mvc;
using Autokauppa_DAL.SellerRepository;
using Autokauppa_DAO.QueryObjects;
using static Autokauppa_DAO.Objects.Result;
namespace Autokauppa_API.Controllers
{
    [Route("AutokauppaAPI/Seller")]
    [ApiController]
    public class SellerController(IGet Get) : ControllerBase
    {
        [Route("/ByQuery")]
        [HttpGet]
        public IActionResult ByQuery([FromQuery]QuerySellerInfo sellerInfo)
        {
            var result = Get.ByQuery(sellerInfo);
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
    }
}
