using System.Collections.Generic;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationControlViewModel = MedicationManager.UI.Core.ViewModels.Medications.Control.MedicationControlViewModel;

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
            { MainMenuNames.Medication, _viewModelLocator.Resolve<MedicationControlViewModel>() }
        };

        public List<INavigationItem> NavigationItems => new()
        {
            new FirstLevelNavigationItem { Label = MainMenuNames.Medication, Icon = PackIconKind.Pill, IsSelected = true }
        };
    }
}
