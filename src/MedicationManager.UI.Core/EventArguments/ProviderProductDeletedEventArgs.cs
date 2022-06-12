using System;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.EventArguments
{
    public class ProviderProductDeletedEventArgs : EventArgs
    {
        public ProviderProductModel Product { get; set; }
    }
}
