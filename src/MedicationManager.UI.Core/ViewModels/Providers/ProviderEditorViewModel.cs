using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.Providers
{
    public class ProviderEditorViewModel : ProviderImportViewModelBase, IModelBasedViewModel<ProviderModel>
    {
        public override string Title => "Редактирование поставщика";

        public ProviderModel Model { get; private set; }

        public void Bind(ProviderModel model)
        {
            Model = model;
        }
    }
}