using CalculationEngine.Core.DbModels;
using CalculationEngine.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationEngine.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CalculationEngineContext context)
        {
            // Look for any products.
            if (context.Product.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product
                {
                    PricePerCarton = 175,
                    UnitsPerCarton = 5,
                    PricePerUnit = 1.3m * 175/5,
                    ProductCode = "ProficookPCDR1116",
                    ProductName = "Fruit dryer",
                },

                new Product
                {
                    PricePerCarton = 875,
                    UnitsPerCarton = 15,
                    // result is 75.8333333333..    The decimal type being saved automatically saves 2 numbers after decimal point
                    // and round to closest number. So it will be saved as 75.83
                    PricePerUnit = 1.3m * 875/15,
                    ProductCode = "DomolettiGardenSSAP009_3m",
                    ProductName = "Garden umbrella",
                },
            };

            context.Product.AddRange(products);
            context.SaveChanges();
        }
    }
}
