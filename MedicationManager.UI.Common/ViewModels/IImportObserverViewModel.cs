using System;

namespace MedicationManager.UI.Common.ViewModels
{
    public interface IImportObserverViewModel
    {
        void ImportCompletedHandler(object sender, EventArgs e);
    }
}