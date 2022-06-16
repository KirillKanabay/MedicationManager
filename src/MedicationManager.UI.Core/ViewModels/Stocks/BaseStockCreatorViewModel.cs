using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Stock.Contracts;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Medications;
using MedicationManager.UI.Core.Models.Providers;
using MedicationManager.UI.Core.Models.Stock;

namespace MedicationManager.UI.Core.ViewModels.Stocks
{
    public abstract class BaseStockCreatorViewModel<TStockModel, TStockDto> : BaseInteractionViewModel
        where TStockModel : BaseStockModel, new()
        where TStockDto : BaseStockDto, new()
    {
        protected readonly IStockService<TStockDto> Service;
        protected readonly IMapper Mapper;
        protected readonly ISnackbarMessageQueue MessageQueue;

        private TStockModel _model;
        
        public event EventHandler ImportCompleted;

        protected BaseStockCreatorViewModel(IStockService<TStockDto> service, IMapper mapper, ISnackbarMessageQueue messageQueue)
        {
            Service = service;
            Mapper = mapper;
            MessageQueue = messageQueue;

            _model = new TStockModel();
            Medications = new ObservableCollection<MedicationModel>();
        }

        public abstract string Title { get; }
        protected abstract string CreatedMessage { get; }
        
        public ObservableCollection<MedicationModel> Medications { get; }

        public TaskBasedCommand OnLoadCommand => new(LoadHandler);
        public TaskBasedCommand SaveItemCommand => new(SaveModel);

        public TStockModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        protected abstract Task LoadHandler();

        protected virtual async Task SaveModel()
        {
            LoaderVisibility = Visibility.Visible;

            var dto = Mapper.Map<TStockDto>(Model);
            await Service.AddAsync(dto);

            MessageQueue.Enqueue(CreatedMessage, SnackbarConstants.CloseSnackbarName, () => {});

            OnImportCompleted();
            LoaderVisibility = Visibility.Collapsed;
        }

        protected virtual void OnImportCompleted()
        {
            ImportCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}