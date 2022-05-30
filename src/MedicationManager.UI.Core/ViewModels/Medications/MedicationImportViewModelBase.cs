using System.Threading.Tasks;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public abstract class MedicationImportViewModelBase : BaseInteractionViewModel
    {
        private MedicationImportModel _model;

        protected MedicationImportViewModelBase()
        {
            _model = new MedicationImportModel();
        }

        public MedicationImportModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public virtual TaskBasedCommand SaveItemCommand => new(SaveModel);

        protected abstract Task SaveModel();
    }
}
