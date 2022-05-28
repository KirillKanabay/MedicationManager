using System;
using MaterialDesignExtensions.Controls;
using MaterialDesignExtensions.Model;
using MedicationManager.Common.UI.Commands;
using MedicationManager.Common.UI.Immutable;
using MedicationManager.Common.UI.ViewModels;
using MedicationManager.UI.Core.ViewModels.Medications;

namespace MedicationManager.UI.Core.ViewModels
{
    public class StartWindowViewModel : BaseViewModel
    {
        private readonly string _defaultMenuItem = MainMenuNames.Medication;
        private readonly MainMenuViewModel _mainMenuViewModel;
        
        private BaseViewModel _currentViewModel;
        private string _currentViewModelName;

        public StartWindowViewModel(MainMenuViewModel mainMenuViewModel, MedicationControlViewModel medicationPageViewModel)
        {
            MainMenuViewModel = mainMenuViewModel ?? throw new ArgumentNullException(nameof(mainMenuViewModel));
            CurrentViewModel = medicationPageViewModel;
        }

        public string Title => "Управление медикаментами";

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainMenuViewModel MainMenuViewModel
        {
            get => _mainMenuViewModel;
            private init
            {
                _mainMenuViewModel = value;
                OnPropertyChanged(nameof(MainMenuViewModel));
            }
        }

        public DelegateCommand<WillSelectNavigationItemEventArgs> SelectNavigationItemCommand => new(_ =>
        {
            if (_.NavigationItemToSelect is FirstLevelNavigationItem navigationItem)
            {
                if (!navigationItem.Label?.Equals(_currentViewModelName) ?? false)
                {
                    CurrentViewModel = _mainMenuViewModel.NavigationViewModels[navigationItem.Label];
                }
            }
        });

        public DelegateCommand OnLoadedCommand => new(_ =>
        {
            _currentViewModelName = _defaultMenuItem;
            CurrentViewModel = _mainMenuViewModel.NavigationViewModels[_defaultMenuItem];
        });
    }
}
