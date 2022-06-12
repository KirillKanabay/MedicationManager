using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FluentValidation;

namespace MedicationManager.UI.Common.Models
{
    public abstract class BaseValidatableModel : BaseModel, IDataErrorInfo
    {
        private readonly IValidator _validator;
        private readonly HashSet<string> _failedProps = new();
        private bool _isValid;

        protected BaseValidatableModel(IValidator validator)
        {
            _validator = validator;
        }
        
        protected abstract IValidationContext ValidationContext { get; }

        public virtual string Error { get; }

        public virtual bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }
        
        public string? this[string columnName]
        {
            get
            {
                var validationResult = _validator.Validate(ValidationContext);
                var error = validationResult.Errors?
                    .FirstOrDefault(x => x.PropertyName.Equals(columnName))?.ErrorMessage;

                if (error != null)
                {
                    _failedProps.Add(columnName);
                }
                else
                {
                    _failedProps.Remove(columnName);
                }

                IsValid = !_failedProps.Any();

                return error;
            }
        }
    }
}
