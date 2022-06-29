using Spargo.Entities;
using System.Collections.Generic;

namespace Spargo.BLL.Interfaces
{
    public interface IPharmacyService
    {
        int AddPharmacy(Pharmacy pharmacy);

        void SoftDeletePharmacy(int pharmacyId);

        void HarddDeletePharmacy(int pharmacyId);

        IEnumerable<ProductQuantityResult> GetProductsInPharmacy(int pharmacyId);
    }
}