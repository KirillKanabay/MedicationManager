using System.Collections.Generic;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using MedicationManager.Common.UI.Immutable;
using MedicationManager.Common.UI.ViewModels;
using MedicationManager.UI.Core.ViewModels.Medications;

namespace MedicationManager.UI.Core.ViewModels
{
    public class MainMenuViewModel
    {
        private readonly MedicationPageViewModel _medicationPageViewModel;

        public MainMenuViewModel(MedicationPageViewModel medicationPageViewModel)
        {
            _medicationPageViewModel = medicationPageViewModel;
        }

        public Dictionary<string, BaseViewModel> NavigationViewModels => new()
        {
            {MainMenuNames.Medication, _medicationPageViewModel}
        };

        public List<INavigationItem> NavigationItems => new()
        {
            new FirstLevelNavigationItem {Label = MainMenuNames.Medication, Icon = PackIconKind.Pill, IsSelected = true}
        };
    }
}
