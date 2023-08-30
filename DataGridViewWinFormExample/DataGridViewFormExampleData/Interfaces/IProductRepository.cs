using DataGridViewWinFormExampleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewFormExampleData.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);   
        List<Product>  GetAll();  
    }
}
