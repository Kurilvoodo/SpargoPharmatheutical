using Spargo.Entities;
using System.Collections.Generic;

namespace Spargo.DAO.Interfaces
{
    public interface IPharmacyDAO
    {
        int AddPharmacy(Pharmacy pharmacy);

        void SoftDeletePharmacy(int pharmacyId);

        void HardDeletePharmacy(int pharmacyId);
        IEnumerable<ProductQuantityResult> GetProductsInPharmacy(int pharmacyId);
    }
}