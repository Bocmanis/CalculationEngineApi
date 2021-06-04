using CalculationEngine.Core.DbModels;
using CalculationEngine.Core.Models;
using System.Collections;
using System.Collections.Generic;

namespace CalculationEngine.Core.Interfaces
{
    public interface ICalculationEngineLogic
    {
        ProductPricing GetProductPricing(string productCode, int unitCount);
        IEnumerable<Product> GetAllProductPricing();
    }
}