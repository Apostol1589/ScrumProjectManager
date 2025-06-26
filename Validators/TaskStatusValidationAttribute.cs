namespace ScrumProjectManager.Validators
{
    using System.ComponentModel.DataAnnotations;

    namespace ScrumProjectManager.Validators
    {
        public class TaskStatusValidationAttribute : ValidationAttribute
        {
            private static readonly string[] AllowedStatuses = { "ToDo", "InProgress", "Done" };

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string status && AllowedStatuses.Contains(status))
                    return ValidationResult.Success!;

                return new ValidationResult("Status must be one of: ToDo, InProgress, Done.");
            }
        }
    }

}
