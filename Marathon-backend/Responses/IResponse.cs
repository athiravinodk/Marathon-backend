namespace Marathon_backend.Responses
{
    public interface IResponse
    {
        String Status { get; set; }
        String Message { get; set; }
        Boolean IsError { get; set; }
        String ErrorMessage { get; set; }
    }
}
