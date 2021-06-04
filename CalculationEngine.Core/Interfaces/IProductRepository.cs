using CalculationEngine.Core.DbModels;
using System.Collections.Generic;

namespace CalculationEngine.Core.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductByCode(string productCode);
    }
}