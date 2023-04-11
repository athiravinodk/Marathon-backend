namespace Marathon_backend.Responses
{
    public class SingleModelResponse<T> : ISingleModelResponse<T>, IDisposable
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public T Model { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
