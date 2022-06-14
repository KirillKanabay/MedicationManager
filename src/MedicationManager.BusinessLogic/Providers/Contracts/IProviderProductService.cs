using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.BusinessLogic.Providers.Dtos;

namespace MedicationManager.BusinessLogic.Providers.Contracts
{
    public interface IProviderProductService
    {
        public Task<List<MedicationDto>> GetAvailableMedications(string providerId);
        public Task<List<ProviderProductDto>> GetProviderProducts(string providerId);
        public Task<List<ProviderProductDto>> GetProviderProducts(string providerId, ProviderProductFilterDto filter);
        public Task AddProduct(ProviderProductDto providerProduct);
        public Task DeleteProduct(ProviderProductDto providerProductDto);
        public Task UpdateProduct(ProviderProductDto providerProduct);
    }
}
