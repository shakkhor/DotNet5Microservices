using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("[action]/{id:length(24)}", Name = "GetShoppingCart")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCart(string userId)
        {
            return Ok(await _basketRepository.GetShoppingCart(userId));
        }


        [HttpPost("[action]", Name = "UpdateProduct")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateShoppinCart(ShoppingCart shoppingCart)
        {
            return Ok(await _basketRepository.UpdateShoppingCart(shoppingCart));
        }


        [HttpDelete("[action]/{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string userId)
        {
            return Ok(await _basketRepository.EmptyCart(userId));
        }
    }
}
