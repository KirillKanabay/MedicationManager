using System.Collections.Generic;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.ViewModels.ProviderProducts;
using MedicationManager.UI.Core.ViewModels.Providers;
using MedicationControlViewModel = MedicationManager.UI.Core.ViewModels.Medications.MedicationControlViewModel;

namespace MedicationManager.UI.Core.ViewModels
{
    public class MainMenuViewModel
    {
        private readonly ViewModelLocator _viewModelLocator;

        public MainMenuViewModel(ViewModelLocator viewModelLocator)
        {
            _viewModelLocator = viewModelLocator;
        }

        public Dictionary<string, BaseViewModel> NavigationViewModels => new()
        {
            { MainMenuNames.Medication, _viewModelLocator.Resolve<MedicationControlViewModel>() },
            { MainMenuNames.Provider, _viewModelLocator.Resolve<ProviderControlViewModel>() },
            { MainMenuNames.ProviderProducts, _viewModelLocator.Resolve<ProviderProductControlViewModel>() }
        };

        public List<INavigationItem> NavigationItems => new()
        {
            new FirstLevelNavigationItem { Label = MainMenuNames.Medication, Icon = PackIconKind.Pill, IsSelected = true },
            new FirstLevelNavigationItem { Label = MainMenuNames.Provider, Icon = PackIconKind.Domain },
            new SecondLevelNavigationItem { Label = MainMenuNames.ProviderProducts, Icon = PackIconKind.PackageVariant },
        };
    }
}
