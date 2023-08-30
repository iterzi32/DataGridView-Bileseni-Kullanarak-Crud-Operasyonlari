using DataGridViewFormExampleData.Interfaces;
using DataGridViewFormExampleData.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewFormExampleData.IOC
{
    public class DataLayerDependencyService
    {
        ServiceProvider serviceProvider;

        public DataLayerDependencyService()
        {
            serviceProvider = new ServiceCollection().AddScoped<IProductRepository, ProductRepository>().BuildServiceProvider(); 
        }
        
        public IProductRepository GetProductRepositoryInstance()
        {
            return serviceProvider.GetRequiredService<IProductRepository>();
        }
    }
}
