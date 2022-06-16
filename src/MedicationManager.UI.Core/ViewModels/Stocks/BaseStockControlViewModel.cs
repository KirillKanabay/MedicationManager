using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Stock.Contracts;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.Infrastructure.Extensions;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Factories;
using MedicationManager.UI.Core.Models.Stock;

namespace MedicationManager.UI.Core.ViewModels.Stocks
{
    public abstract class BaseStockControlViewModel<TStockModel, TStockDto> : BaseViewModel, IImportObserverViewModel
        where TStockModel : BaseStockModel
        where TStockDto : BaseStockDto

    {
        protected readonly StockDialogFactory DialogFactory;
        protected readonly IMapper Mapper;
        protected readonly ViewModelLocator ViewModelLocator;
        protected readonly IStockService<TStockDto> Service;

        protected BaseStockControlViewModel(StockDialogFactory dialogFactory, IMapper mapper,
            ViewModelLocator viewModelLocator, ISnackbarMessageQueue messageQueue, IStockService<TStockDto> service)
        {
            DialogFactory = dialogFactory;
            Mapper = mapper;
            ViewModelLocator = viewModelLocator;

            Items = new ObservableCollection<TStockModel>();
            MessageQueue = messageQueue;
            Service = service;
        }

        public virtual ObservableCollection<TStockModel> Items { get; }
        public ISnackbarMessageQueue MessageQueue { get; }

        public TaskBasedCommand OnLoadCommand => new(GetItems);
        public TaskBasedCommand OpenCreatorDialogCommand => new(OpenCreatorDialog);

        public async void ImportCompletedHandler(object? sender, EventArgs e)
        {
            await GetItems();
        }

        protected virtual async Task GetItems()
        {
            var dtos = await Service.ListAllAsync();

            var models = Mapper.Map<List<TStockModel>>(dtos);

            Items.Assign(models);
        }

        protected abstract Task OpenCreatorDialog();
    }
}