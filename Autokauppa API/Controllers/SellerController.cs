﻿using Microsoft.AspNetCore.Mvc;
using Autokauppa_DAL.SellerRepository;
using Autokauppa_DAO.QueryObjects;
using static Autokauppa_DAO.Objects.Result;
namespace Autokauppa_API.Controllers
{
    [Route("AutokauppaAPI/Seller")]
    [ApiController]
    public class SellerController(IGet Get, IPost Post, IPut Put, IDelete Delete) : ControllerBase
    {
        [Route("/SellersByQuery")]
        [HttpGet]
        public IActionResult ByQuery([FromQuery] QuerySellerInfo sellerInfo)
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

        [Route("/AllSellers")]
        [HttpGet]
        public IActionResult AllSellers([FromQuery] bool includeCars)
        {
            var result = Get.AllSellers(includeCars);
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

        [Route("/NewSeller")]
        [HttpPost]
        public IActionResult NewSeller([FromQuery] QuerySellerInfo sellerInfo)
        {
            var result = Post.NewSeller(sellerInfo);
            if (result.StatusCode == Status.OK)
            {
                return Ok();
            }
            else if (result.StatusCode == Status.BadRequest)
            {
                return BadRequest(result.Data);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [Route("/UpdateSeller/{sellerId}")]
        [HttpPut]
        public IActionResult UpdateSeller([FromRoute] string sellerId, QuerySellerInfo sellerInfo)
        {
            var result = Put.UpdateSeller(sellerId, sellerInfo);
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

        [Route("/SellerById/{sellerId}")]
        [HttpDelete]
        public IActionResult SellerById([FromRoute]string sellerId)
        {
            var result = Delete.SellerById(sellerId);
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
