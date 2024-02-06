namespace FinancialTrackingApi.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidationAttribute : Attribute
    {
        public Type ValidatorType { get; set; }

        public ValidationAttribute(Type validatorType)
        {
            ValidatorType = validatorType;
        }
    }
}
