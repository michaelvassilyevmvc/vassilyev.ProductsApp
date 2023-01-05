using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Attributes
{
    public class DateLessThanAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string _comparisonProperty;

        public DateLessThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            var error = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-error", error);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || validationContext == null)
                return null;

            ErrorMessage = ErrorMessageString;
            var currentValue = (DateTime)value;

            if (currentValue.Year < 1900) return null;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if(property == null)
            {
                throw new ArgumentException("Property with this name not found");
            }

            try
            {
                var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

                if (currentValue > comparisonValue)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return base.IsValid(value, validationContext);
            }
            catch 
            {
                return null;
            }

            
        }
    }
}
