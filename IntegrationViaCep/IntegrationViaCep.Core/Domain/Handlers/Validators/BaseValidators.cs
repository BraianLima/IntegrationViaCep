namespace IntegrationViaCep.Core.Domain.Handlers.Validators
{
    /// <summary>
    /// Abstract class with generic methods
    /// </summary>
    public abstract class BaseValidators
    {
        /// <summary>
        /// Check if string is null or empty.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <returns></returns>
        public bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Check if object is null.
        /// </summary>
        /// <param name="data">Object</param>
        /// <returns></returns>
        public bool IsNull(object data)
        {
            return data == null;
        }
    }
}
