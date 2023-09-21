namespace tutorial1.ResponseUtils;

public enum StatusCode
{
	// 200
	OK = 200,
	Created = 201,
	Accepted = 202,
	NoContent = 204,

	// 300
	MovedPermenantly = 301,
	NotModified = 304,

	// 400
	BadRequest = 400,
	Unauthorized = 401,
	Forbidden = 403,
	NotFound = 404,
	MethodNotAllowed = 405,
	NotAcceptable = 406,

	// 500,
	InternalServerError = 500,
	NotImplemented = 501,
	BadGateway = 502,

}