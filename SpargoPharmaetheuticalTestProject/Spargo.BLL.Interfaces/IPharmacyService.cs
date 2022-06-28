using Spargo.Entities;

namespace Spargo.BLL.Interfaces
{
    public interface IPharmacyService
    {
        int AddPharmacy(Pharmacy pharmacy);

        void SoftDeletePharmacy(int pharmacyId);

        void HarddDeletePharmacy(int pharmacyId);
    }
}