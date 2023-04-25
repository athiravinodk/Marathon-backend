namespace Marathon_backend.Responses
{
    public interface IResponse
    {
        Boolean IsError { get; set; }
        String ErrorMessage { get; set; }
    }
}
