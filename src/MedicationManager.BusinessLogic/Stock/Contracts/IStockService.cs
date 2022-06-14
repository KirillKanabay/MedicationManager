using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.BusinessLogic.Stock.Dtos;

namespace MedicationManager.BusinessLogic.Stock.Contracts
{
    public interface IStockService<TStockDto> 
        where TStockDto : BaseStockDto
    {
        Task<List<TStockDto>> ListAllAsync();
        Task<TStockDto> GetByIdAsync(string id);
        Task UpdateAsync(TStockDto dto);
        Task AddAsync(TStockDto dto);
        Task DeleteAsync(string id);
    }
}
