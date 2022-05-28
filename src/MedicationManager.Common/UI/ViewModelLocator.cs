using System;
using MedicationManager.Common.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationManager.Common.UI
{
    public class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TViewModel Resolve<TViewModel>() where TViewModel : BaseViewModel
        {
            return _serviceProvider.GetService<TViewModel>() ?? throw new ArgumentNullException();
        }
    }
}
