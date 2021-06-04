using CalculationEngine.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngine.Logic
{
    public class CalculationEngineLogicDiContainer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICalculationEngineLogic, CalculationEngineLogic>();
        }
    }
}
