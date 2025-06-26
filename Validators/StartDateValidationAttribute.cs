using System.ComponentModel.DataAnnotations;

namespace ScrumProjectManager.Validators
{
    public class StartDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not DateTime startDate)
                return new ValidationResult("Invalid date format.");

            if (startDate < DateTime.Today)
                return new ValidationResult("Start date cannot be in the past.");

            if (startDate > DateTime.Today.AddDays(30))
                return new ValidationResult("Start date cannot be more than 30 days in the future.");

            return ValidationResult.Success;
        }
    }
}
