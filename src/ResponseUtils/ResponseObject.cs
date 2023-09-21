namespace tutorial1.ResponseUtils;

public class ResponseObject<T> : BaseResponse
{
	public T? Data { get; set; }

	public ResponseObject(RequestMethod method) : base(method) { }
}