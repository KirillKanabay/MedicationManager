using System;
using System.Windows;
using MaterialDesignExtensions.Controls;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.ViewModels.Medications;
using MedicationControlViewModel = MedicationManager.UI.Core.ViewModels.Medications.MedicationControlViewModel;

namespace MedicationManager.UI.Core.ViewModels
{
    public class StartWindowViewModel : BaseViewModel
    {
        private readonly string _defaultMenuItem = MainMenuNames.Medication;
        private readonly MainMenuViewModel _mainMenuViewModel;
        
        private BaseViewModel _currentViewModel;
        private string _currentViewModelName;

        public StartWindowViewModel(MainMenuViewModel mainMenuViewModel, 
            MedicationControlViewModel medicationPageViewModel,
            ISnackbarMessageQueue messageQueue)
        {
            MainMenuViewModel = mainMenuViewModel ?? throw new ArgumentNullException(nameof(mainMenuViewModel));
            CurrentViewModel = medicationPageViewModel ?? throw new ArgumentNullException(nameof(medicationPageViewModel));
            MessageQueue = messageQueue ?? throw new ArgumentNullException(nameof(messageQueue));
        }

        public string Title => "Управление медикаментами";

        public ISnackbarMessageQueue MessageQueue { get; }

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
            if (_.NavigationItemToSelect is NavigationItem navigationItem)
            {
                if (!navigationItem.Label?.Equals(_currentViewModelName) ?? false)
                {
                    CurrentViewModel = _mainMenuViewModel.NavigationViewModels[navigationItem.Label];
                    _currentViewModelName = navigationItem.Label;
                }
            }
        });

        public DelegateCommand OnLoadedCommand => new(_ =>
        {
            _currentViewModelName = _defaultMenuItem;
            CurrentViewModel = _mainMenuViewModel.NavigationViewModels[_defaultMenuItem];
        });

        public DelegateCommand<Window> CloseWindowCommand => new(_ =>
        {
            _.Close();
        });

        public DelegateCommand<Window> MinimizeWindowCommand => new(_ =>
        {
            _.WindowState = WindowState.Minimized;
        });
    }
}
