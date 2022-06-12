using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.Infrastructure.Extensions;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.EventArguments;
using MedicationManager.UI.Core.Models.Medications;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.Providers.Import.Creator
{
    public class ProviderConcreteProductCreatorViewModel : BaseViewModel
    {
        private ProviderModel _providerModel;
        private ProviderProductModel _providerProductModel;
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        public ProviderConcreteProductCreatorViewModel(IMedicationService medicationService, IMapper mapper)
        {
            _medicationService = medicationService;
            _mapper = mapper;
            Medications = new ObservableCollection<MedicationModel>();
            Model = new ProviderProductModel();
        }

        public event EventHandler<ProviderProductCreatedEventArgs> ProductCreated;
        
        public string Title => "Добавление продукта";

        public ProviderProductModel Model
        {
            get => _providerProductModel;
            set
            {
                _providerProductModel = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public ObservableCollection<MedicationModel> Medications { get; }

        public TaskBasedCommand OnLoadCommand => new(GetMedications);
        public DelegateCommand SaveItemCommand => new(SaveItem);

        private void SaveItem(object param)
        {
            OnProductCreated();
            DialogHost.Close(HostRoots.ProviderDialogRoot);
        }

        private async Task GetMedications()
        {
            var dtos = await _medicationService.ListAllAsync();
            var medications = _mapper.Map<List<MedicationModel>>(dtos);

            Medications.Assign(medications);
        }
        
        public void Bind(ProviderModel model)
        {
            _providerModel = model;
        }

        protected virtual void OnProductCreated()
        {
            ProductCreated?.Invoke(this, new ProviderProductCreatedEventArgs
            {
                Product = Model
            });
        } 
    }
}
