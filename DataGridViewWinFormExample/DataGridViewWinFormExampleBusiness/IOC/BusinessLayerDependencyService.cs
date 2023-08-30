using DataGridViewWinFormExampleBusiness.Interfaces;
using DataGridViewWinFormExampleBusiness.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewWinFormExampleBusiness.IOC
{
    public class BusinessLayerDependencyService
    {
        ServiceProvider serviceProvider;

        public BusinessLayerDependencyService()
        {
            serviceProvider = new ServiceCollection().AddScoped<IProductService, ProductManager>().BuildServiceProvider();
        }

        public IProductService GetProductManagerInstance()
        {
            return serviceProvider.GetRequiredService<IProductService>();
        }
    }
}
