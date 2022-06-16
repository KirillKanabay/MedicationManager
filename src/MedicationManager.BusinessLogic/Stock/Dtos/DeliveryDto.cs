using MedicationManager.BusinessLogic.Providers.Dtos;

namespace MedicationManager.BusinessLogic.Stock.Dtos
{
    public class DeliveryDto : BaseStockDto
    {
        public string ProviderId { get; set; }

        public ProviderDto Provider { get; set; }
    }
}
