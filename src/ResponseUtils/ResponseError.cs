namespace tutorial1.ResponseUtils;

public class ResponseError : BaseResponse
{
	public class ResponseErrorData
	{
		public StatusCode Code { get; set; } = StatusCode.InternalServerError;
		public string Message { get; set; } = string.Empty;
	}

	public ResponseErrorData Error { get; set; } = new();

	public ResponseError(RequestMethod method) : base(method) { }

};