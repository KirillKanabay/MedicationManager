using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.UI.Common.Immutable;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public class MedicationCreatorViewModel : MedicationImportViewModelBase
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        private readonly ISnackbarMessageQueue _snackbarMessageQueue;
        public MedicationCreatorViewModel(IMedicationService medicationService, IMapper mapper, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _medicationService = medicationService;
            _mapper = mapper;
            _snackbarMessageQueue = snackbarMessageQueue;
        }

        public override string Title => "Создание медикамента";

        protected override async Task SaveModel()
        {
            LoaderVisibility = Visibility.Visible;

            var dto = _mapper.Map<MedicationDto>(Model);

            await _medicationService.AddAsync(dto);

            _snackbarMessageQueue.Enqueue(SnackbarConstants.MedicationCreatedMessage, SnackbarConstants.CloseSnackbarName, () => { });

            await base.SaveModel();
        }
    }
}
