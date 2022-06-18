using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.BusinessLogic.Stock.Filters;

namespace MedicationManager.BusinessLogic.Stock.Contracts
{
    public interface IStockService<TStockDto> 
        where TStockDto : BaseStockDto
    {
        Task<List<TStockDto>> ListAsync(StockFilterDto filter);
        Task<List<TStockDto>> ListAllAsync();
        Task<TStockDto> GetByIdAsync(string id);
        Task AddAsync(TStockDto dto);
    }
}
