using CalculationEngine.Core.DbModels;
using CalculationEngine.Core.Interfaces;
using CalculationEngine.Core.Models;
using CalculationEngine.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace CalculationEngine.Logic
{
    public class CalculationEngineLogic: ICalculationEngineLogic
    {
        private readonly IProductRepository productRepository;

        public CalculationEngineLogic(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ProductPricing GetProductPricing(string productCode, int unitCount)
        {
            var product = productRepository.GetProductByCode(productCode);
            if (product == null)
            {
                return null;
            }
            ProductPricing result = CalculateProductPricing(unitCount, product);

            return result;
        }

        private static ProductPricing CalculateProductPricing(int unitCount, Product product)
        {
            var result = new ProductPricing();
            result.UnitsTotal = unitCount;
            result.Cartons = result.UnitsTotal / product.UnitsPerCarton;
            result.PriceForCartons = result.Cartons * product.PricePerCarton;
            result.UnitsRemainder = result.UnitsTotal % product.UnitsPerCarton;
            result.PriceForUnits = result.UnitsRemainder * product.PricePerUnit;
            result.PriceTotal = result.PriceForCartons + result.PriceForUnits;
            result.ProductName = product.ProductName;
            result.ProductCode = product.ProductCode;
            
            // avoid divide by 0
            if (result.UnitsTotal != 0)
            {
                result.EffectivePricePerUnit = Math.Round(result.PriceTotal / result.UnitsTotal, 2);
            }

            return result;
        }


        /// <summary>
        /// Gets all product prices with unit count 1-50.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProductPricing()
        {
            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                product.ProductPricings = new List<ProductPricing>();
                for (int i = 1; i < 50; i++)
                {
                    var pricing = CalculateProductPricing(i, product);
                    product.ProductPricings.Add(pricing);
                }
            }
            return products;
        }
    }
}
