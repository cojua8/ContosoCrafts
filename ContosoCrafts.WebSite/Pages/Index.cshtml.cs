using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private JsonFileProductsService _productsService;
		public IEnumerable<Product> Products { get; private set; }

		public IndexModel(ILogger<IndexModel> logger, JsonFileProductsService productsService)
		{

			_logger = logger;
			_productsService = productsService;
		}

		public void OnGet()
		{
			Products = _productsService.GetProducts();
			_logger.LogInformation($"Got {Products.Count()} products");
		}
	}
}
