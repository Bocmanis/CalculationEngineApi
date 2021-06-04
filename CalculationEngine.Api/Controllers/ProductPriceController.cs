using CalculationEngine.Api.Data;
using CalculationEngine.Core.DbModels;
using CalculationEngine.Core.Interfaces;
using CalculationEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationEngine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductPriceController : Controller
    {
        private readonly ILogger<ProductPriceController> logger;
        private readonly ICalculationEngineLogic calculationEngineLogic;

        public ProductPriceController(ILogger<ProductPriceController> logger, ICalculationEngineLogic calculationEngineLogic)
        {
            this.logger = logger;
            this.calculationEngineLogic = calculationEngineLogic;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Product> GetAllProductPrices()
        {
            var result = calculationEngineLogic.GetAllProductPricing();

            return result;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetPrice(string productCode, int unitCount)
        {

            var result = calculationEngineLogic.GetProductPricing(productCode, unitCount);
            if (result == null)
            {
                return NotFound("Product not found");
            }

            return Ok(result);
        }
    }
}
