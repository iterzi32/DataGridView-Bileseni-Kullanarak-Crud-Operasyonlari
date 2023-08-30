using DataGridViewFormExampleData.Interfaces;
using DataGridViewFormExampleData.IOC;
using DataGridViewWinFormExampleBusiness.Interfaces;
using DataGridViewWinFormExampleDto.Product;
using DataGridViewWinFormExampleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewWinFormExampleBusiness.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductManager()
        {
            productRepository = new DataLayerDependencyService().GetProductRepositoryInstance();
        }

        public void Add(ProductCreateDto productCreateDto)
        {
            Product addedProduct = new Product();
            addedProduct.Name = productCreateDto.Name;
            addedProduct.Price = productCreateDto.Price;
            productRepository.Add(addedProduct);
        }

        public void Delete(ProductDeleteDto productDeleteDto)
        {
            Product deletedProduct = new Product();
            deletedProduct.Id = productDeleteDto.Id;
            productRepository.Delete(deletedProduct);
        }
       
        public void Update(ProductUpdateDto productUpdateDto)
        {
            Product updatedProduct = new Product();
            updatedProduct.Id = productUpdateDto.Id;
            updatedProduct.Name = productUpdateDto.Name;
            updatedProduct.Price = productUpdateDto.Price;
            productRepository.Update(updatedProduct);   
        }
        
        public List<ProductListDto> GetAll()
        {
            List<ProductListDto> productListDto = new List<ProductListDto>();

            var list = productRepository.GetAll();
            foreach ( var item in list )
            {
                var dto = new ProductListDto();
                dto.Id = item.Id;
                dto.Name = item.Name;
                dto.Price = item.Price;
                productListDto.Add( dto );
            }

            return productListDto;
        }    
    }
}
