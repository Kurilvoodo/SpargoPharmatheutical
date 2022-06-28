using Spargo.Entities;

namespace Spargo.DAO.Interfaces
{
    public interface IProductDAO
    {
        int AddProduct(Product product);

        void SoftDeleteProduct(int productId);

        void HardDeleteProduct(int productId);
    }
}