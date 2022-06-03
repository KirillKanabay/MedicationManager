using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FluentValidation;

namespace MedicationManager.UI.Common.Models
{
    public abstract class BaseValidatableModel : BaseModel, IDataErrorInfo
    {
        private readonly IValidator _validator;

        protected BaseValidatableModel(IValidator validator)
        {
            _validator = validator;
        }
        
        protected abstract IValidationContext ValidationContext { get; }

        public virtual string Error { get; }

        public string? this[string columnName]
        {
            get
            {
                var validationResult = _validator.Validate(ValidationContext);
                var error = validationResult.Errors?
                    .FirstOrDefault(x => x.PropertyName.Equals(columnName))?.ErrorMessage;

                return error;
            }
        }
    }
}
