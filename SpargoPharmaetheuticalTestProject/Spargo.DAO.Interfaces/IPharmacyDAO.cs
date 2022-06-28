using Spargo.Entities;

namespace Spargo.DAO.Interfaces
{
    public interface IPharmacyDAO
    {
        int AddPharmacy(Pharmacy pharmacy);

        void SoftDeletePharmacy(int pharmacyId);

        void HardDeletePharmacy(int pharmacyId);
    }
}