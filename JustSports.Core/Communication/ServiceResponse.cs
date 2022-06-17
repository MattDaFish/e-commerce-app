namespace JustSports.Core.Communication
{
    public abstract class ServiceResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        protected ServiceResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        protected ServiceResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}