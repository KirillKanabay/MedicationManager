using MedicationManager.UI.Common.Models;

namespace MedicationManager.UI.Core.Models.Providers
{
    public class ProviderProductFilterModel : BaseModel
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}