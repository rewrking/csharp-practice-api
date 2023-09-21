namespace tutorial1.ResponseUtils;

public class ApiException : Exception
{
	public StatusCode Code;

	public ApiException(StatusCode code, string message = "Internal Server Error") : base(message)
	{
		Code = code;
	}
}