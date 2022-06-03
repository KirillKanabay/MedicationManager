using System;
using MedicationManager.UI.Common.Models;
using MedicationManager.UI.Common.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationManager.UI.Common
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

        public TViewModel Resolve<TViewModel, TModel>(TModel model)
            where TModel : BaseModel
            where TViewModel : BaseViewModel, IModelBasedViewModel<TModel>
        {
            var vm = _serviceProvider.GetService<TViewModel>() ?? throw new ArgumentNullException();
            vm.Bind(model);

            return vm;
        }
    }
}
