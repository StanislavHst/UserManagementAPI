namespace UserManagement.Application.Requests;

public class Response
{
    public bool IsSuccess { get; set; }

    public object Result { get; set; }


    public string DisplayMessage { get; set; }

    public List<string> ErrorMessages { get; set; }

    public Response()
    {
        IsSuccess = true;
        ErrorMessages = new List<string>();
        DisplayMessage = string.Empty;
    }
}