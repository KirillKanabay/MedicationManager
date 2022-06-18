using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Stock.Contracts;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.BusinessLogic.Stock.Filters;
using MedicationManager.Data.Stocks.Contracts;
using MedicationManager.Data.Stocks.Documents;
using MedicationManager.Infrastructure.Extensions;

namespace MedicationManager.BusinessLogic.Stock.Services
{
    public class BaseStockService<TStockDto, TStockDocument> : IStockService<TStockDto>
        where TStockDto : BaseStockDto
        where TStockDocument : BaseStockDocument
    {
        private readonly IMapper _mapper;
        private readonly IMedicationService _medicationService;
        private readonly IStockRepository<TStockDocument> _stockRepository;
        
        public BaseStockService(IMapper mapper, IMedicationService medicationService, IStockRepository<TStockDocument> stockRepository)
        {
            _mapper = mapper;
            _medicationService = medicationService;
            _stockRepository = stockRepository;
        }

        public async Task<List<TStockDto>> ListAsync(StockFilterDto filter)
        {
            var items = await ListAllAsync();

            if (items == null)
            {
                return new List<TStockDto>();
            }

            return GetQuery(items, filter).ToList();
        }

        public virtual async Task<List<TStockDto>> ListAllAsync()
        {
            var documents = await _stockRepository.GetAllAsync();

            var dtos = await ToDto(documents);

            return dtos;
        }

        public virtual async Task<TStockDto> GetByIdAsync(string id)
        {
            var document = await _stockRepository.GetByIdAsync(id);

            var dto = await ToDto(document);

            return dto;
        }

        protected virtual async Task UpdateAsync(TStockDto dto)
        {
            var document = _mapper.Map<TStockDocument>(dto);

            await _stockRepository.UpdateAsync(document);
        }

        public virtual async Task AddAsync(TStockDto dto)
        {
            var document = _mapper.Map<TStockDocument>(dto);

            await _stockRepository.AddAsync(document);
        }

        protected virtual async Task DeleteAsync(string id)
        {
            await _stockRepository.DeleteAsync(id);
        }

        protected virtual async Task<List<TStockDto>> ToDto(List<TStockDocument> documents)
        {
            var tasks = documents.Select(ToDto);

            var result = await Task.WhenAll(tasks);

            return result.ToList();
        }

        protected virtual async Task<TStockDto> ToDto(TStockDocument document)
        {
            var dto = _mapper.Map<TStockDto>(document);

            if (!dto.MedicationId.IsNullOrWhitespace())
            {
                var medication = await _medicationService.GetByIdUnsafeAsync(dto.MedicationId);
                dto.Medication = medication;
            }
            
            return dto;
        }

        protected virtual IEnumerable<TStockDto> GetQuery(IEnumerable<TStockDto> items, StockFilterDto filter)
        {
            var query = items;

            if (!filter.Name.IsNullOrWhitespace())
            {
                var regex = new Regex($"^{filter.Name}.*", RegexOptions.IgnoreCase);
                query = query.Where(x => x.Medication?.Name != null && regex.IsMatch(x.Medication.Name));
            }

            return query;
        }
    }
}
