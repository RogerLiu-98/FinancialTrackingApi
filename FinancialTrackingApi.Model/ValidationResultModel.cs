namespace FinancialTrackingApi.Model
{
    public class ValidationResultModel
    {
        public List<ValidationError> Errors { get; set; } = new List<ValidationError>();
        public bool IsValid => Errors.Count == 0;
    }

    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
