using System.Text.Json.Serialization;

namespace tutorial1.ResponseUtils;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RequestMethod
{
	GET,
	POST,
	PUT,
	DELETE,
}