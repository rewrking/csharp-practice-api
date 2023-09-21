namespace tutorial1.ResponseUtils;

public class BaseResponse<T>
{
	public int ApiVersion { get; } = 1;
	public RequestMethod Method { get; set; }

	public BaseResponse(RequestMethod method)
	{
		Method = method;
	}
}

public class BaseResponse : BaseResponse<ResponseError>
{
	public BaseResponse(RequestMethod method) : base(method) { }
}
