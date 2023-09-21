namespace tutorial1.ResponseUtils;

public class ResponseArray<T> : BaseResponse
{
	public class ResponseArrayData
	{
		public List<T> Items { get; set; } = new();

		public ResponseArrayData(List<T> items)
		{
			Items = items;
		}
	};

	public ResponseArrayData? Data { get; set; }

	public ResponseArray(RequestMethod method) : base(method) { }
}
