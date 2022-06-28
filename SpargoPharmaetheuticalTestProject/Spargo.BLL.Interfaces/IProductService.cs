using Spargo.Entities;

namespace Spargo.BLL.Interfaces
{
    public interface IProductService
    {
        int AddProduct(Product product);

        void SoftDeleteProduct(int productId);

        void HardDeleteProduct(int productId);
    }
}