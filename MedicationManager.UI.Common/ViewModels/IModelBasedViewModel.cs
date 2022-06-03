using MedicationManager.UI.Common.Models;

namespace MedicationManager.UI.Common.ViewModels
{
    public interface IModelBasedViewModel<in TModel> where TModel : BaseModel
    {
        void Bind(TModel model);
    }
}
