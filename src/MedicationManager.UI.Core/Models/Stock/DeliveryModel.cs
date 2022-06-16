using FluentValidation;
using MedicationManager.UI.Core.Models.Providers;
using MedicationManager.UI.Core.Validators.Stocks;

namespace MedicationManager.UI.Core.Models.Stock
{
    public class DeliveryModel : BaseStockModel
    {
        protected override IValidationContext ValidationContext => new ValidationContext<DeliveryModel>(this);

        public DeliveryModel() : base(new DeliveryModelValidator())
        {
        }

        public string ProviderId { get; set; }
        public ProviderModel Provider { get; set; }
    }
}