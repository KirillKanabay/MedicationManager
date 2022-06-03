namespace MedicationManager.UI.Common.ViewModels
{
    public interface IObservableViewModel
    {
        void Register(IImportObserverViewModel observer);
        void Publish();
    }
}