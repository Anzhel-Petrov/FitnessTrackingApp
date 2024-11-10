using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.Common;

public class BodyWeightPrecisionAttribute : ValidationAttribute
{
    private readonly int _precision;
    private readonly int _scale;

    public BodyWeightPrecisionAttribute(int precision, int scale)
    {
        _precision = precision;
        _scale = scale;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is decimal decimalValue)
        {
            var stringValue = decimalValue.ToString($"F{_scale}");
            if (stringValue.Replace(".", "").Length - _scale > _precision - _scale)
            {
                return new ValidationResult($"The body weight must be in format {decimalValue}.75 (max two digits after the decimal point).");
            }
        }
        return ValidationResult.Success;
    }
}