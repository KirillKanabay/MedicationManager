using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.BusinessLogic.Providers.Dtos;

namespace MedicationManager.BusinessLogic.Providers.Contracts
{
    public interface IProviderProductService
    {
        public Task<List<MedicationDto>> GetAvailableMedications(ProviderDto provider);
        public Task<List<ProviderProductDto>> GetProviderProducts(string providerId);
        public Task<List<ProviderProductDto>> GetProviderProducts(string providerId, ProviderProductFilterDto filter);
        public Task AddProduct(string providerId, ProviderProductDto providerProduct);
        public Task DeleteProduct(string providerId, ProviderProductDto providerProductDto);
        public Task UpdateProduct(string providerId, ProviderProductDto providerProduct);
    }
}
