using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.Providers.Import.Creator
{
    public class ProviderInformationCreatorViewModel : BaseViewModel, IModelBasedViewModel<ProviderModel>
    {
        private ProviderModel _model;
        
        public ProviderModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public void Bind(ProviderModel model)
        {
            _model = model;
        }
    }
}
