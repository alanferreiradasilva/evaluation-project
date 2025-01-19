namespace NetCore.Ambev.Abstractions.Entities.Validations
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string error) : base(error)
        { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainValidation(error);
        }

        public static void WhenRequired(string value, string fieldName, string? error = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (error is not null)
                    throw new DomainValidation(error);
                else
                    throw new DomainValidation($"Invalid {fieldName}. Field required.");
            }
        }

        public static void NotInRange(int value, int startValue, int endValue, string fieldName, string? error = null)
        {
            if (value < startValue || value > endValue)
            {
                if (error is not null)
                    throw new DomainValidation(error);
                else
                    throw new DomainValidation($"Invalid {fieldName}. {fieldName} must be between {startValue} and {endValue} characters long.");
            }
        }
    }
}
