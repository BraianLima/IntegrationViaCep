namespace IntegrationViaCep.Core.Domain.Handlers.Validators
{
    public abstract class BaseValidators
    {
        public bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public bool IsNull(object data)
        {
            return data == null;
        }
    }
}
