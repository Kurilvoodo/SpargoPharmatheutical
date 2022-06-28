using Spargo.BLL.Interfaces;
using Spargo.DAO.Interfaces;
using Spargo.Entities;

namespace Spargo.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDAO _productDAO;

        public ProductService(IProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public int AddProduct(Product product)
        {
            return _productDAO.AddProduct(product);
        }

        public void HardDeleteProduct(int productId)
        {
            _productDAO.HardDeleteProduct(productId);
        }

        public void SoftDeleteProduct(int productId)
        {
            _productDAO.SoftDeleteProduct(productId);
        }
    }
}