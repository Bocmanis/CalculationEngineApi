using CalculationEngine.Core.DbModels;
using CalculationEngine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngine.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CalculationEngineContext context;

        public ProductRepository(CalculationEngineContext context)
        {
            this.context = context;
        }

        public Product GetProductByCode(string productCode)
        {
            return context.Product.FirstOrDefault(x => x.ProductCode == productCode);
        }

        public List<Product> GetAllProducts()
        {
            return context.Product.ToList();
        }
    }
}
