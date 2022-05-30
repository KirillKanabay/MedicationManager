using System;
using System.Threading.Tasks;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public abstract class MedicationImportViewModelBase : BaseInteractionViewModel
    {
        private MedicationModel _model;

        public event EventHandler ImportCompleted;

        protected MedicationImportViewModelBase()
        {
            _model = new MedicationModel();
        }

        public MedicationModel Model
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

        protected virtual void OnImportCompleted()
        {
            ImportCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
