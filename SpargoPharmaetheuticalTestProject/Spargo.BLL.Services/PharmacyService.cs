using Spargo.BLL.Interfaces;
using Spargo.DAO.Interfaces;
using Spargo.Entities;
using System.Collections.Generic;

namespace Spargo.BLL.Services
{
    public class PharmacyService : IPharmacyService
    {
        private IPharmacyDAO _pharmacyDAO;

        public PharmacyService(IPharmacyDAO pharmacyDAO)
        {
            _pharmacyDAO = pharmacyDAO;
        }

        public int AddPharmacy(Pharmacy pharmacy)
        {
            return _pharmacyDAO.AddPharmacy(pharmacy);
        }

        public IEnumerable<ProductQuantityResult> GetProductsInPharmacy(int pharmacyId)
        {
            return _pharmacyDAO.GetProductsInPharmacy(pharmacyId);
        }

        public void HarddDeletePharmacy(int pharmacyId)
        {
            _pharmacyDAO.HardDeletePharmacy(pharmacyId);
        }

        public void SoftDeletePharmacy(int pharmacyId)
        {
            _pharmacyDAO.SoftDeletePharmacy(pharmacyId);
        }
    }
}