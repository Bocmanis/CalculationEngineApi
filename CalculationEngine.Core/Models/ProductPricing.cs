using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngine.Core.Models
{
    public class ProductPricing
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int UnitsTotal { get; set; }

        /// <summary>
        /// Unit count that didnt form a full carton
        /// </summary>
        public int UnitsRemainder { get; set; }
        public int Cartons { get; set; }
        public decimal PriceForCartons { get; set; }
        public decimal PriceForUnits { get; set; }
        public decimal PriceTotal { get; set; }

         
        // extras
        public decimal EffectivePricePerUnit { get; set; }
        public int AddThisManyToFormAFullCarton { get; set; }
    }
}
