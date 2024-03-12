using System;
using System.ComponentModel.DataAnnotations;

public class StartBeforeEndDateAttribute : ValidationAttribute
{
    private readonly string _startDatePropertyName;

    public StartBeforeEndDateAttribute(string startDatePropertyName)
    {
        _startDatePropertyName = startDatePropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);

        if (startDateProperty == null)
        {
            return new ValidationResult($"Unknown property {_startDatePropertyName}");
        }

        var startDateValue = (DateTime)startDateProperty.GetValue(validationContext.ObjectInstance);

        if (value == null || startDateValue == null)
        {
            return ValidationResult.Success;
        }

        DateTime startDate = (DateTime)startDateValue;
        DateTime endDate = (DateTime)value;

        if (startDate > endDate)
        {
            return new ValidationResult("End Date must be after Start Date");
        }

        return ValidationResult.Success;
    }
}
