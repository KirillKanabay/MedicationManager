using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MedicationManager.Infrastructure.Extensions;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.EventArguments;
using MedicationManager.UI.Core.Factories;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.Providers.Import.Creator
{
    public class ProviderProductCreatorViewModel : BaseViewModel, IModelBasedViewModel<ProviderModel>
    {
        private ProviderModel _model;

        private readonly ProviderDialogFactory _providerDialogFactory;
        private readonly ViewModelLocator _viewModelLocator;

        public ProviderProductCreatorViewModel()
        {
            
        }

        public ProviderProductCreatorViewModel(ProviderDialogFactory providerDialogFactory, ViewModelLocator viewModelLocator)
        {
            _providerDialogFactory = providerDialogFactory;
            _viewModelLocator = viewModelLocator;
            Items = new ObservableCollection<ProviderProductSelectableItemViewModel>
            {
                new ProviderProductSelectableItemViewModel()
            };
        }

        public TaskBasedCommand OpenCreatorDialogCommand => new(OpenCreatorDialog);

        public ObservableCollection<ProviderProductSelectableItemViewModel> Items { get; set; }

        private async Task OpenCreatorDialog()
        {
            var dialog = _providerDialogFactory.CreateProviderConcreteProductCreator(this);
            Items.Add(new ProviderProductSelectableItemViewModel());
            await DialogHost.Show(dialog, HostRoots.ProviderDialogRoot);
        }

        public void Bind(ProviderModel model)
        {
            _model = model;
        }

        public void OnProductCreated(object? sender, ProviderProductCreatedEventArgs e)
        {
            Items.Assign(new []{ new ProviderProductSelectableItemViewModel() });
        }

        public void OnProductDeleted(object? sender, ProviderProductDeletedEventArgs e)
        {
            Items.Assign(Items.Where(x => !x.Model.Medication.Id.Equals(e.Product.Medication.Id)));
        }

        private ProviderProductSelectableItemViewModel CreateSelectableProduct(ProviderProductModel model)
        {
            var selectableProduct = _viewModelLocator.Resolve<ProviderProductSelectableItemViewModel, ProviderProductModel>(model);
            
            selectableProduct.ProductDeleted += OnProductDeleted;

            return selectableProduct;
        }
    }
}
