using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductsService ProductsService { get; set; }
        public ProductsController(JsonFileProductsService productsService)
        {
            ProductsService = productsService;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts() => ProductsService.GetProducts();

        [Route("rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string productId, [FromQuery] int rating)
        {
            ProductsService.AddRating(productId, rating);
            return Ok();
        }
    }
}
