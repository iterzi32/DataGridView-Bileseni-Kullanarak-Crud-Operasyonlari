using DataGridViewWinFormExampleDto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewWinFormExampleBusiness.Interfaces
{
    public interface IProductService
    {    
        void Add(ProductCreateDto productCreateDto);
        void Delete(ProductDeleteDto productDeleteDto);
        void Update(ProductUpdateDto productUpdateDto);
        List<ProductListDto> GetAll();
    }
}
