using Azure;

namespace Marathon_backend.Responses
{
    public interface ISingleModelResponse<T> : IResponse, IDisposable
    {
        T Model { get; set; }
    }
}
