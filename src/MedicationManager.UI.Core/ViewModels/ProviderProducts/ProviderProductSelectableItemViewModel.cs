using System.Threading.Tasks;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.EventArguments;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.ProviderProducts
{
    public class ProviderProductSelectableItemViewModel : BaseSelectableTableItemViewModel, IModelBasedViewModel<ProviderProductModel>
    {
        public ProviderProductModel Model { get; private set; }

        public override TaskBasedCommand DeleteItemCommand => new(DeleteItem);
        public override TaskBasedCommand EditItemCommand => new(EditItem);

        private Task DeleteItem()
        {
            OnProductDeleted();
            return Task.CompletedTask;
        }

        private Task EditItem()
        {
            return Task.CompletedTask;
        }

        public void Bind(ProviderProductModel model)
        {
            Model = model;
        }

        protected virtual void OnProductDeleted()
        {
            ProductDeleted?.Invoke(this, new ProviderProductDeletedEventArgs
            {
                Product = Model
            });
        }
    }
}
