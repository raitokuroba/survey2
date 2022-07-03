using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models.CustomAttribute
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private string PropertyName { get; set; }
        private object DesiredValue { get; set; }
        private readonly RequiredAttribute _innerAttribute;

        public RequiredIfAttribute(string propertyName, object desiredValue)
        {
            PropertyName = propertyName;
            DesiredValue = desiredValue;
            _innerAttribute = new RequiredAttribute();
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var dependentValue = context.ObjectInstance.GetType().GetProperty(PropertyName).GetValue(context.ObjectInstance, null);
            var desiredValue = DesiredValue?.ToString();

            if (dependentValue?.ToString().ToLower() == desiredValue?.ToLower())
            {
                if (!_innerAttribute.IsValid(value))
                {
                    return new ValidationResult($"The {context.DisplayName} field is required if {PropertyName} equal to {desiredValue ?? "null"}", new[] { context.MemberName });
                };
            }
            return ValidationResult.Success;
        }
    }
}
