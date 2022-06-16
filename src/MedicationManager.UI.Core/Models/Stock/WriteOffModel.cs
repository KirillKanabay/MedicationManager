using FluentValidation;
using MedicationManager.UI.Core.Validators.Stocks;

namespace MedicationManager.UI.Core.Models.Stock
{
    public class WriteOffModel : BaseStockModel
    { 
        protected override IValidationContext ValidationContext => new ValidationContext<WriteOffModel>(this);

        public WriteOffModel() : base(new WriteOffValidator())
        {

        }
    }
}