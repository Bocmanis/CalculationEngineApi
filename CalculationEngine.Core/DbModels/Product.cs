using CalculationEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngine.Core.DbModels
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int UnitsPerCarton { get; set; }
        public decimal PricePerCarton { get; set; }
        public decimal PricePerUnit { get; set; }
        public string ProductName { get; set; }



        [NotMapped]
        public List<ProductPricing> ProductPricings { get; set; }

    }
}
