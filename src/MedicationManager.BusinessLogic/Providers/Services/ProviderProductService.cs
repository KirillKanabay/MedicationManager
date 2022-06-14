using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Comparers;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.BusinessLogic.Providers.Comparers;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.Infrastructure.Extensions;

namespace MedicationManager.BusinessLogic.Providers.Services
{
    public class ProviderProductService : IProviderProductService
    {
        private readonly IProviderService _providerService;
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        
        public ProviderProductService(IProviderService providerService, IMedicationService medicationService, IMapper mapper)
        {
            _providerService = providerService ?? throw new ArgumentNullException(nameof(providerService));
            _medicationService = medicationService ?? throw new ArgumentNullException(nameof(medicationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<MedicationDto>> GetAvailableMedications(string providerId)
        {
            var medications = await _medicationService.ListAllAsync();
            var dtos = _mapper.Map<List<MedicationDto>>(medications);

            var providerProducts = (await GetProviderProducts(providerId))
                .Select(x => x.Medication)
                .ToList();

            dtos = dtos.Except(providerProducts, new MedicationComparer()).ToList();

            return dtos;
        }

        public async Task<List<ProviderProductDto>> GetProviderProducts(string providerId)
        {
            var provider = await _providerService.GetByIdAsync(providerId);

            if (provider == null)
            {
                return new List<ProviderProductDto>();
            }

            var providerProducts = provider.Products;
            var dtos = _mapper.Map<List<ProviderProductDto>>(providerProducts);

            return dtos;
        }

        public async Task<List<ProviderProductDto>> GetProviderProducts(string providerId, ProviderProductFilterDto filter)
        {
            var products = await GetProviderProducts(providerId);
            
            if (products == null)
            {
                return new List<ProviderProductDto>();
            }

            return GetProductQuery(products, filter).ToList();
        }

        public async Task AddProduct(ProviderProductDto product)
        {
            var provider = await _providerService.GetByIdAsync(product.ProviderId);

            if (provider == null)
            {
                return;
            }
            provider.Products ??= new List<ProviderProductDto>();

            if(provider.Products.Contains(product, new ProviderProductComparer()))
            {
                throw new ArgumentException("Product already exists in list of products");
            }

            provider.Products.Add(product);

            await _providerService.UpdateAsync(provider);
        }

        public async Task DeleteProduct(ProviderProductDto product)
        {
            var provider = await _providerService.GetByIdAsync(product.ProviderId);

            if (provider == null)
            {
                return;
            }

            provider.Products ??= new List<ProviderProductDto>();

            provider.Products = provider
                .Products
                .Where(x => !new ProviderProductComparer().Equals(x, product))
                .ToList();

            await _providerService.UpdateAsync(provider);
        }

        public async Task UpdateProduct(ProviderProductDto updatedProduct)
        {
            var provider = await _providerService.GetByIdAsync(updatedProduct.ProviderId);

            if (provider == null)
            {
                return;
            }

            provider.Products ??= new List<ProviderProductDto>();

            var product = provider
                .Products
                .FirstOrDefault(x => new ProviderProductComparer().Equals(x, updatedProduct));

            if (product != null)
            {
                product.Price = updatedProduct.Price;
            }

            await _providerService.UpdateAsync(provider);
        }

        private IEnumerable<ProviderProductDto> GetProductQuery(IEnumerable<ProviderProductDto> products, ProviderProductFilterDto filter)
        {
            var query = products;

            if (!filter.Name.IsNullOrWhitespace())
            {
                var regex = new Regex($"^{filter.Name}.*", RegexOptions.IgnoreCase);
                query = query.Where(x => x.Medication?.Name != null && regex.IsMatch(x.Medication.Name));
            }

            return query;
        }
    }
}
